using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BrickadiaAutoPainter {
	struct BrickadiaColor {
		public static double ChannelToSrgb(double channel) =>
			channel > 0.0031308 ? 1.055 * Math.Pow(channel, 1 / 2.4) - 0.055 : 12.92 * channel;

		public static (double, double, double) FractionalColor(BrickadiaColor color) =>
			(color.Red / 255d, color.Green / 255d, color.Blue / 255d);

		public static double ColorDistance(BrickadiaColor a, BrickadiaColor b) {
			var (aa, ab, ac) = FractionalColor(a);
			var (ba, bb, bc) = FractionalColor(b);
			var adiff = ba - aa;
			var bdiff = bb - ab;
			var cdiff = bc - ac;
			return Math.Sqrt(adiff * adiff + bdiff * bdiff + cdiff * cdiff);
		}

		//

		[JsonProperty("r")]
		public byte Red;

		[JsonProperty("g")]
		public byte Green;

		[JsonProperty("b")]
		public byte Blue;

		public BrickadiaColor(byte r, byte g, byte b) {
			Red = r;
			Green = g;
			Blue = b;
		}

		public BrickadiaColor(Color color) {
			Red = color.R;
			Green = color.G;
			Blue = color.B;
		}

		public BrickadiaColor ToSrgb() {
			return new BrickadiaColor(
				(byte)Math.Round(ChannelToSrgb(Red / 255d) * 255),
				(byte)Math.Round(ChannelToSrgb(Green / 255d) * 255),
				(byte)Math.Round(ChannelToSrgb(Blue / 255d) * 255)
			);
		}

		public int ToInt() {
			int color = Red;
			color = color << 8 + Green;
			color = color << 8 + Blue;
			return color;
		}

		public Color ToColor() {
			return Color.FromArgb(Red, Green, Blue);
		}
	}
}
