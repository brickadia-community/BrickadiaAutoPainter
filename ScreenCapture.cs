using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace BrickadiaAutoPainter {
	class ScreenCapture {
		public static Bitmap CaptureWindow(IntPtr window) {
			Windows.RECT rect = new Windows.RECT();
			Windows.GetWindowRect(window, ref rect);
			Rectangle rectangle = new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
			
			Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
			using Graphics graphics = Graphics.FromImage(bitmap);
			graphics.CopyFromScreen(new Point(rectangle.Left, rectangle.Top), Point.Empty, rectangle.Size);

			return bitmap;
		}

		public static Bitmap CropBitmap(Bitmap bitmap, Rectangle cropping) {
			return bitmap.Clone(cropping, PixelFormat.Format32bppArgb);
		}
	}
}
