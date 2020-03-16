namespace WikiForm
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
            this.path_textBox = new System.Windows.Forms.TextBox();
            this.openBut = new System.Windows.Forms.Button();
            this.backupBut = new System.Windows.Forms.Button();
            this.restoreBut = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backup_dumpBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // path_textBox
            // 
            this.path_textBox.Location = new System.Drawing.Point(54, 29);
            this.path_textBox.Name = "path_textBox";
            this.path_textBox.Size = new System.Drawing.Size(353, 20);
            this.path_textBox.TabIndex = 0;
            // 
            // openBut
            // 
            this.openBut.Location = new System.Drawing.Point(422, 25);
            this.openBut.Name = "openBut";
            this.openBut.Size = new System.Drawing.Size(90, 27);
            this.openBut.TabIndex = 1;
            this.openBut.Text = "открыть";
            this.openBut.UseVisualStyleBackColor = true;
            this.openBut.Click += new System.EventHandler(this.OpenBut_Click);
            // 
            // backupBut
            // 
            this.backupBut.Location = new System.Drawing.Point(54, 78);
            this.backupBut.Name = "backupBut";
            this.backupBut.Size = new System.Drawing.Size(137, 27);
            this.backupBut.TabIndex = 2;
            this.backupBut.Text = "backup sql";
            this.backupBut.UseVisualStyleBackColor = true;
            this.backupBut.Click += new System.EventHandler(this.BackupBut_Click);
            // 
            // restoreBut
            // 
            this.restoreBut.Location = new System.Drawing.Point(375, 78);
            this.restoreBut.Name = "restoreBut";
            this.restoreBut.Size = new System.Drawing.Size(137, 27);
            this.restoreBut.TabIndex = 3;
            this.restoreBut.Text = "restore";
            this.restoreBut.UseVisualStyleBackColor = true;
            this.restoreBut.Click += new System.EventHandler(this.RestoreBut_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // backup_dumpBut
            // 
            this.backup_dumpBut.Location = new System.Drawing.Point(219, 78);
            this.backup_dumpBut.Name = "backup_dumpBut";
            this.backup_dumpBut.Size = new System.Drawing.Size(137, 27);
            this.backup_dumpBut.TabIndex = 4;
            this.backup_dumpBut.Text = "backup dump";
            this.backup_dumpBut.UseVisualStyleBackColor = true;
            this.backup_dumpBut.Click += new System.EventHandler(this.Backup_dumpBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 126);
            this.Controls.Add(this.backup_dumpBut);
            this.Controls.Add(this.restoreBut);
            this.Controls.Add(this.backupBut);
            this.Controls.Add(this.openBut);
            this.Controls.Add(this.path_textBox);
            this.Name = "Form1";
            this.Text = "WikiBackup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox path_textBox;
        private System.Windows.Forms.Button openBut;
        private System.Windows.Forms.Button backupBut;
        private System.Windows.Forms.Button restoreBut;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button backup_dumpBut;
    }
}

