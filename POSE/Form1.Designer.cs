namespace POSE
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lImages = new System.Windows.Forms.Label();
            this.cbImages = new System.Windows.Forms.ComboBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lImages
            // 
            this.lImages.AutoSize = true;
            this.lImages.Location = new System.Drawing.Point(13, 13);
            this.lImages.Name = "lImages";
            this.lImages.Size = new System.Drawing.Size(41, 13);
            this.lImages.TabIndex = 0;
            this.lImages.Text = "Images";
            // 
            // cbImages
            // 
            this.cbImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbImages.FormattingEnabled = true;
            this.cbImages.Location = new System.Drawing.Point(16, 29);
            this.cbImages.Name = "cbImages";
            this.cbImages.Size = new System.Drawing.Size(203, 21);
            this.cbImages.TabIndex = 1;
            this.cbImages.SelectedIndexChanged += new System.EventHandler(this.CbImages_SelectedIndexChanged);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(13, 57);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(206, 202);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImage.TabIndex = 2;
            this.pbImage.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(229, 270);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.cbImages);
            this.Controls.Add(this.lImages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lImages;
        private System.Windows.Forms.ComboBox cbImages;
        private System.Windows.Forms.PictureBox pbImage;
    }
}

