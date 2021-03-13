using NHotkey;
using NHotkey.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BrickadiaAutoPainter {
	class Robot : IDisposable {
		public IntPtr Window;
		public int ColorPlaceDelay;
		public int AfterColorPickDelay;
		public int ColorChangeDelay;
		public ColorPalette Palette;
		public Bitmap Image;
		public int Width;
		public int Height;
		public ColorSpaceSetting ColorSpace;
		public SkipColorsSetting SkipColors;

		public (int, int)? TopLeft;
		public (int, int)? TopRight;
		public (int, int)? BottomLeft;
		public (int, int)? BottomRight;

		public bool Active = false;

		public Form1 Form;

		private int paletteX = 0;
		private int paletteY = 0;
		private bool usingHammer = false;

		public bool Stop = false;
		public bool Paused = false;

		private List<KeyValuePair<(int, int), List<(int, int)>>> palettePixelPairs = default;
		public int PairIndex = 0;
		public int PairPixelIndex = 0;
		private (int, int)? pairToDelete = null;
		private (int, int) skippedColor = (0, 0);

		public Perspective CreatePerspective() {
			return new Perspective(TopLeft.Value, TopRight.Value, BottomLeft.Value, BottomRight.Value);
		}

		public int PixelsCompleted() {
			int sum = 0;
			for (int i = 0; i < PairIndex - 1; i++) {
				sum += palettePixelPairs[i].Value.Count;
			}
			sum += PairPixelIndex;
			return sum;
		}

		public int TotalPixels() {
			return palettePixelPairs.Aggregate(0, (c, pair) => c + pair.Value.Count);
		}

		public void SetPaintProgress() {
			if (palettePixelPairs == default) {
				Form.SetPaintProgress(0);
				return;
			}

			Form.SetPaintProgress(PixelsCompleted() / (double)TotalPixels());
		}

		public void ChangePaletteColor((int, int) previous, (int, int) next) {
			(int px, int py) = previous;
			(int nx, int ny) = next;

			// change X
			if (nx == px) {
				// No changes to be made for groups.
			} else if (nx > px) {
				// Press E until we reach the new group.
				for (int i = 0; i < (nx - px); i++) {
					Windows.KeyboardEvent(69, Window, ColorChangeDelay);
					Thread.Sleep(ColorChangeDelay);
					py = Math.Min(py, Palette.Colors[px + i + 1].Count - 1);
				}
			} else if (nx < px) {
				// Press E until x = 0, then press E to nx.
				for (int i = 0; i < (Palette.Colors.Count - px + nx); i++) {
					Windows.KeyboardEvent(69, Window, ColorChangeDelay);
					Thread.Sleep(ColorChangeDelay);
					py = Math.Min(py, Palette.Colors[(px + i + 1) % Palette.Colors.Count].Count - 1);
				}
			}

			// change Y
			if (ny == py) {
				// No changes made to Y.
			} else if (ny > py) {
				// Scroll down to reach ny.
				for (int i = 0; i < (ny - py); i++) {
					Windows.mouse_event(0x800, 0, 0, -120, 0);
					Thread.Sleep(ColorChangeDelay);
				}
			} else if (ny < py) {
				// Scroll up to reach ny.
				for (int i = 0; i < (py - ny); i++) {
					Windows.mouse_event(0x800, 0, 0, 120, 0);
					Thread.Sleep(ColorChangeDelay);
				}
			}
		}

		public void Dispose() {
			Image.Dispose();
		}

		public Bitmap GeneratePreview() {
			Bitmap preview = new Bitmap(Image, new Size(Width, Height));
			for (int y = 0; y < Height; y++) {
				for (int x = 0; x < Width; x++) {
					BrickadiaColor pixel = new BrickadiaColor(preview.GetPixel(x, y));
					preview.SetPixel(x, y, Palette.ClosestColor(pixel, ColorSpace).ToColor());
				}
			}
			return preview;
		}

		public void PaintFromState() {
			int startPairIndex = PairIndex;
			for (; PairIndex < palettePixelPairs.Count; PairIndex++) {
				KeyValuePair<(int, int), List<(int, int)>> pair = palettePixelPairs[PairIndex];
				bool shouldBeDeleting = pairToDelete == pair.Key;

				if (Stop || Paused) break;

				ChangePaletteColor((paletteX, paletteY), pair.Key);
				paletteX = pair.Key.Item1;
				paletteY = pair.Key.Item2;
				Thread.Sleep(AfterColorPickDelay);

				if (PairIndex != startPairIndex) PairPixelIndex = 0;
				for (; PairPixelIndex < pair.Value.Count; PairPixelIndex++) {
					if (Stop || Paused) break;
					(int, int) pixel = pair.Value[PairPixelIndex];
					(int, int)? nextPixel = PairPixelIndex + 1 >= pair.Value.Count ? ((int, int)?)null : pair.Value[PairPixelIndex + 1];
					bool nextPixelAdjacent = nextPixel.HasValue ? pixel.Item1 + 1 == nextPixel.Value.Item1 : false;

					if (shouldBeDeleting && !usingHammer) {
						// switch to hammer
						Windows.KeyboardEvent(0x51, Window, ColorChangeDelay);
						Thread.Sleep(ColorChangeDelay);
						usingHammer = true;
					}

					if (!shouldBeDeleting && usingHammer) {
						// switch back to paint
						Windows.KeyboardEvent(69, Window, ColorChangeDelay);
						Thread.Sleep(ColorChangeDelay);
						usingHammer = false;
					}

					Windows.SetCursorPos(pixel.Item1, pixel.Item2);
					Windows.MouseClick("left", 0);
					Thread.Sleep(ColorPlaceDelay);

					if (!nextPixelAdjacent || shouldBeDeleting) {
						// don't release mouse if next pixel is adjacent
						Windows.MouseClick("left", 1);
						Thread.Sleep(ColorPlaceDelay);
					}
				}
			}

			if (SkipColors == SkipColorsSetting.MostFrequent && !Stop && !Paused)
				ChangePaletteColor((paletteX, paletteY), skippedColor);

			if (!Stop && !Paused) {
				Active = false;
				Form.SetWindowState(FormWindowState.Normal);
			}

			SetPaintProgress();
		}

		public void Paint() {
			Stop = false;
			Paused = false;
			Active = true;
			PairIndex = 0;
			PairPixelIndex = 0;
			SetPaintProgress();

			Dictionary<(int, int), List<(int, int)>> palettePixelPair = new Dictionary<(int, int), List<(int, int)>>();

			Perspective perspective = CreatePerspective();
			using Bitmap bitmap = new Bitmap(Image, new Size(Width, Height));
			for (int iy = 0; iy < bitmap.Height; iy++) {
				for (int ix = 0; ix < bitmap.Width; ix++) {
					Color rawColor = bitmap.GetPixel(ix, iy);
					BrickadiaColor color = new BrickadiaColor(rawColor);

					if (SkipColors == SkipColorsSetting.Transparent && rawColor.A > 127)
						continue;

					(int, int) palettePos = Palette.ClosestColorPalettePosition(color, ColorSpace);

					double tx = ix / (double)(Width - 1);
					double ty = iy / (double)(Height - 1);

					(int, int) pxy = perspective.PointOn(tx, ty);

					if (!palettePixelPair.ContainsKey(palettePos))
						palettePixelPair[palettePos] = new List<(int, int)> { pxy };
					else
						palettePixelPair[palettePos].Add(pxy);
				}
			}

			palettePixelPairs = palettePixelPair.ToList();

			// handle skipping most frequent color
			skippedColor = (0, 0);
			if (SkipColors == SkipColorsSetting.MostFrequent) {
				var pairsList = palettePixelPair.ToList();
				pairsList.Sort((a, b) => b.Value.Count - a.Value.Count);
				palettePixelPair.Remove(pairsList.First().Key);
				skippedColor = pairsList.First().Key;
			} else if (SkipColors == SkipColorsSetting.DeleteMostFrequent) {
				var pairsList = palettePixelPair.ToList();
				pairsList.Sort((a, b) => b.Value.Count - a.Value.Count);
				palettePixelPair.Remove(pairsList.First().Key);
				pairToDelete = pairsList.First().Key;
			}

			// painting needs to happen in a different thread to allow for keybinds to still work
			Thread paintThread = new Thread(PaintFromState);
			paintThread.Start();
		}
	}
}
