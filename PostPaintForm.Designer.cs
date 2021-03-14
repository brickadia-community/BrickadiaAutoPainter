
namespace BrickadiaAutoPainter {
	partial class PostPaintForm {
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
			this.labelTimeToComplete = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.picturePaletteHeatmap = new System.Windows.Forms.PictureBox();
			this.labelAverageColorAccuracy = new System.Windows.Forms.Label();
			this.labelWorstColorAccuracy = new System.Windows.Forms.Label();
			this.labelBestColorAccuracy = new System.Windows.Forms.Label();
			this.labelNumberColors = new System.Windows.Forms.Label();
			this.labelFrequentColorPixelCount = new System.Windows.Forms.Label();
			this.picturePainting = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.picturePaletteHeatmap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picturePainting)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(145, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Time to complete";
			// 
			// labelTimeToComplete
			// 
			this.labelTimeToComplete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.labelTimeToComplete.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelTimeToComplete.Location = new System.Drawing.Point(163, 13);
			this.labelTimeToComplete.Name = "labelTimeToComplete";
			this.labelTimeToComplete.Size = new System.Drawing.Size(99, 24);
			this.labelTimeToComplete.TabIndex = 1;
			this.labelTimeToComplete.Text = "0m00s";
			this.labelTimeToComplete.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(145, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Average color accuracy";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(145, 24);
			this.label3.TabIndex = 3;
			this.label3.Text = "Worst color accuracy";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 85);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(145, 24);
			this.label4.TabIndex = 4;
			this.label4.Text = "Best color accuracy";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 109);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(145, 24);
			this.label5.TabIndex = 5;
			this.label5.Text = "Number of colors";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 133);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 24);
			this.label6.TabIndex = 6;
			this.label6.Text = "Highest color pixel count";
			// 
			// picturePaletteHeatmap
			// 
			this.picturePaletteHeatmap.Location = new System.Drawing.Point(13, 161);
			this.picturePaletteHeatmap.Name = "picturePaletteHeatmap";
			this.picturePaletteHeatmap.Size = new System.Drawing.Size(249, 286);
			this.picturePaletteHeatmap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picturePaletteHeatmap.TabIndex = 7;
			this.picturePaletteHeatmap.TabStop = false;
			// 
			// labelAverageColorAccuracy
			// 
			this.labelAverageColorAccuracy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.labelAverageColorAccuracy.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelAverageColorAccuracy.Location = new System.Drawing.Point(163, 37);
			this.labelAverageColorAccuracy.Name = "labelAverageColorAccuracy";
			this.labelAverageColorAccuracy.Size = new System.Drawing.Size(99, 24);
			this.labelAverageColorAccuracy.TabIndex = 8;
			this.labelAverageColorAccuracy.Text = "0%";
			this.labelAverageColorAccuracy.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelWorstColorAccuracy
			// 
			this.labelWorstColorAccuracy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.labelWorstColorAccuracy.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelWorstColorAccuracy.Location = new System.Drawing.Point(163, 61);
			this.labelWorstColorAccuracy.Name = "labelWorstColorAccuracy";
			this.labelWorstColorAccuracy.Size = new System.Drawing.Size(99, 24);
			this.labelWorstColorAccuracy.TabIndex = 9;
			this.labelWorstColorAccuracy.Text = "0%";
			this.labelWorstColorAccuracy.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelBestColorAccuracy
			// 
			this.labelBestColorAccuracy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.labelBestColorAccuracy.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelBestColorAccuracy.Location = new System.Drawing.Point(163, 85);
			this.labelBestColorAccuracy.Name = "labelBestColorAccuracy";
			this.labelBestColorAccuracy.Size = new System.Drawing.Size(99, 24);
			this.labelBestColorAccuracy.TabIndex = 10;
			this.labelBestColorAccuracy.Text = "0%";
			this.labelBestColorAccuracy.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelNumberColors
			// 
			this.labelNumberColors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.labelNumberColors.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelNumberColors.Location = new System.Drawing.Point(163, 109);
			this.labelNumberColors.Name = "labelNumberColors";
			this.labelNumberColors.Size = new System.Drawing.Size(99, 24);
			this.labelNumberColors.TabIndex = 11;
			this.labelNumberColors.Text = "0";
			this.labelNumberColors.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelFrequentColorPixelCount
			// 
			this.labelFrequentColorPixelCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.labelFrequentColorPixelCount.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.labelFrequentColorPixelCount.Location = new System.Drawing.Point(163, 133);
			this.labelFrequentColorPixelCount.Name = "labelFrequentColorPixelCount";
			this.labelFrequentColorPixelCount.Size = new System.Drawing.Size(99, 24);
			this.labelFrequentColorPixelCount.TabIndex = 12;
			this.labelFrequentColorPixelCount.Text = "0";
			this.labelFrequentColorPixelCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// picturePainting
			// 
			this.picturePainting.Location = new System.Drawing.Point(269, 13);
			this.picturePainting.Name = "picturePainting";
			this.picturePainting.Size = new System.Drawing.Size(390, 434);
			this.picturePainting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picturePainting.TabIndex = 13;
			this.picturePainting.TabStop = false;
			// 
			// PostPaintForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(671, 459);
			this.Controls.Add(this.picturePainting);
			this.Controls.Add(this.labelFrequentColorPixelCount);
			this.Controls.Add(this.labelNumberColors);
			this.Controls.Add(this.labelBestColorAccuracy);
			this.Controls.Add(this.labelWorstColorAccuracy);
			this.Controls.Add(this.labelAverageColorAccuracy);
			this.Controls.Add(this.picturePaletteHeatmap);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelTimeToComplete);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "PostPaintForm";
			this.Text = "Post Paint Statistics";
			((System.ComponentModel.ISupportInitialize)(this.picturePaletteHeatmap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picturePainting)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelTimeToComplete;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox picturePaletteHeatmap;
		private System.Windows.Forms.Label labelAverageColorAccuracy;
		private System.Windows.Forms.Label labelWorstColorAccuracy;
		private System.Windows.Forms.Label labelBestColorAccuracy;
		private System.Windows.Forms.Label labelNumberColors;
		private System.Windows.Forms.Label labelFrequentColorPixelCount;
		private System.Windows.Forms.PictureBox picturePainting;
	}
}