namespace SmashAttacks
{
    partial class AboutBox
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblName1 = new System.Windows.Forms.Label();
            this.lblName2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblGNULicense = new System.Windows.Forms.Label();
            this.lblhAdditionalContributors = new System.Windows.Forms.Label();
            this.lstAdditionalContributors = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::SmashAttacks.Properties.Resources.pictureBox1_Image;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblName1
            // 
            this.lblName1.AutoSize = true;
            this.lblName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName1.Location = new System.Drawing.Point(96, 16);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(44, 13);
            this.lblName1.TabIndex = 1;
            this.lblName1.Text = "Creator:";
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName2.Location = new System.Drawing.Point(96, 40);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(45, 13);
            this.lblName2.TabIndex = 2;
            this.lblName2.Text = "Version:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(128, 264);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(96, 48);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(145, 13);
            this.lblLine.TabIndex = 4;
            this.lblLine.Text = "_______________________";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreator.Location = new System.Drawing.Point(144, 16);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(82, 13);
            this.lblCreator.TabIndex = 5;
            this.lblCreator.Text = "Phantom Wings";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(144, 40);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(28, 13);
            this.lblVersion.TabIndex = 6;
            this.lblVersion.Text = "1.3a";
            // 
            // lblGNULicense
            // 
            this.lblGNULicense.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblGNULicense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblGNULicense.Location = new System.Drawing.Point(8, 88);
            this.lblGNULicense.Name = "lblGNULicense";
            this.lblGNULicense.Size = new System.Drawing.Size(392, 168);
            this.lblGNULicense.TabIndex = 7;
            this.lblGNULicense.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblhAdditionalContributors
            // 
            this.lblhAdditionalContributors.AutoSize = true;
            this.lblhAdditionalContributors.Location = new System.Drawing.Point(248, 8);
            this.lblhAdditionalContributors.Name = "lblhAdditionalContributors";
            this.lblhAdditionalContributors.Size = new System.Drawing.Size(115, 13);
            this.lblhAdditionalContributors.TabIndex = 8;
            this.lblhAdditionalContributors.Text = "Additional Contributors.";
            // 
            // lstAdditionalContributors
            // 
            this.lstAdditionalContributors.FormattingEnabled = true;
            this.lstAdditionalContributors.Items.AddRange(new object[] {
            "Sammi Husky",
            "Dantarion"});
            this.lstAdditionalContributors.Location = new System.Drawing.Point(248, 24);
            this.lstAdditionalContributors.Name = "lstAdditionalContributors";
            this.lstAdditionalContributors.ScrollAlwaysVisible = true;
            this.lstAdditionalContributors.Size = new System.Drawing.Size(152, 56);
            this.lstAdditionalContributors.TabIndex = 9;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 293);
            this.Controls.Add(this.lstAdditionalContributors);
            this.Controls.Add(this.lblhAdditionalContributors);
            this.Controls.Add(this.lblGNULicense);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCreator);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblName2);
            this.Controls.Add(this.lblName1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutBox";
            this.Text = "Smash Attacks";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblGNULicense;
        private System.Windows.Forms.Label lblhAdditionalContributors;
        private System.Windows.Forms.ListBox lstAdditionalContributors;
    }
}