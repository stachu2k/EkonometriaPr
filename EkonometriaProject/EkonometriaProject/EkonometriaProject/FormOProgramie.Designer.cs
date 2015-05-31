namespace EkonometriaProject
{
    partial class FormOProgramie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOProgramie));
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelCredits = new System.Windows.Forms.Label();
            this.pictureBoxCredits = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCredits)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(127, 284);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelCredits
            // 
            this.labelCredits.AutoSize = true;
            this.labelCredits.Location = new System.Drawing.Point(31, 187);
            this.labelCredits.Name = "labelCredits";
            this.labelCredits.Size = new System.Drawing.Size(266, 78);
            this.labelCredits.TabIndex = 1;
            this.labelCredits.Text = resources.GetString("labelCredits.Text");
            this.labelCredits.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxCredits
            // 
            this.pictureBoxCredits.Image = global::EkonometriaProject.Properties.Resources.wwb_img1;
            this.pictureBoxCredits.Location = new System.Drawing.Point(95, 26);
            this.pictureBoxCredits.Name = "pictureBoxCredits";
            this.pictureBoxCredits.Size = new System.Drawing.Size(139, 147);
            this.pictureBoxCredits.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxCredits.TabIndex = 2;
            this.pictureBoxCredits.TabStop = false;
            // 
            // FormOProgramie
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 332);
            this.Controls.Add(this.pictureBoxCredits);
            this.Controls.Add(this.labelCredits);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormOProgramie";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "O programie";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCredits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelCredits;
        private System.Windows.Forms.PictureBox pictureBoxCredits;
    }
}