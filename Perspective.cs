using System;
using System.Collections.Generic;
using System.Text;

namespace BrickadiaAutoPainter {
	class Perspective {
		public int[] xs;
		public int[] ys;
		public double[] matrix;
		
		public Perspective((int, int) c00, (int, int) c10, (int, int) c01, (int, int) c11) {
			xs = new int[4] { c00.Item1, c10.Item1, c01.Item1, c11.Item1 };
			ys = new int[4] { c00.Item2, c10.Item2, c01.Item2, c11.Item2 };

			int diffx1 = xs[1] - xs[3];
			int diffy1 = ys[1] - ys[3];
			int diffx2 = xs[2] - xs[3];
			int diffy2 = ys[2] - ys[3];

			int det = diffx1 * diffy2 - diffx2 * diffy1;
			if (det == 0) throw new Exception("Determinant of matrix is zero");

			int sumx = xs[0] - xs[1] + xs[3] - xs[2];
			int sumy = ys[0] - ys[1] + ys[3] - ys[2];

			if (sumx == 0 && sumy == 0) {
				matrix = new double[] {
					xs[1] - xs[0], ys[1] - ys[0], 0,
					xs[3] - xs[1], ys[3] - ys[1], 0,
					xs[0], ys[0], 1d
				};
			} else {
				double oodet = 1d / det;
				double g = (sumx * diffy2 - diffx2 * sumy) * oodet;
				double h = (diffx1 * sumy - sumx * diffy1) * oodet;

				matrix = new double[] {
					xs[1] - xs[0] + g * xs[1], ys[1] - ys[0] + g * ys[1], g,
					xs[2] - xs[0] + h * xs[2], ys[2] - ys[0] + h * ys[2], h,
					xs[0], ys[0], 1d
				};
			}
		}

		public (int, int) PointOn(double x, double y) {
			double xo = matrix[0] * x + matrix[3] * y + matrix[6];
			double yo = matrix[1] * x + matrix[4] * y + matrix[7];
			double w = matrix[2] * x + matrix[5] * y + matrix[8];
			return ((int)Math.Round(xo / w), (int)Math.Round(yo / w));
		}
	}
}
