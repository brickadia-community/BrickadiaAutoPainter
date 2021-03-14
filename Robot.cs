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
	public class Robot : IDisposable {
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

		public DateTime? StartTime = null;
		public DateTime? EndTime = null;

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

		public List<KeyValuePair<(int, int), List<(int, int)>>> PalettePixelPairs = default;
		public int PairIndex = 0;
		public int PairPixelIndex = 0;
		private (int, int)? pairToDelete = null;
		private (int, int) skippedColor = (0, 0);

		public Dictionary<(int, int), double> ColorAccuracy;

		public Perspective CreatePerspective() {
			return new Perspective(TopLeft.Value, TopRight.Value, BottomLeft.Value, BottomRight.Value);
		}

		public int PixelsCompleted() {
			int sum = 0;
			for (int i = 0; i < PairIndex - 1; i++) {
				sum += PalettePixelPairs[i].Value.Count;
			}
			sum += PairPixelIndex;
			return sum;
		}

		public int TotalPixels() {
			return PalettePixelPairs.Aggregate(0, (c, pair) => c + pair.Value.Count);
		}

		public void SetPaintProgress() {
			if (PalettePixelPairs == default) {
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
				}
			} else if (nx < px) {
				// Press E until x = 0, then press E to nx.
				for (int i = 0; i < (Palette.Colors.Count - px + nx); i++) {
					Windows.KeyboardEvent(69, Window, ColorChangeDelay);
					Thread.Sleep(ColorChangeDelay);
				}
			}

			py = Math.Min(py, Palette.Colors[nx].Count - 1);

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
			for (; PairIndex < PalettePixelPairs.Count; PairIndex++) {
				KeyValuePair<(int, int), List<(int, int)>> pair = PalettePixelPairs[PairIndex];
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
					bool nextPixelAdjacent = nextPixel.HasValue ? nextPixel == (pixel.Item1 + 1, pixel.Item2) : false;

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

					if (!nextPixelAdjacent || usingHammer) {
						// don't release mouse if next pixel is adjacent
						Windows.MouseClick("left", 0);
						Thread.Sleep(ColorPlaceDelay);
						Windows.MouseClick("left", 1);
					}

					Thread.Sleep(ColorPlaceDelay);
				}
			}

			if (SkipColors == SkipColorsSetting.MostFrequent && !Stop && !Paused)
				ChangePaletteColor((paletteX, paletteY), skippedColor);

			if (!Stop && !Paused) {
				Active = false;
				EndTime = DateTime.Now;

				// display post paint form
				Form.CreateAndShowPostPaint(this);
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
			ColorAccuracy = new Dictionary<(int, int), double>();

			Perspective perspective = CreatePerspective();
			using Bitmap bitmap = new Bitmap(Image, new Size(Width, Height));
			for (int iy = 0; iy < bitmap.Height; iy++) {
				for (int ix = 0; ix < bitmap.Width; ix++) {
					Color rawColor = bitmap.GetPixel(ix, iy);
					BrickadiaColor color = new BrickadiaColor(rawColor);

					if (SkipColors == SkipColorsSetting.Transparent && rawColor.A > 127)
						continue;

					(int, int, double) colorData = Palette.ClosestColorPalettePositionWithDistance(color, ColorSpace);
					(int, int) palettePos = (colorData.Item1, colorData.Item2);

					double tx = ix / (double)(Width - 1);
					double ty = iy / (double)(Height - 1);

					(int, int) pxy = perspective.PointOn(tx, ty);

					if (!palettePixelPair.ContainsKey(palettePos)) {
						palettePixelPair[palettePos] = new List<(int, int)> { pxy };
						ColorAccuracy[palettePos] = Math.Abs(1 - (colorData.Item3)); // hard-coded value to determine how accurate a color is (>Ndist becomes 0%, 0dist = 100%)
					} else
						palettePixelPair[palettePos].Add(pxy);
				}
			}

			PalettePixelPairs = palettePixelPair.ToList();

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
			StartTime = DateTime.Now;
		}
	}
}
