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

	public partial class AdvancedSettingsForm : Form {
		public int ColorSwitchDelay => (int)boxColorSwitchDelay.Value;
		public int ColorSwitchedDelay => (int)boxColorSwitchedDelay.Value;
		public int PixelPaintDelay => (int)boxPixelPaintDelay.Value;
		public ColorSpaceSetting ColorSpace => (ColorSpaceSetting)Enum.Parse(typeof(ColorSpaceSetting), dropdownColorSpace.Text);

		public AdvancedSettingsForm() {
			InitializeComponent();
			dropdownColorSpace.SelectedIndex = 0;
		}

		private void AdvancedSettingsForm_Load(object sender, EventArgs e) {
		}

		private void okButton_Click(object sender, EventArgs e) {
			Hide();
		}
	}
}
