using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BrickadiaAutoPainter {
	public partial class PostPaintForm : Form {
		public PostPaintForm() {
			InitializeComponent();
		}

		private string formatSpan(TimeSpan span) {
			if (span.TotalHours > 1) {
				return string.Format("{0}h{1}m{2}s", Math.Floor(span.TotalHours), span.Minutes, span.Seconds);
			} else {
				return string.Format("{0}m{1}s", Math.Floor(span.TotalMinutes), span.Seconds);
			}
		}


		private void setPercentAndColor(Label label, double percent) {
			label.Text = string.Format("{0:0.##}%", percent * 100);

			if (percent >= 0.8)
				label.ForeColor = Color.Green;
			else if (percent <= 0.3)
				label.ForeColor = Color.Red;
		}

		public void SetFromRobot(Robot robot) {
			TimeSpan paintTime = robot.EndTime.Value - robot.StartTime.Value;
			labelTimeToComplete.Text = formatSpan(paintTime);

			var colorAccuracyList = robot.ColorAccuracy.ToList();
			var colorAccuracies = colorAccuracyList.Select((kvp) => kvp.Value);
			setPercentAndColor(labelAverageColorAccuracy, colorAccuracies.Average());
			setPercentAndColor(labelWorstColorAccuracy, colorAccuracies.Min());
			setPercentAndColor(labelBestColorAccuracy, colorAccuracies.Max());

			labelNumberColors.Text = robot.PalettePixelPairs.Count.ToString();
			labelFrequentColorPixelCount.Text = robot.PalettePixelPairs.Select((kvp) => kvp.Value.Count).Max().ToString();

			// display the color palette
			Bitmap heatmapBitmap = robot.Palette.CreateHeatmap(robot.PalettePixelPairs.ToDictionary(p => p.Key, p => p.Value.Count));
			picturePaletteHeatmap.Image = heatmapBitmap;

			// screenshot and display the painting, after moving mouse to corner of screen
			Rectangle screenBounds = Screen.FromHandle(Program.GetBrickadiaIntPtr()).Bounds;
			Windows.SetCursorPos(screenBounds.Width - 1, screenBounds.Height - 1);
			Thread.Sleep(500);

			using Bitmap gameShot = ScreenCapture.CaptureWindow(Program.GetBrickadiaIntPtr());
			int[] xs = new int[] { robot.TopLeft.Value.Item1, robot.TopRight.Value.Item1, robot.BottomLeft.Value.Item1, robot.BottomRight.Value.Item1 };
			int[] ys = new int[] { robot.TopLeft.Value.Item2, robot.TopRight.Value.Item2, robot.BottomLeft.Value.Item2, robot.BottomRight.Value.Item2 };
			int minX = xs.Min();
			int maxX = xs.Max();
			int minY = ys.Min();
			int maxY = ys.Max();

			int padding = 80;
			Rectangle cropping = new Rectangle(minX - padding, minY - padding, maxX - minX + padding * 2, maxY - minY + padding * 2);
			cropping.Intersect(screenBounds);

			Bitmap croppedShot = ScreenCapture.CropBitmap(gameShot, cropping);
			picturePainting.Image = croppedShot;

			TopMost = true;
			Activate();
			WindowState = FormWindowState.Normal;
		}
	}
}
