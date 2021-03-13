using Newtonsoft.Json;
using NHotkey.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BrickadiaAutoPainter.Windows;

namespace BrickadiaAutoPainter {
	public partial class Form1 : Form {
		private bool paletteSet = false;
		private bool imageSet = false;
		private Bitmap previewBitmap = null;

		private (int, int)? topLeftPos;
		private (int, int)? topRightPos;
		private (int, int)? bottomLeftPos;
		private (int, int)? bottomRightPos;

		private AdvancedSettingsForm advancedSettingsForm;
		private Robot paintingRobot;
		private delegate void SafeSetPaintProgress(int value);
		private delegate void SafeSetWindowState(FormWindowState state);

		public Form1() {
			InitializeComponent();

			advancedSettingsForm = new AdvancedSettingsForm();
			registerHotkeys();
		}

		private void registerHotkeys() {
			HotkeyManager.Current.AddOrReplace("Stop", Keys.Escape, (sender, e) => {
				if (paintingRobot != null) {
					paintingRobot.Stop = true;
					paintingRobot.Active = false;
					paintingRobot.SetPaintProgress();
				}

				e.Handled = true;
			});

			HotkeyManager.Current.AddOrReplace("Pause", Keys.F4, (sender, e) => {
				if (paintingRobot != null) {
					if (paintingRobot.Paused) {
						// resume
						paintingRobot.Paused = false;
						if (paintingRobot.PairIndex != 0) paintingRobot.PairIndex--;
						if (paintingRobot.PairPixelIndex != 0) paintingRobot.PairPixelIndex--;
						new Thread(paintingRobot.PaintFromState).Start();
					} else {
						// pause
						paintingRobot.Paused = true;
						paintingRobot.SetPaintProgress();
					}
				}

				e.Handled = true;
			});
		}

		private void setPaintProgressSafe(int value) {
			if (paintProgress.InvokeRequired)
				paintProgress.Invoke(new SafeSetPaintProgress(setPaintProgressSafe), new object[] { value });
			else
				paintProgress.Value = value;
		}

		public void SetWindowState(FormWindowState state) {
			if (InvokeRequired)
				Invoke(new SafeSetWindowState(SetWindowState), new object[] { state });
			else
				WindowState = state;
		}

		public void SetPaintProgress(double value) {
			setPaintProgressSafe((int)Math.Round(value * 100));
		}

		private Robot createRobot() {
			PresetColorPaletteEntry entry = JsonConvert.DeserializeObject<PresetColorPaletteEntry>(File.ReadAllText(colorPaletteFile.FileName));

			return new Robot {
				Form = this,

				ColorChangeDelay = advancedSettingsForm.ColorSwitchDelay,
				ColorPlaceDelay = advancedSettingsForm.PixelPaintDelay,
				AfterColorPickDelay = advancedSettingsForm.ColorSwitchedDelay,
				ColorSpace = advancedSettingsForm.ColorSpace,
				SkipColors = advancedSettingsForm.SkipColors,

				Width = (int)numBricksX.Value,
				Height = (int)numBricksY.Value,
				Image = new Bitmap(imageFile.FileName),
				Palette = new ColorPalette(entry),
				Window = Program.GetBrickadiaIntPtr(),
				TopLeft = topLeftPos,
				TopRight = topRightPos,
				BottomLeft = bottomLeftPos,
				BottomRight = bottomRightPos
			};
		}

		private (int, int) captureCursorPos() {
			WindowState = FormWindowState.Minimized;
			Thread.Sleep(5000);
			Point pos = Cursor.Position;
			WindowState = FormWindowState.Normal;
			return (pos.X, pos.Y);
		}

		private void colorPaletteBrowse_Click(object sender, EventArgs e) {
			DialogResult result = colorPaletteFile.ShowDialog();
			if (result == DialogResult.OK) {
				string fileName = Path.GetFileName(colorPaletteFile.FileName);
				colorPaletteName.ForeColor = SystemColors.ControlText;
				colorPaletteName.Text = fileName;
				paletteSet = true;
			}
		}

		private void imageBrowse_Click(object sender, EventArgs e) {
			DialogResult result = imageFile.ShowDialog();
			if (result == DialogResult.OK) {
				string fileName = Path.GetFileName(imageFile.FileName);
				imageName.ForeColor = SystemColors.ControlText;
				imageName.Text = fileName;
				imageSet = true;
			}
		}

		private void previewButton_Click(object sender, EventArgs e) {
			if (!paletteSet || !imageSet) return;
			if (previewBitmap != null) previewBitmap.Dispose();

			using Robot robot = createRobot();
			previewBitmap = robot.GeneratePreview();
			previewImageBox.Image = previewBitmap;
		}

		private void captureTopLeft_Click(object sender, EventArgs e) {
			(int, int) pos = captureCursorPos();
			topLeftPos = pos;
			captureTopLeftLabel.ForeColor = SystemColors.ControlText;
			captureTopLeftLabel.Text = $"({pos.Item1}, {pos.Item2})";
		}

		private void captureTopRight_Click(object sender, EventArgs e) {
			(int, int) pos = captureCursorPos();
			topRightPos = pos;
			captureTopRightLabel.ForeColor = SystemColors.ControlText;
			captureTopRightLabel.Text = $"({pos.Item1}, {pos.Item2})";
		}

		private void captureBottomLeft_Click(object sender, EventArgs e) {
			(int, int) pos = captureCursorPos();
			bottomLeftPos = pos;
			captureBottomLeftLabel.ForeColor = SystemColors.ControlText;
			captureBottomLeftLabel.Text = $"({pos.Item1}, {pos.Item2})";
		}

		private void captureBottomRight_Click(object sender, EventArgs e) {
			(int, int) pos = captureCursorPos();
			bottomRightPos = pos;
			captureBottomRightLabel.ForeColor = SystemColors.ControlText;
			captureBottomRightLabel.Text = $"({pos.Item1}, {pos.Item2})";
		}

		private void paintButton_Click(object sender, EventArgs e) {
			if (!paletteSet || !imageSet) return;
			if (!topLeftPos.HasValue || !topRightPos.HasValue || !bottomLeftPos.HasValue || !bottomRightPos.HasValue) return;
			if (paintingRobot != null) {
				if (paintingRobot.Active)
					return;

				paintingRobot.Dispose();
			}

			paintingRobot = createRobot();
			WindowState = FormWindowState.Minimized;
			Thread.Sleep(2000);
			paintingRobot.Paint();
		}

		private void advancedSettingsButton_Click(object sender, EventArgs e) {
			advancedSettingsForm.ShowDialog();
		}

		private void checkGridAlignment(object sender, EventArgs e) {
			if (!topLeftPos.HasValue || !topRightPos.HasValue || !bottomLeftPos.HasValue || !bottomRightPos.HasValue) return;

			int[] xs = new int[] { topLeftPos.Value.Item1, topRightPos.Value.Item1, bottomLeftPos.Value.Item1, bottomRightPos.Value.Item1 };
			int[] ys = new int[] { topLeftPos.Value.Item2, topRightPos.Value.Item2, bottomLeftPos.Value.Item2, bottomRightPos.Value.Item2 };

			int minX = Enumerable.Min(xs);
			int minY = Enumerable.Min(ys);

			int maxX = Enumerable.Max(xs);
			int maxY = Enumerable.Max(ys);

			int padding = 40; // padding to surround the cropped image with

			Rectangle cropping = new Rectangle(minX - padding, minY - padding, maxX - minX + padding * 2, maxY - minY + padding * 2);
			Rectangle screenBounds = Screen.FromHandle(Program.GetBrickadiaIntPtr()).Bounds;
			cropping.Intersect(screenBounds);

			// take a screenshot AFTER minimizing the window
			WindowState = FormWindowState.Minimized;
			Thread.Sleep(500);
			using Bitmap gameShot = ScreenCapture.CaptureWindow(Program.GetBrickadiaIntPtr());
			WindowState = FormWindowState.Normal;

			// add the grid
			using Graphics graphics = Graphics.FromImage(gameShot);
			using SolidBrush gridMarkerBrush = new SolidBrush(Color.Gray);
			using SolidBrush cornerMarkerBrush = new SolidBrush(Color.Blue);

			Action<Brush, int, int, int> drawPoint = (brush, x, y, r) => {
				int rx = Math.Max(0, Math.Min(screenBounds.Width - r, x));
				int ry = Math.Max(0, Math.Min(screenBounds.Height - r, y));
				graphics.FillRectangle(brush, new Rectangle(rx - r, ry - r, r * 2, r * 2));
			};

			Perspective perspective = new Perspective(topLeftPos.Value, topRightPos.Value, bottomLeftPos.Value, bottomRightPos.Value);
			int w = (int)numBricksX.Value;
			int h = (int)numBricksY.Value;
			for (int y = 0; y < w; y++) {
				for (int x = 0; x < h; x++) {
					double tx = x / (double)(w - 1);
					double ty = y / (double)(h - 1);

					(int, int) point = perspective.PointOn(tx, ty);
					drawPoint(gridMarkerBrush, point.Item1, point.Item2, 2);
				}
			}

			// and the corners
			for (int i = 0; i < 4; i++)
				drawPoint(cornerMarkerBrush, xs[i], ys[i], 5);

			// finally crop the image
			using Bitmap croppedGameShot = ScreenCapture.CropBitmap(gameShot, cropping);

			// open the alignment form
			GridAlignmentForm alignmentForm = new GridAlignmentForm();
			alignmentForm.PictureBox.Image = croppedGameShot;
			alignmentForm.ShowDialog();
		}
	}
}
