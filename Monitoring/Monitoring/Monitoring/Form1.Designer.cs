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
            this.components = new System.ComponentModel.Container();
            this.AddFiles = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Rayons = new System.Windows.Forms.ListBox();
            this.Errors = new System.Windows.Forms.TreeView();
            this.fileCount = new System.Windows.Forms.Label();
            this.errorMessage = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dayTab = new System.Windows.Forms.TabPage();
            this.dayReportPB = new System.Windows.Forms.ProgressBar();
            this.weekTab = new System.Windows.Forms.TabPage();
            this.weekReportLog = new System.Windows.Forms.TreeView();
            this.weekReportPB = new System.Windows.Forms.ProgressBar();
            this.weekReportBtn = new System.Windows.Forms.Button();
            this.wednesdayReports = new System.Windows.Forms.ListBox();
            this.AddWeekFiles = new System.Windows.Forms.Button();
            this.over10Tab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.over10PB = new System.Windows.Forms.ProgressBar();
            this.over10Report = new System.Windows.Forms.Button();
            this.curWeekBtn = new System.Windows.Forms.Button();
            this.prevWeekBtn = new System.Windows.Forms.Button();
            this.curWeek = new System.Windows.Forms.ListBox();
            this.prevWeek = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.dayTab.SuspendLayout();
            this.weekTab.SuspendLayout();
            this.over10Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddFiles
            // 
            this.AddFiles.BackColor = System.Drawing.Color.Transparent;
            this.AddFiles.Location = new System.Drawing.Point(6, 6);
            this.AddFiles.Name = "AddFiles";
            this.AddFiles.Size = new System.Drawing.Size(75, 23);
            this.AddFiles.TabIndex = 1;
            this.AddFiles.Text = "Файлы...";
            this.AddFiles.UseVisualStyleBackColor = false;
            // 
            // Check
            // 
            this.Check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Check.Location = new System.Drawing.Point(6, 381);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(160, 23);
            this.Check.TabIndex = 2;
            this.Check.Text = "Cоздать отчёт";
            this.Check.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Rayons
            // 
            this.Rayons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Rayons.FormattingEnabled = true;
            this.Rayons.Location = new System.Drawing.Point(2, 33);
            this.Rayons.Name = "Rayons";
            this.Rayons.Size = new System.Drawing.Size(172, 342);
            this.Rayons.Sorted = true;
            this.Rayons.TabIndex = 5;
            // 
            // Errors
            // 
            this.Errors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Errors.Location = new System.Drawing.Point(191, 33);
            this.Errors.Name = "Errors";
            this.Errors.Size = new System.Drawing.Size(500, 342);
            this.Errors.TabIndex = 6;
            // 
            // fileCount
            // 
            this.fileCount.AutoSize = true;
            this.fileCount.Location = new System.Drawing.Point(91, 10);
            this.fileCount.Name = "fileCount";
            this.fileCount.Size = new System.Drawing.Size(0, 13);
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.dayTab);
            this.tabControl1.Controls.Add(this.weekTab);
            this.tabControl1.Controls.Add(this.over10Tab);
            this.tabControl1.ItemSize = new System.Drawing.Size(199, 23);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 436);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 11;
            // 
            // dayTab
            // 
            this.dayTab.BackColor = System.Drawing.SystemColors.Control;
            this.dayTab.Controls.Add(this.dayReportPB);
            this.dayTab.Controls.Add(this.AddFiles);
            this.dayTab.Controls.Add(this.Rayons);
            this.dayTab.Controls.Add(this.Errors);
            this.dayTab.Controls.Add(this.Check);
            this.dayTab.Location = new System.Drawing.Point(4, 27);
            this.dayTab.Name = "dayTab";
            this.dayTab.Padding = new System.Windows.Forms.Padding(3);
            this.dayTab.Size = new System.Drawing.Size(694, 405);
            this.dayTab.TabIndex = 0;
            this.dayTab.Text = "День";
            // 
            // dayReportPB
            // 
            this.dayReportPB.Location = new System.Drawing.Point(191, 381);
            this.dayReportPB.Maximum = 104;
            this.dayReportPB.Name = "dayReportPB";
            this.dayReportPB.Size = new System.Drawing.Size(500, 23);
            this.dayReportPB.TabIndex = 7;
            // 
            // weekTab
            // 
            this.weekTab.BackColor = System.Drawing.SystemColors.Control;
            this.weekTab.Controls.Add(this.weekReportLog);
            this.weekTab.Controls.Add(this.weekReportPB);
            this.weekTab.Controls.Add(this.weekReportBtn);
            this.weekTab.Controls.Add(this.wednesdayReports);
            this.weekTab.Controls.Add(this.AddWeekFiles);
            this.weekTab.Location = new System.Drawing.Point(4, 27);
            this.weekTab.Name = "weekTab";
            this.weekTab.Padding = new System.Windows.Forms.Padding(3);
            this.weekTab.Size = new System.Drawing.Size(694, 405);
            this.weekTab.TabIndex = 1;
            this.weekTab.Text = "Неделя";
            // 
            // weekReportLog
            // 
            this.weekReportLog.Location = new System.Drawing.Point(192, 33);
            this.weekReportLog.Name = "weekReportLog";
            this.weekReportLog.Size = new System.Drawing.Size(499, 342);
            this.weekReportLog.TabIndex = 6;
            // 
            // weekReportPB
            // 
            this.weekReportPB.Location = new System.Drawing.Point(192, 381);
            this.weekReportPB.Maximum = 102;
            this.weekReportPB.Name = "weekReportPB";
            this.weekReportPB.Size = new System.Drawing.Size(499, 23);
            this.weekReportPB.TabIndex = 5;
            // 
            // weekReportBtn
            // 
            this.weekReportBtn.Location = new System.Drawing.Point(6, 381);
            this.weekReportBtn.Name = "weekReportBtn";
            this.weekReportBtn.Size = new System.Drawing.Size(160, 23);
            this.weekReportBtn.TabIndex = 4;
            this.weekReportBtn.Text = "Создать отчёт";
            this.weekReportBtn.UseVisualStyleBackColor = true;
            // 
            // wednesdayReports
            // 
            this.wednesdayReports.FormattingEnabled = true;
            this.wednesdayReports.Location = new System.Drawing.Point(2, 33);
            this.wednesdayReports.Name = "wednesdayReports";
            this.wednesdayReports.Size = new System.Drawing.Size(172, 342);
            this.wednesdayReports.Sorted = true;
            this.wednesdayReports.TabIndex = 3;
            // 
            // AddWeekFiles
            // 
            this.AddWeekFiles.Location = new System.Drawing.Point(6, 6);
            this.AddWeekFiles.Name = "AddWeekFiles";
            this.AddWeekFiles.Size = new System.Drawing.Size(75, 23);
            this.AddWeekFiles.TabIndex = 2;
            this.AddWeekFiles.Text = "Файлы...";
            this.AddWeekFiles.UseVisualStyleBackColor = true;
            // 
            // over10Tab
            // 
            this.over10Tab.BackColor = System.Drawing.SystemColors.Control;
            this.over10Tab.Controls.Add(this.label2);
            this.over10Tab.Controls.Add(this.label1);
            this.over10Tab.Controls.Add(this.over10PB);
            this.over10Tab.Controls.Add(this.over10Report);
            this.over10Tab.Controls.Add(this.curWeekBtn);
            this.over10Tab.Controls.Add(this.prevWeekBtn);
            this.over10Tab.Controls.Add(this.curWeek);
            this.over10Tab.Controls.Add(this.prevWeek);
            this.over10Tab.Cursor = System.Windows.Forms.Cursors.Default;
            this.over10Tab.Location = new System.Drawing.Point(4, 27);
            this.over10Tab.Name = "over10Tab";
            this.over10Tab.Padding = new System.Windows.Forms.Padding(3);
            this.over10Tab.Size = new System.Drawing.Size(694, 405);
            this.over10Tab.TabIndex = 2;
            this.over10Tab.Text = "Сверх 10%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(470, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Текущая неделя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(120, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Прошлая неделя";
            // 
            // over10PB
            // 
            this.over10PB.Location = new System.Drawing.Point(156, 379);
            this.over10PB.Maximum = 104;
            this.over10PB.Name = "over10PB";
            this.over10PB.Size = new System.Drawing.Size(377, 23);
            this.over10PB.TabIndex = 5;
            // 
            // over10Report
            // 
            this.over10Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.over10Report.Location = new System.Drawing.Point(297, 342);
            this.over10Report.Name = "over10Report";
            this.over10Report.Size = new System.Drawing.Size(93, 36);
            this.over10Report.TabIndex = 4;
            this.over10Report.Text = "Рассчитать";
            this.over10Report.UseVisualStyleBackColor = true;
            // 
            // curWeekBtn
            // 
            this.curWeekBtn.Location = new System.Drawing.Point(496, 6);
            this.curWeekBtn.Name = "curWeekBtn";
            this.curWeekBtn.Size = new System.Drawing.Size(75, 23);
            this.curWeekBtn.TabIndex = 3;
            this.curWeekBtn.Text = "Файлы...";
            this.curWeekBtn.UseVisualStyleBackColor = true;
            // 
            // prevWeekBtn
            // 
            this.prevWeekBtn.Location = new System.Drawing.Point(146, 6);
            this.prevWeekBtn.Name = "prevWeekBtn";
            this.prevWeekBtn.Size = new System.Drawing.Size(75, 23);
            this.prevWeekBtn.TabIndex = 2;
            this.prevWeekBtn.Text = "Файлы...";
            this.prevWeekBtn.UseVisualStyleBackColor = true;
            // 
            // curWeek
            // 
            this.curWeek.FormattingEnabled = true;
            this.curWeek.Location = new System.Drawing.Point(371, 48);
            this.curWeek.Name = "curWeek";
            this.curWeek.Size = new System.Drawing.Size(315, 290);
            this.curWeek.Sorted = true;
            this.curWeek.TabIndex = 1;
            // 
            // prevWeek
            // 
            this.prevWeek.FormattingEnabled = true;
            this.prevWeek.Location = new System.Drawing.Point(3, 48);
            this.prevWeek.Name = "prevWeek";
            this.prevWeek.Size = new System.Drawing.Size(316, 290);
            this.prevWeek.Sorted = true;
            this.prevWeek.TabIndex = 0;
            // 
            // Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(704, 436);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.errorMessage);
            this.Controls.Add(this.fileCount);
            this.MaximumSize = new System.Drawing.Size(720, 700);
            this.MinimumSize = new System.Drawing.Size(369, 474);
            this.Name = "Monitoring";
            this.Text = "Мониторинг";
            this.tabControl1.ResumeLayout(false);
            this.dayTab.ResumeLayout(false);
            this.weekTab.ResumeLayout(false);
            this.over10Tab.ResumeLayout(false);
            this.over10Tab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button AddFiles;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ListBox Rayons;
        private TreeView Errors;
        private Label fileCount;
        private Label errorMessage;
        private TabControl tabControl1;
        private TabPage dayTab;
        private TabPage weekTab;
        private TabPage over10Tab;
        private ProgressBar dayReportPB;
        private Button weekReportBtn;
        private ListBox wednesdayReports;
        private Button AddWeekFiles;
        private TreeView weekReportLog;
        private ProgressBar weekReportPB;
        private Button curWeekBtn;
        private Button prevWeekBtn;
        private ListBox curWeek;
        private ListBox prevWeek;
        private ToolTip toolTip1;
        private ProgressBar over10PB;
        private Button over10Report;
        private Label label2;
        private Label label1;
    }
}

