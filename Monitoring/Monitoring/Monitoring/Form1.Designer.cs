using System;
using System.Windows.Forms;

namespace Monitoring
{
    partial class Monitoring
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        String path = System.Environment.CurrentDirectory;

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
        public void InitializeComponent()
        {
            this.AddFiles = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Rayons = new System.Windows.Forms.ListBox();
            this.Errors = new System.Windows.Forms.TreeView();
            this.dayReportRB = new System.Windows.Forms.RadioButton();
            this.w2w = new System.Windows.Forms.RadioButton();
            this.fileCount = new System.Windows.Forms.Label();
            this.errorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddFiles
            // 
            this.AddFiles.Location = new System.Drawing.Point(1, 5);
            this.AddFiles.Name = "AddFiles";
            this.AddFiles.Size = new System.Drawing.Size(75, 23);
            this.AddFiles.TabIndex = 1;
            this.AddFiles.Text = "Файлы...";
            this.AddFiles.UseVisualStyleBackColor = true;
            // 
            // Check
            // 
            this.Check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Check.Enabled = false;
            this.Check.Location = new System.Drawing.Point(508, 5);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(93, 23);
            this.Check.TabIndex = 2;
            this.Check.Text = "Создать отчёт";
            this.Check.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Rayons
            // 
            this.Rayons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Rayons.FormattingEnabled = true;
            this.Rayons.Location = new System.Drawing.Point(1, 34);
            this.Rayons.Name = "Rayons";
            this.Rayons.Size = new System.Drawing.Size(600, 173);
            this.Rayons.TabIndex = 5;
            // 
            // Errors
            // 
            this.Errors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Errors.Location = new System.Drawing.Point(1, 222);
            this.Errors.Name = "Errors";
            this.Errors.Size = new System.Drawing.Size(600, 211);
            this.Errors.TabIndex = 6;
            // 
            // dayReportRB
            // 
            this.dayReportRB.AutoSize = true;
            this.dayReportRB.Checked = true;
            this.dayReportRB.Location = new System.Drawing.Point(232, 8);
            this.dayReportRB.Name = "dayReportRB";
            this.dayReportRB.Size = new System.Drawing.Size(100, 17);
            this.dayReportRB.TabIndex = 7;
            this.dayReportRB.TabStop = true;
            this.dayReportRB.Text = "Дневной отчет";
            this.dayReportRB.UseVisualStyleBackColor = true;
            // 
            // w2w
            // 
            this.w2w.AutoSize = true;
            this.w2w.Location = new System.Drawing.Point(339, 8);
            this.w2w.Name = "w2w";
            this.w2w.Size = new System.Drawing.Size(99, 17);
            this.w2w.TabIndex = 8;
            this.w2w.Text = "Среда к Среде";
            this.w2w.UseVisualStyleBackColor = true;
            // 
            // fileCount
            // 
            this.fileCount.AutoSize = true;
            this.fileCount.Location = new System.Drawing.Point(91, 10);
            this.fileCount.Name = "fileCount";
            this.fileCount.Size = new System.Drawing.Size(36, 13);
            this.fileCount.TabIndex = 9;
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.ForeColor = System.Drawing.Color.Red;
            this.errorMessage.Location = new System.Drawing.Point(9, 208);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(0, 13);
            this.errorMessage.TabIndex = 10;
            // 
            // Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(604, 436);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.fileCount);
            this.Controls.Add(this.w2w);
            this.Controls.Add(this.dayReportRB);
            this.Controls.Add(this.Errors);
            this.Controls.Add(this.Rayons);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.AddFiles);
            this.MaximumSize = new System.Drawing.Size(620, 700);
            this.MinimumSize = new System.Drawing.Size(369, 474);
            this.Name = "Monitoring";
            this.Text = "Мониторинг";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button AddFiles;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ListBox Rayons;
        private TreeView Errors;
        private RadioButton dayReportRB;
        private RadioButton w2w;
        private Label fileCount;
        private Label errorMessage;
    }
}

