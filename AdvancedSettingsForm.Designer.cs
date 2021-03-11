
namespace BrickadiaAutoPainter {
	partial class AdvancedSettingsForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.boxColorSwitchDelay = new System.Windows.Forms.NumericUpDown();
			this.boxColorSwitchedDelay = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.boxPixelPaintDelay = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.dropdownColorSpace = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.boxColorSwitchDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.boxColorSwitchedDelay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.boxPixelPaintDelay)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Color switch delay (ms)";
			// 
			// boxColorSwitchDelay
			// 
			this.boxColorSwitchDelay.Location = new System.Drawing.Point(170, 11);
			this.boxColorSwitchDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.boxColorSwitchDelay.Name = "boxColorSwitchDelay";
			this.boxColorSwitchDelay.Size = new System.Drawing.Size(70, 23);
			this.boxColorSwitchDelay.TabIndex = 1;
			this.boxColorSwitchDelay.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			// 
			// boxColorSwitchedDelay
			// 
			this.boxColorSwitchedDelay.Location = new System.Drawing.Point(170, 40);
			this.boxColorSwitchedDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.boxColorSwitchedDelay.Name = "boxColorSwitchedDelay";
			this.boxColorSwitchedDelay.Size = new System.Drawing.Size(70, 23);
			this.boxColorSwitchedDelay.TabIndex = 3;
			this.boxColorSwitchedDelay.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Color switched delay (ms)";
			// 
			// boxPixelPaintDelay
			// 
			this.boxPixelPaintDelay.Location = new System.Drawing.Point(170, 69);
			this.boxPixelPaintDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.boxPixelPaintDelay.Name = "boxPixelPaintDelay";
			this.boxPixelPaintDelay.Size = new System.Drawing.Size(70, 23);
			this.boxPixelPaintDelay.TabIndex = 5;
			this.boxPixelPaintDelay.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Pixel paint delay (ms)";
			// 
			// dropdownColorSpace
			// 
			this.dropdownColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dropdownColorSpace.FormattingEnabled = true;
			this.dropdownColorSpace.Items.AddRange(new object[] {
            "sRGB",
            "Oklab"});
			this.dropdownColorSpace.Location = new System.Drawing.Point(170, 98);
			this.dropdownColorSpace.Name = "dropdownColorSpace";
			this.dropdownColorSpace.Size = new System.Drawing.Size(121, 23);
			this.dropdownColorSpace.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 15);
			this.label4.TabIndex = 7;
			this.label4.Text = "Color space";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.Location = new System.Drawing.Point(122, 164);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 8;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// AdvancedSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(306, 199);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.dropdownColorSpace);
			this.Controls.Add(this.boxPixelPaintDelay);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.boxColorSwitchedDelay);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.boxColorSwitchDelay);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "AdvancedSettingsForm";
			this.Text = "Auto Paint Advanced Settings";
			this.Load += new System.EventHandler(this.AdvancedSettingsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.boxColorSwitchDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.boxColorSwitchedDelay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.boxPixelPaintDelay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown boxColorSwitchDelay;
		private System.Windows.Forms.NumericUpDown boxColorSwitchedDelay;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown boxPixelPaintDelay;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown boxPixelPa;
		private System.Windows.Forms.NumericUpDown intDelay;
		private System.Windows.Forms.NumericUpDown boxPixe;
		private System.Windows.Forms.NumericUpDown boxPixel;
		private System.Windows.Forms.ComboBox dropdownColorSpace;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button okButton;
	}
}