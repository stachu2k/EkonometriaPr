namespace EkonometriaProject
{
    partial class Form1
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
            this.menuGornyPasek = new System.Windows.Forms.MenuStrip();
            this.plikMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.zaladujPlikMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetujMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramieMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaladujPlikFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGridDane = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxDane = new System.Windows.Forms.GroupBox();
            this.groupBoxR0 = new System.Windows.Forms.GroupBox();
            this.dataGridR0 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxR = new System.Windows.Forms.GroupBox();
            this.dataGridR = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBoxR_pi = new System.Windows.Forms.GroupBox();
            this.dataGridR_pi = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuGornyPasek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDane)).BeginInit();
            this.groupBoxDane.SuspendLayout();
            this.groupBoxR0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridR0)).BeginInit();
            this.groupBoxR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridR)).BeginInit();
            this.groupBoxR_pi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridR_pi)).BeginInit();
            this.SuspendLayout();
            // 
            // menuGornyPasek
            // 
            this.menuGornyPasek.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikMenu,
            this.infoMenu});
            this.menuGornyPasek.Location = new System.Drawing.Point(0, 0);
            this.menuGornyPasek.Name = "menuGornyPasek";
            this.menuGornyPasek.Size = new System.Drawing.Size(855, 24);
            this.menuGornyPasek.TabIndex = 1;
            this.menuGornyPasek.Text = "menuStrip1";
            // 
            // plikMenu
            // 
            this.plikMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zaladujPlikMenuItem,
            this.resetujMenuItem});
            this.plikMenu.Name = "plikMenu";
            this.plikMenu.Size = new System.Drawing.Size(38, 20);
            this.plikMenu.Text = "Plik";
            // 
            // zaladujPlikMenuItem
            // 
            this.zaladujPlikMenuItem.Name = "zaladujPlikMenuItem";
            this.zaladujPlikMenuItem.Size = new System.Drawing.Size(144, 22);
            this.zaladujPlikMenuItem.Text = "Załaduj plik...";
            this.zaladujPlikMenuItem.Click += new System.EventHandler(this.zaladujPlikMenuItem_Click);
            // 
            // resetujMenuItem
            // 
            this.resetujMenuItem.Name = "resetujMenuItem";
            this.resetujMenuItem.Size = new System.Drawing.Size(144, 22);
            this.resetujMenuItem.Text = "Resetuj";
            // 
            // infoMenu
            // 
            this.infoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramieMenuItem});
            this.infoMenu.Name = "infoMenu";
            this.infoMenu.Size = new System.Drawing.Size(40, 20);
            this.infoMenu.Text = "Info";
            // 
            // oProgramieMenuItem
            // 
            this.oProgramieMenuItem.Name = "oProgramieMenuItem";
            this.oProgramieMenuItem.Size = new System.Drawing.Size(141, 22);
            this.oProgramieMenuItem.Text = "O programie";
            // 
            // zaladujPlikFileDialog
            // 
            this.zaladujPlikFileDialog.Filter = "pliki TXT|*txt|Wszystkie pliki|*.*";
            // 
            // dataGridDane
            // 
            this.dataGridDane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridDane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDane.Location = new System.Drawing.Point(3, 16);
            this.dataGridDane.Name = "dataGridDane";
            this.dataGridDane.RowHeadersVisible = false;
            this.dataGridDane.RowHeadersWidth = 100;
            this.dataGridDane.Size = new System.Drawing.Size(326, 183);
            this.dataGridDane.TabIndex = 2;
            this.dataGridDane.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridDane_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // groupBoxDane
            // 
            this.groupBoxDane.Controls.Add(this.dataGridDane);
            this.groupBoxDane.Location = new System.Drawing.Point(12, 27);
            this.groupBoxDane.Name = "groupBoxDane";
            this.groupBoxDane.Size = new System.Drawing.Size(332, 202);
            this.groupBoxDane.TabIndex = 3;
            this.groupBoxDane.TabStop = false;
            this.groupBoxDane.Text = "Dane statystyczne";
            // 
            // groupBoxR0
            // 
            this.groupBoxR0.Controls.Add(this.dataGridR0);
            this.groupBoxR0.Location = new System.Drawing.Point(362, 27);
            this.groupBoxR0.Name = "groupBoxR0";
            this.groupBoxR0.Size = new System.Drawing.Size(127, 202);
            this.groupBoxR0.TabIndex = 4;
            this.groupBoxR0.TabStop = false;
            this.groupBoxR0.Text = "Macierz korelacji R0";
            // 
            // dataGridR0
            // 
            this.dataGridR0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridR0.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2});
            this.dataGridR0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridR0.Location = new System.Drawing.Point(3, 16);
            this.dataGridR0.Name = "dataGridR0";
            this.dataGridR0.RowHeadersVisible = false;
            this.dataGridR0.Size = new System.Drawing.Size(121, 183);
            this.dataGridR0.TabIndex = 0;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // groupBoxR
            // 
            this.groupBoxR.Controls.Add(this.dataGridR);
            this.groupBoxR.Location = new System.Drawing.Point(506, 27);
            this.groupBoxR.Name = "groupBoxR";
            this.groupBoxR.Size = new System.Drawing.Size(332, 202);
            this.groupBoxR.TabIndex = 5;
            this.groupBoxR.TabStop = false;
            this.groupBoxR.Text = "Macierz korelacji R1";
            // 
            // dataGridR
            // 
            this.dataGridR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3});
            this.dataGridR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridR.Location = new System.Drawing.Point(3, 16);
            this.dataGridR.Name = "dataGridR";
            this.dataGridR.RowHeadersVisible = false;
            this.dataGridR.Size = new System.Drawing.Size(326, 183);
            this.dataGridR.TabIndex = 0;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 235);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(474, 199);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // groupBoxR_pi
            // 
            this.groupBoxR_pi.Controls.Add(this.dataGridR_pi);
            this.groupBoxR_pi.Location = new System.Drawing.Point(506, 232);
            this.groupBoxR_pi.Name = "groupBoxR_pi";
            this.groupBoxR_pi.Size = new System.Drawing.Size(332, 202);
            this.groupBoxR_pi.TabIndex = 7;
            this.groupBoxR_pi.TabStop = false;
            this.groupBoxR_pi.Text = "Macierz R\'";
            // 
            // dataGridR_pi
            // 
            this.dataGridR_pi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridR_pi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4});
            this.dataGridR_pi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridR_pi.Location = new System.Drawing.Point(3, 16);
            this.dataGridR_pi.Name = "dataGridR_pi";
            this.dataGridR_pi.RowHeadersVisible = false;
            this.dataGridR_pi.Size = new System.Drawing.Size(326, 183);
            this.dataGridR_pi.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 449);
            this.Controls.Add(this.groupBoxR_pi);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBoxR);
            this.Controls.Add(this.groupBoxR0);
            this.Controls.Add(this.groupBoxDane);
            this.Controls.Add(this.menuGornyPasek);
            this.MainMenuStrip = this.menuGornyPasek;
            this.Name = "Form1";
            this.Text = "Ekonometria";
            this.menuGornyPasek.ResumeLayout(false);
            this.menuGornyPasek.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDane)).EndInit();
            this.groupBoxDane.ResumeLayout(false);
            this.groupBoxR0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridR0)).EndInit();
            this.groupBoxR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridR)).EndInit();
            this.groupBoxR_pi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridR_pi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuGornyPasek;
        private System.Windows.Forms.ToolStripMenuItem plikMenu;
        private System.Windows.Forms.ToolStripMenuItem zaladujPlikMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetujMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoMenu;
        private System.Windows.Forms.ToolStripMenuItem oProgramieMenuItem;
        private System.Windows.Forms.OpenFileDialog zaladujPlikFileDialog;
        private System.Windows.Forms.DataGridView dataGridDane;
        private System.Windows.Forms.GroupBox groupBoxDane;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.GroupBox groupBoxR0;
        private System.Windows.Forms.DataGridView dataGridR0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBoxR;
        private System.Windows.Forms.DataGridView dataGridR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBoxR_pi;
        private System.Windows.Forms.DataGridView dataGridR_pi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;

    }
}

