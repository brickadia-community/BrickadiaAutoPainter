using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BrickadiaAutoPainter {
	class PresetColorPaletteEntry {
		[JsonProperty("data")]
		public PresetColorPalette Data;
	}

	class PresetColorPalette {
		[JsonProperty("groups")]
		public List<PresetColorPaletteGroup> Groups;
	}

	class PresetColorPaletteGroup {
		[JsonProperty("colors")]
		public List<BrickadiaColor> Colors;
	}

	class ColorPalette {
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

		public (int, int) ClosestColorPalettePosition(BrickadiaColor color, ColorSpaceSetting colorSpace) {
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

			return (x, y);
		}
	}
}
