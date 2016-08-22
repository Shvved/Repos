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
            this.Wednesday = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Rayons = new System.Windows.Forms.ListBox();
            this.Errors = new System.Windows.Forms.TreeView();
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
            this.Check.Location = new System.Drawing.Point(394, 5);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(93, 23);
            this.Check.TabIndex = 2;
            this.Check.Text = "Создать отчёт";
            this.Check.UseVisualStyleBackColor = true;
            // 
            // Wednesday
            // 
            this.Wednesday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Wednesday.Location = new System.Drawing.Point(490, 5);
            this.Wednesday.Name = "Wednesday";
            this.Wednesday.Size = new System.Drawing.Size(89, 23);
            this.Wednesday.TabIndex = 3;
            this.Wednesday.Text = "Среда к среде";
            this.Wednesday.UseVisualStyleBackColor = true;
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
            // Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(604, 436);
            this.Controls.Add(this.Errors);
            this.Controls.Add(this.Rayons);
            this.Controls.Add(this.Wednesday);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.AddFiles);
            this.MaximumSize = new System.Drawing.Size(620, 700);
            this.MinimumSize = new System.Drawing.Size(369, 474);
            this.Name = "Monitoring";
            this.Text = "Мониторинг";
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Button AddFiles;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.Button Wednesday;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ListBox Rayons;
        private TreeView Errors;
    }
}

