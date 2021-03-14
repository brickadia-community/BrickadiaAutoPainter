using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BrickadiaAutoPainter {
	public struct BrickadiaColor {
		public static double ChannelToSrgb(double channel) =>
			channel > 0.0031308 ? 1.055 * Math.Pow(channel, 1 / 2.4) - 0.055 : 12.92 * channel;

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

		public double DistanceSrgb(BrickadiaColor other) {
			var (aa, ab, ac) = Fractional();
			var (ba, bb, bc) = other.Fractional();
			var adiff = ba - aa;
			var bdiff = bb - ab;
			var cdiff = bc - ac;
			return Math.Sqrt(adiff * adiff + bdiff * bdiff + cdiff * cdiff);
		}

		public double DistanceOklab(BrickadiaColor other) {
			var (aa, ab, ac) = ToOklab();
			var (ba, bb, bc) = other.ToOklab();
			var adiff = ba - aa;
			var bdiff = bb - ab;
			var cdiff = bc - ac;
			return Math.Sqrt(adiff * adiff + bdiff * bdiff + cdiff * cdiff);
		}

		public (double, double, double) Fractional()
			=> (Red / 255d, Green / 255d, Blue / 255d);

		public (double, double, double) ToOklab() {
			var (r, g, b) = Fractional();
			double l = 0.4122214708d * r + 0.5363325363d * g + 0.0514459929d * b;
			double m = 0.2119034982d * r + 0.6806995451d * g + 0.1073969566d * b;
			double s = 0.0883024619d * r + 0.2817188376d * g + 0.6299787005d * b;

			double l_ = Math.Cbrt(l);
			double m_ = Math.Cbrt(m);
			double s_ = Math.Cbrt(s);

			return (
				0.2104542553d * l_ + 0.7936177850d * m_ - 0.0040720468d * s_,
				1.9779984951d * l_ - 2.4285922050d * m_ + 0.4505937099d * s_,
				0.0259040371d * l_ + 0.7827717662d * m_ - 0.8086757660d * s_
			);
		}
	}
}
