using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BrickadiaAutoPainter {
	public class PresetColorPaletteEntry {
		[JsonProperty("data")]
		public PresetColorPalette Data;
	}

	public class PresetColorPalette {
		[JsonProperty("groups")]
		public List<PresetColorPaletteGroup> Groups;
	}

	public class PresetColorPaletteGroup {
		[JsonProperty("colors")]
		public List<BrickadiaColor> Colors;
	}

	public class ColorPalette {
		public List<List<BrickadiaColor>> Colors = new List<List<BrickadiaColor>>();

		public ColorPalette(PresetColorPaletteEntry paletteEntry) {
			foreach (PresetColorPaletteGroup group in paletteEntry.Data.Groups) {
				List<BrickadiaColor> buffer = new List<BrickadiaColor>();
				foreach (BrickadiaColor color in group.Colors) buffer.Add(color.ToSrgb());
				Colors.Add(buffer);
			}
		}

		public BrickadiaColor ClosestColor(BrickadiaColor color, ColorSpaceSetting colorSpace) {
			BrickadiaColor nearColor = default;
			double colorDistance = double.MaxValue;

			for (int x = 0; x < Colors.Count; x++) {
				for (int y = 0; y < Colors[x].Count; y++) {
					BrickadiaColor bColor = Colors[x][y];
					double distance = double.MaxValue;
					
					switch (colorSpace) {
						case ColorSpaceSetting.sRGB:
							distance = color.DistanceSrgb(bColor);
							break;
						case ColorSpaceSetting.Oklab:
							distance = color.DistanceOklab(bColor);
							break;
					}

					if (distance < colorDistance) {
						nearColor = bColor;
						colorDistance = distance;
					}
				}
			}

			return nearColor;
		}

		public (int, int, double) ClosestColorPalettePositionWithDistance(BrickadiaColor color, ColorSpaceSetting colorSpace) {
			int x = -1;
			int y = -1;
			double colorDistance = double.MaxValue;

			for (int colx = 0; colx < Colors.Count; colx++) {
				for (int coly = 0; coly < Colors[colx].Count; coly++) {
					BrickadiaColor bColor = Colors[colx][coly];
					double distance = double.MaxValue;

					switch (colorSpace) {
						case ColorSpaceSetting.sRGB:
							distance = color.DistanceSrgb(bColor);
							break;
						case ColorSpaceSetting.Oklab:
							distance = color.DistanceOklab(bColor);
							break;
					}

					if (distance < colorDistance) {
						x = colx;
						y = coly;
						colorDistance = distance;
					}
				}
			}

			return (x, y, colorDistance);
		}

		public (int, int) ClosestColorPalettePosition(BrickadiaColor color, ColorSpaceSetting colorSpace) {
			(int x, int y, double _) = ClosestColorPalettePositionWithDistance(color, colorSpace);
			return (x, y);
		}

		public Bitmap CreateHeatmap(Dictionary<(int, int), int> heatmap) {
			int w = Colors.Count;
			int h = Colors.Select(c => c.Count).Max();
			int ppc = 20;
			int maxFreq = heatmap.ToList().Select(kvp => kvp.Value).Max();
			Bitmap bitmap = new Bitmap(w * ppc, h * ppc);
			using Graphics graphics = Graphics.FromImage(bitmap);

			for (int col = 0; col < Colors.Count; col++) {
				for (int i = 0; i < Colors[col].Count; i++) {
					(int, int) tuple = (col, i);
					int frequency = heatmap.ContainsKey(tuple) ? heatmap[tuple] : 0;

					Color color = Colors[col][i].ToColor();
					using Brush backBrush = new SolidBrush(Color.FromArgb(64, color.R, color.G, color.B));
					graphics.FillRectangle(backBrush, new Rectangle(col * ppc, i * ppc, ppc, ppc));

					if (frequency > 0) {
						Debug.WriteLine($"{frequency}, max: {maxFreq}");
						int size = (int)Math.Round(frequency / (double)maxFreq * ppc);
						using Brush brush = new SolidBrush(Colors[col][i].ToColor());
						graphics.FillRectangle(brush, new Rectangle(col * ppc + ppc / 2 - size / 2, i * ppc + ppc / 2 - size / 2, size, size));
					}
				}
			}

			return bitmap;
		}
	}
}
