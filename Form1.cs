using Newtonsoft.Json;
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

		public Form1() {
			InitializeComponent();

			advancedSettingsForm = new AdvancedSettingsForm();
		}

		private Robot createRobot() {
			PresetColorPaletteEntry entry = JsonConvert.DeserializeObject<PresetColorPaletteEntry>(File.ReadAllText(colorPaletteFile.FileName));

			return new Robot {
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

			using Robot robot = createRobot();
			WindowState = FormWindowState.Minimized;
			Thread.Sleep(2000);
			robot.Paint();
			Thread.Sleep(500);
			WindowState = FormWindowState.Normal;
		}

		private void advancedSettingsButton_Click(object sender, EventArgs e) {
			advancedSettingsForm.ShowDialog();
		}
	}
}
