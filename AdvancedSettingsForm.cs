using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BrickadiaAutoPainter {
	public enum ColorSpaceSetting {
		sRGB,
		Oklab
	}

	public enum SkipColorsSetting {
		None,
		MostFrequent,
		Transparent
	}

	public partial class AdvancedSettingsForm : Form {
		public int ColorSwitchDelay => (int)boxColorSwitchDelay.Value;
		public int ColorSwitchedDelay => (int)boxColorSwitchedDelay.Value;
		public int PixelPaintDelay => (int)boxPixelPaintDelay.Value;
		public ColorSpaceSetting ColorSpace => (ColorSpaceSetting)Enum.Parse(typeof(ColorSpaceSetting), dropdownColorSpace.Text);
		public SkipColorsSetting SkipColors => (SkipColorsSetting)Enum.GetValues(typeof(SkipColorsSetting)).GetValue(dropdownSkipColors.SelectedIndex);

		public AdvancedSettingsForm() {
			InitializeComponent();
			dropdownColorSpace.SelectedIndex = 0;
			dropdownSkipColors.SelectedIndex = 0;
		}

		private void AdvancedSettingsForm_Load(object sender, EventArgs e) {
		}

		private void okButton_Click(object sender, EventArgs e) {
			Hide();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

		}
	}
}
