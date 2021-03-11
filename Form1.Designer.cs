
namespace BrickadiaAutoPainter {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.colorPaletteFile = new System.Windows.Forms.OpenFileDialog();
			this.colorPaletteBrowse = new System.Windows.Forms.Button();
			this.colorPaletteName = new System.Windows.Forms.Label();
			this.imageName = new System.Windows.Forms.Label();
			this.imageBrowse = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.previewImageBox = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numBricksX = new System.Windows.Forms.NumericUpDown();
			this.numBricksY = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.captureTopLeft = new System.Windows.Forms.Button();
			this.captureTopLeftLabel = new System.Windows.Forms.Label();
			this.captureTopRightLabel = new System.Windows.Forms.Label();
			this.captureTopRight = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.captureBottomLeftLabel = new System.Windows.Forms.Label();
			this.captureBottomLeft = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.captureBottomRightLabel = new System.Windows.Forms.Label();
			this.captureBottomRight = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.paintButton = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.imageFile = new System.Windows.Forms.OpenFileDialog();
			this.previewButton = new System.Windows.Forms.Button();
			this.advancedSettingsButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBricksX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numBricksY)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(178, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "1. Import the server color palette";
			// 
			// colorPaletteFile
			// 
			this.colorPaletteFile.DefaultExt = "bp";
			this.colorPaletteFile.FileName = "openFileDialog1";
			this.colorPaletteFile.Filter = "Brickadia Preset (*.bp)|*.bp|All files (*.*)|*.*";
			this.colorPaletteFile.Title = "Server color palette";
			// 
			// colorPaletteBrowse
			// 
			this.colorPaletteBrowse.Location = new System.Drawing.Point(13, 28);
			this.colorPaletteBrowse.Name = "colorPaletteBrowse";
			this.colorPaletteBrowse.Size = new System.Drawing.Size(75, 23);
			this.colorPaletteBrowse.TabIndex = 1;
			this.colorPaletteBrowse.Text = "Open...";
			this.colorPaletteBrowse.UseVisualStyleBackColor = true;
			this.colorPaletteBrowse.Click += new System.EventHandler(this.colorPaletteBrowse_Click);
			// 
			// colorPaletteName
			// 
			this.colorPaletteName.AutoSize = true;
			this.colorPaletteName.ForeColor = System.Drawing.Color.Brown;
			this.colorPaletteName.Location = new System.Drawing.Point(94, 32);
			this.colorPaletteName.Name = "colorPaletteName";
			this.colorPaletteName.Size = new System.Drawing.Size(82, 15);
			this.colorPaletteName.TabIndex = 2;
			this.colorPaletteName.Text = "None selected";
			// 
			// imageName
			// 
			this.imageName.AutoSize = true;
			this.imageName.ForeColor = System.Drawing.Color.Brown;
			this.imageName.Location = new System.Drawing.Point(94, 91);
			this.imageName.Name = "imageName";
			this.imageName.Size = new System.Drawing.Size(82, 15);
			this.imageName.TabIndex = 5;
			this.imageName.Text = "None selected";
			// 
			// imageBrowse
			// 
			this.imageBrowse.Location = new System.Drawing.Point(12, 87);
			this.imageBrowse.Name = "imageBrowse";
			this.imageBrowse.Size = new System.Drawing.Size(75, 23);
			this.imageBrowse.TabIndex = 4;
			this.imageBrowse.Text = "Open...";
			this.imageBrowse.UseVisualStyleBackColor = true;
			this.imageBrowse.Click += new System.EventHandler(this.imageBrowse_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 69);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "2. Open an image";
			// 
			// previewImageBox
			// 
			this.previewImageBox.Location = new System.Drawing.Point(488, 28);
			this.previewImageBox.Name = "previewImageBox";
			this.previewImageBox.Size = new System.Drawing.Size(300, 300);
			this.previewImageBox.TabIndex = 6;
			this.previewImageBox.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(488, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "Image preview";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(232, 15);
			this.label4.TabIndex = 8;
			this.label4.Text = "3. Specify number of bricks for dimensions";
			// 
			// numBricksX
			// 
			this.numBricksX.Location = new System.Drawing.Point(12, 147);
			this.numBricksX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numBricksX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numBricksX.Name = "numBricksX";
			this.numBricksX.Size = new System.Drawing.Size(59, 23);
			this.numBricksX.TabIndex = 9;
			this.numBricksX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// numBricksY
			// 
			this.numBricksY.Location = new System.Drawing.Point(104, 147);
			this.numBricksY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numBricksY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numBricksY.Name = "numBricksY";
			this.numBricksY.Size = new System.Drawing.Size(59, 23);
			this.numBricksY.TabIndex = 10;
			this.numBricksY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(77, 149);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(20, 15);
			this.label5.TabIndex = 11;
			this.label5.Text = "by";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(13, 186);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(231, 47);
			this.label6.TabIndex = 12;
			this.label6.Text = "4. Align yourself looking at your target paint spot as straight on as possible an" +
    "d enter free cursor mode (default N)";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 250);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(232, 78);
			this.label7.TabIndex = 13;
			this.label7.Text = "5. Mark off the four corners of your desired paint location with a different colo" +
    "r. Check that they make a rectangle the same size as the dimensions you provided" +
    " in step 3";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(256, 9);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(217, 38);
			this.label8.TabIndex = 14;
			this.label8.Text = "6. Select the coordinates on your screen of each corner (center of the brick)";
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label9.Location = new System.Drawing.Point(256, 47);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(217, 83);
			this.label9.TabIndex = 0;
			this.label9.Text = "Click the Capture button and place your cursor over the center of the correspondi" +
    "ng corner. Your cursor position will be captured after 5 seconds.";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(256, 131);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(46, 15);
			this.label10.TabIndex = 15;
			this.label10.Text = "Top left";
			// 
			// captureTopLeft
			// 
			this.captureTopLeft.Location = new System.Drawing.Point(256, 149);
			this.captureTopLeft.Name = "captureTopLeft";
			this.captureTopLeft.Size = new System.Drawing.Size(75, 23);
			this.captureTopLeft.TabIndex = 16;
			this.captureTopLeft.Text = "Capture...";
			this.captureTopLeft.UseVisualStyleBackColor = true;
			this.captureTopLeft.Click += new System.EventHandler(this.captureTopLeft_Click);
			// 
			// captureTopLeftLabel
			// 
			this.captureTopLeftLabel.AutoSize = true;
			this.captureTopLeftLabel.ForeColor = System.Drawing.Color.Brown;
			this.captureTopLeftLabel.Location = new System.Drawing.Point(337, 153);
			this.captureTopLeftLabel.Name = "captureTopLeftLabel";
			this.captureTopLeftLabel.Size = new System.Drawing.Size(77, 15);
			this.captureTopLeftLabel.TabIndex = 17;
			this.captureTopLeftLabel.Text = "Not captured";
			// 
			// captureTopRightLabel
			// 
			this.captureTopRightLabel.AutoSize = true;
			this.captureTopRightLabel.ForeColor = System.Drawing.Color.Brown;
			this.captureTopRightLabel.Location = new System.Drawing.Point(337, 202);
			this.captureTopRightLabel.Name = "captureTopRightLabel";
			this.captureTopRightLabel.Size = new System.Drawing.Size(77, 15);
			this.captureTopRightLabel.TabIndex = 20;
			this.captureTopRightLabel.Text = "Not captured";
			// 
			// captureTopRight
			// 
			this.captureTopRight.Location = new System.Drawing.Point(256, 198);
			this.captureTopRight.Name = "captureTopRight";
			this.captureTopRight.Size = new System.Drawing.Size(75, 23);
			this.captureTopRight.TabIndex = 19;
			this.captureTopRight.Text = "Capture...";
			this.captureTopRight.UseVisualStyleBackColor = true;
			this.captureTopRight.Click += new System.EventHandler(this.captureTopRight_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(256, 180);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(54, 15);
			this.label12.TabIndex = 18;
			this.label12.Text = "Top right";
			// 
			// captureBottomLeftLabel
			// 
			this.captureBottomLeftLabel.AutoSize = true;
			this.captureBottomLeftLabel.ForeColor = System.Drawing.Color.Brown;
			this.captureBottomLeftLabel.Location = new System.Drawing.Point(337, 250);
			this.captureBottomLeftLabel.Name = "captureBottomLeftLabel";
			this.captureBottomLeftLabel.Size = new System.Drawing.Size(77, 15);
			this.captureBottomLeftLabel.TabIndex = 23;
			this.captureBottomLeftLabel.Text = "Not captured";
			// 
			// captureBottomLeft
			// 
			this.captureBottomLeft.Location = new System.Drawing.Point(256, 246);
			this.captureBottomLeft.Name = "captureBottomLeft";
			this.captureBottomLeft.Size = new System.Drawing.Size(75, 23);
			this.captureBottomLeft.TabIndex = 22;
			this.captureBottomLeft.Text = "Capture...";
			this.captureBottomLeft.UseVisualStyleBackColor = true;
			this.captureBottomLeft.Click += new System.EventHandler(this.captureBottomLeft_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(256, 228);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(67, 15);
			this.label13.TabIndex = 21;
			this.label13.Text = "Bottom left";
			// 
			// captureBottomRightLabel
			// 
			this.captureBottomRightLabel.AutoSize = true;
			this.captureBottomRightLabel.ForeColor = System.Drawing.Color.Brown;
			this.captureBottomRightLabel.Location = new System.Drawing.Point(337, 298);
			this.captureBottomRightLabel.Name = "captureBottomRightLabel";
			this.captureBottomRightLabel.Size = new System.Drawing.Size(77, 15);
			this.captureBottomRightLabel.TabIndex = 26;
			this.captureBottomRightLabel.Text = "Not captured";
			// 
			// captureBottomRight
			// 
			this.captureBottomRight.Location = new System.Drawing.Point(256, 294);
			this.captureBottomRight.Name = "captureBottomRight";
			this.captureBottomRight.Size = new System.Drawing.Size(75, 23);
			this.captureBottomRight.TabIndex = 25;
			this.captureBottomRight.Text = "Capture...";
			this.captureBottomRight.UseVisualStyleBackColor = true;
			this.captureBottomRight.Click += new System.EventHandler(this.captureBottomRight_Click);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(256, 276);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(75, 15);
			this.label14.TabIndex = 24;
			this.label14.Text = "Bottom right";
			// 
			// paintButton
			// 
			this.paintButton.Location = new System.Drawing.Point(713, 387);
			this.paintButton.Name = "paintButton";
			this.paintButton.Size = new System.Drawing.Size(75, 23);
			this.paintButton.TabIndex = 27;
			this.paintButton.Text = "Paint";
			this.paintButton.UseVisualStyleBackColor = true;
			this.paintButton.Click += new System.EventHandler(this.paintButton_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(13, 395);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(563, 15);
			this.label11.TabIndex = 28;
			this.label11.Text = "When you have completed all steps, click the paint button in the bottom right. Th" +
    "e window will minimize.";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(13, 337);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(231, 48);
			this.label15.TabIndex = 29;
			this.label15.Text = "6. Open the paint tool, putting the selected color to the first one, then press F" +
    "3 to hide UI";
			// 
			// imageFile
			// 
			this.imageFile.DefaultExt = "jpg";
			this.imageFile.FileName = "openFileDialog1";
			this.imageFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
			this.imageFile.Title = "Server color palette";
			// 
			// previewButton
			// 
			this.previewButton.Location = new System.Drawing.Point(632, 387);
			this.previewButton.Name = "previewButton";
			this.previewButton.Size = new System.Drawing.Size(75, 23);
			this.previewButton.TabIndex = 30;
			this.previewButton.Text = "Preview";
			this.previewButton.UseVisualStyleBackColor = true;
			this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
			// 
			// advancedSettingsButton
			// 
			this.advancedSettingsButton.Location = new System.Drawing.Point(632, 358);
			this.advancedSettingsButton.Name = "advancedSettingsButton";
			this.advancedSettingsButton.Size = new System.Drawing.Size(156, 23);
			this.advancedSettingsButton.TabIndex = 31;
			this.advancedSettingsButton.Text = "Open advanced settings";
			this.advancedSettingsButton.UseVisualStyleBackColor = true;
			this.advancedSettingsButton.Click += new System.EventHandler(this.advancedSettingsButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(800, 421);
			this.Controls.Add(this.advancedSettingsButton);
			this.Controls.Add(this.previewButton);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.paintButton);
			this.Controls.Add(this.captureBottomRightLabel);
			this.Controls.Add(this.captureBottomRight);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.captureBottomLeftLabel);
			this.Controls.Add(this.captureBottomLeft);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.captureTopRightLabel);
			this.Controls.Add(this.captureTopRight);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.captureTopLeftLabel);
			this.Controls.Add(this.captureTopLeft);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.numBricksY);
			this.Controls.Add(this.numBricksX);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.previewImageBox);
			this.Controls.Add(this.imageName);
			this.Controls.Add(this.imageBrowse);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.colorPaletteName);
			this.Controls.Add(this.colorPaletteBrowse);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Brickadia Auto Painter";
			((System.ComponentModel.ISupportInitialize)(this.previewImageBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBricksX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numBricksY)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.OpenFileDialog colorPaletteFile;
		private System.Windows.Forms.Button colorPaletteBrowse;
		private System.Windows.Forms.Label colorPaletteName;
		private System.Windows.Forms.Label imageName;
		private System.Windows.Forms.Button imageBrowse;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox previewImageBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numBricksX;
		private System.Windows.Forms.NumericUpDown numBricksY;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button captureTopLeft;
		private System.Windows.Forms.Label captureTopLeftLabel;
		private System.Windows.Forms.Label captureTopRightLabel;
		private System.Windows.Forms.Button captureTopRight;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button captu;
		private System.Windows.Forms.Button ure;
		private System.Windows.Forms.Label captureBottomLeftLabel;
		private System.Windows.Forms.Button captureBottomLeft;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label captureBottomRightLabel;
		private System.Windows.Forms.Button captureBottomRight;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button paintButton;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.OpenFileDialog imageFile;
		private System.Windows.Forms.Button previewButton;
		private System.Windows.Forms.Button iewButt;
		private System.Windows.Forms.PictureBox Box;
		private System.Windows.Forms.Button advancedSettingsButton;
		private System.Windows.Forms.Button advanced;
	}
}

