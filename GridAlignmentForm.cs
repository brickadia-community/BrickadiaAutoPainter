using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BrickadiaAutoPainter {
	public partial class GridAlignmentForm : Form {
		public PictureBox PictureBox => pictureBox;

		public GridAlignmentForm() {
			InitializeComponent();
		}

		private void okButton_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
