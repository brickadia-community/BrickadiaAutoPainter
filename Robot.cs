using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

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

		private int paletteX = 0;
		private int paletteY = 0;

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

		public void Paint() {
			(int, int) topLeft = TopLeft.Value;
			(int, int) topRight = TopRight.Value;
			(int, int) bottomLeft = BottomLeft.Value;
			(int, int) bottomRight = BottomRight.Value;

			Dictionary<(int, int), List<(int, int)>> palettePixelPair = new Dictionary<(int, int), List<(int, int)>>();

			Perspective perspective = new Perspective(topLeft, topRight, bottomLeft, bottomRight);
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

			// handle skipping most frequent color
			(int, int) skippedColor = (0, 0);
			if (SkipColors == SkipColorsSetting.MostFrequent) {
				var pairsList = palettePixelPair.ToList();
				pairsList.Sort((a, b) => b.Value.Count - a.Value.Count);
				palettePixelPair.Remove(pairsList.First().Key);
				skippedColor = pairsList.First().Key;
			}

			foreach (KeyValuePair<(int, int), List<(int, int)>> pair in palettePixelPair) {
				ChangePaletteColor((paletteX, paletteY), pair.Key);
				paletteX = pair.Key.Item1;
				paletteY = pair.Key.Item2;
				Thread.Sleep(AfterColorPickDelay);
				foreach ((int, int) pixel in pair.Value) {
					Windows.SetCursorPos(pixel.Item1, pixel.Item2);
					Windows.MouseClick("left", 0);
					Thread.Sleep(ColorPlaceDelay);
					Windows.MouseClick("left", 1);
					Thread.Sleep(ColorPlaceDelay);
				}
			}

			if (SkipColors == SkipColorsSetting.MostFrequent)
				ChangePaletteColor((paletteX, paletteY), skippedColor);
		}
	}
}
