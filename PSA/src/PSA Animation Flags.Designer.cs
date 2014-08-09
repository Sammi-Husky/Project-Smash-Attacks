namespace SmashAttacks
{
    partial class FormAnimationFlags
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
            this.lblInTransitionTime = new System.Windows.Forms.Label();
            this.chkNoOutTransition = new System.Windows.Forms.CheckBox();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.chkMovesCharacter = new System.Windows.Forms.CheckBox();
            this.chkFixedTranslation = new System.Windows.Forms.CheckBox();
            this.chkFixedRotation = new System.Windows.Forms.CheckBox();
            this.chkFixedScale = new System.Windows.Forms.CheckBox();
            this.chkTransitionOutFromStart = new System.Windows.Forms.CheckBox();
            this.chkUnknown4 = new System.Windows.Forms.CheckBox();
            this.txtInTransitionTime = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInTransitionTime
            // 
            this.lblInTransitionTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInTransitionTime.Location = new System.Drawing.Point(8, 8);
            this.lblInTransitionTime.Name = "lblInTransitionTime";
            this.lblInTransitionTime.Size = new System.Drawing.Size(96, 20);
            this.lblInTransitionTime.TabIndex = 0;
            this.lblInTransitionTime.Text = "In Transition Time:";
            // 
            // chkNoOutTransition
            // 
            this.chkNoOutTransition.AutoSize = true;
            this.chkNoOutTransition.Location = new System.Drawing.Point(8, 32);
            this.chkNoOutTransition.Name = "chkNoOutTransition";
            this.chkNoOutTransition.Size = new System.Drawing.Size(109, 17);
            this.chkNoOutTransition.TabIndex = 1;
            this.chkNoOutTransition.Text = "No Out Transition";
            this.chkNoOutTransition.UseVisualStyleBackColor = true;
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Location = new System.Drawing.Point(8, 56);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(50, 17);
            this.chkLoop.TabIndex = 2;
            this.chkLoop.Text = "Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            // 
            // chkMovesCharacter
            // 
            this.chkMovesCharacter.AutoSize = true;
            this.chkMovesCharacter.Location = new System.Drawing.Point(8, 80);
            this.chkMovesCharacter.Name = "chkMovesCharacter";
            this.chkMovesCharacter.Size = new System.Drawing.Size(107, 17);
            this.chkMovesCharacter.TabIndex = 3;
            this.chkMovesCharacter.Text = "Moves Character";
            this.chkMovesCharacter.UseVisualStyleBackColor = true;
            // 
            // chkFixedTranslation
            // 
            this.chkFixedTranslation.AutoSize = true;
            this.chkFixedTranslation.Location = new System.Drawing.Point(8, 104);
            this.chkFixedTranslation.Name = "chkFixedTranslation";
            this.chkFixedTranslation.Size = new System.Drawing.Size(106, 17);
            this.chkFixedTranslation.TabIndex = 4;
            this.chkFixedTranslation.Text = "Fixed Translation";
            this.chkFixedTranslation.UseVisualStyleBackColor = true;
            // 
            // chkFixedRotation
            // 
            this.chkFixedRotation.AutoSize = true;
            this.chkFixedRotation.Location = new System.Drawing.Point(136, 32);
            this.chkFixedRotation.Name = "chkFixedRotation";
            this.chkFixedRotation.Size = new System.Drawing.Size(94, 17);
            this.chkFixedRotation.TabIndex = 5;
            this.chkFixedRotation.Text = "Fixed Rotation";
            this.chkFixedRotation.UseVisualStyleBackColor = true;
            // 
            // chkFixedScale
            // 
            this.chkFixedScale.AutoSize = true;
            this.chkFixedScale.Location = new System.Drawing.Point(136, 56);
            this.chkFixedScale.Name = "chkFixedScale";
            this.chkFixedScale.Size = new System.Drawing.Size(81, 17);
            this.chkFixedScale.TabIndex = 6;
            this.chkFixedScale.Text = "Fixed Scale";
            this.chkFixedScale.UseVisualStyleBackColor = true;
            // 
            // chkTransitionOutFromStart
            // 
            this.chkTransitionOutFromStart.AutoSize = true;
            this.chkTransitionOutFromStart.Location = new System.Drawing.Point(136, 80);
            this.chkTransitionOutFromStart.Name = "chkTransitionOutFromStart";
            this.chkTransitionOutFromStart.Size = new System.Drawing.Size(143, 17);
            this.chkTransitionOutFromStart.TabIndex = 7;
            this.chkTransitionOutFromStart.Text = "Transition Out From Start";
            this.chkTransitionOutFromStart.UseVisualStyleBackColor = true;
            // 
            // chkUnknown4
            // 
            this.chkUnknown4.AutoSize = true;
            this.chkUnknown4.Location = new System.Drawing.Point(136, 104);
            this.chkUnknown4.Name = "chkUnknown4";
            this.chkUnknown4.Size = new System.Drawing.Size(72, 17);
            this.chkUnknown4.TabIndex = 8;
            this.chkUnknown4.Text = "Unknown";
            this.chkUnknown4.UseVisualStyleBackColor = true;
            // 
            // txtInTransitionTime
            // 
            this.txtInTransitionTime.Location = new System.Drawing.Point(104, 8);
            this.txtInTransitionTime.MaxLength = 3;
            this.txtInTransitionTime.Name = "txtInTransitionTime";
            this.txtInTransitionTime.Size = new System.Drawing.Size(32, 20);
            this.txtInTransitionTime.TabIndex = 9;
            this.txtInTransitionTime.Leave += new System.EventHandler(this.txtInTransitionTime_Leave);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(8, 128);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(112, 24);
            this.btnDone.TabIndex = 11;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(136, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 24);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormAnimationFlags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 160);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtInTransitionTime);
            this.Controls.Add(this.chkUnknown4);
            this.Controls.Add(this.chkTransitionOutFromStart);
            this.Controls.Add(this.chkFixedScale);
            this.Controls.Add(this.chkFixedRotation);
            this.Controls.Add(this.chkFixedTranslation);
            this.Controls.Add(this.chkMovesCharacter);
            this.Controls.Add(this.chkLoop);
            this.Controls.Add(this.chkNoOutTransition);
            this.Controls.Add(this.lblInTransitionTime);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(284, 160);
            this.Name = "FormAnimationFlags";
            this.ShowIcon = false;
            this.Text = "Animation Flags";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAnimationFlags_FormClosing);
            this.Load += new System.EventHandler(this.FormAnimationFlags_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInTransitionTime;
        private System.Windows.Forms.CheckBox chkNoOutTransition;
        private System.Windows.Forms.CheckBox chkLoop;
        private System.Windows.Forms.CheckBox chkMovesCharacter;
        private System.Windows.Forms.CheckBox chkFixedTranslation;
        private System.Windows.Forms.CheckBox chkFixedRotation;
        private System.Windows.Forms.CheckBox chkFixedScale;
        private System.Windows.Forms.CheckBox chkTransitionOutFromStart;
        private System.Windows.Forms.CheckBox chkUnknown4;
        private System.Windows.Forms.TextBox txtInTransitionTime;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
    }
}