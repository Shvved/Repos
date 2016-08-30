using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using GemBox.Spreadsheet;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace Monitoring
{
    public partial class Monitoring : Form
    {
        private ContextMenuStrip ContextMenu;
        ArrayList list = new ArrayList();
        ArrayList weekList = new ArrayList();
        ArrayList prevWeekList = new ArrayList();
        ArrayList curWeekList = new ArrayList();
        int rowNum = 40;  // Кол-во строк в файле
        int rowOffset = 5; // Смещение нужных строк в файле
        static string outPathDay = Directory.GetCurrentDirectory() + @"\day_out\";
        static string outPathWeek = Directory.GetCurrentDirectory() + @"\week_out\";
        static string outPathOver10 = Directory.GetCurrentDirectory() + @"\over10_out\";
        string dayOutTemplates = Directory.GetCurrentDirectory() + @"\templates\day_report.xlsx";
        string weekOutTemplates = Directory.GetCurrentDirectory() + @"\templates\week_report.xlsx";
        string over10OutTemplates = Directory.GetCurrentDirectory() + @"\templates\over10_report.xlsx";
        string dayOutPath = outPathDay + "day_" + DateTime.Now.ToString("dd.MM.yyyy") + ".xlsx";
        string weekOutPath = outPathWeek + "week_" + DateTime.Now.ToString("dd.MM.yyyy") + ".xlsx";
        string over10OutPath = outPathOver10 + "over_10" + DateTime.Now.ToString("dd.MM.yyyy") + ".xlsx";
        public Monitoring()
        {
            InitializeComponent();
            ContextMenu = new ContextMenuStrip();
            ContextMenu.Opening += new CancelEventHandler(ContextMenu_Opening);
            ContextMenu.ItemClicked += new ToolStripItemClickedEventHandler(ContextMenu_Del);

            Rayons.MouseDown += listBox1_MouseDown;
            wednesdayReports.MouseDown += listBox1_MouseDown;
            prevWeek.MouseDown += listBox1_MouseDown;
            curWeek.MouseDown += listBox1_MouseDown;

            Rayons.ContextMenuStrip = ContextMenu;
            wednesdayReports.ContextMenuStrip = ContextMenu;
            prevWeek.ContextMenuStrip = ContextMenu;
            curWeek.ContextMenuStrip = ContextMenu;

            AddFiles.Click += AddFiles_Click;
            Check.Click += CheckAndReporting;
            AddWeekFiles.Click += AddFiles_Click;
            prevWeekBtn.Click += AddFiles_Click;
            curWeekBtn.Click += AddFiles_Click;
            over10Report.Click += Over10Report_Click;
            weekReportBtn.Click += weekReportBtn_Click;
           
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                switch (((ListBox)sender).Name)
                {
                    case "Rayons":
                        Rayons.SelectedIndex = Rayons.IndexFromPoint(e.Location);
                        if (Rayons.SelectedIndex != -1)
                        {
                            ContextMenu.Show();
                        }
                        break;
                    case "wednesdayReports":
                        wednesdayReports.SelectedIndex = wednesdayReports.IndexFromPoint(e.Location);
                        if (wednesdayReports.SelectedIndex != -1)
                        {
                            ContextMenu.Show();
                        }
                        break;
                    case "prevWeek":
                        prevWeek.SelectedIndex = prevWeek.IndexFromPoint(e.Location);
                        if (prevWeek.SelectedIndex != -1)
                        {
                            ContextMenu.Show();
                        }
                        break;
                    case "curWeek":
                        curWeek.SelectedIndex = curWeek.IndexFromPoint(e.Location);
                        if (curWeek.SelectedIndex != -1)
                        {
                            ContextMenu.Show();
                        }
                        break;
                }
                //select the item under the mouse pointer
                
            }
        }

        void ContextMenu_Del(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip menu = sender as ContextMenuStrip;
            Control sourceControl = menu.SourceControl;
            switch (sourceControl.Name)
            {
                case "Rayons":
                   list.Remove(list[Rayons.SelectedIndex]);
                    Rayons.Items.Remove(Rayons.SelectedItem);
                    break;
                case "wednesdayReports":
                    weekList.Remove(weekList[wednesdayReports.SelectedIndex]);
                    wednesdayReports.Items.Remove(wednesdayReports.SelectedItem);
                    break;
                case "prevWeek":
                    prevWeekList.Remove(prevWeekList[prevWeek.SelectedIndex]);
                    prevWeek.Items.Remove(prevWeek.SelectedItem);
                    break;
                case "curWeek":
                    curWeekList.Remove(curWeekList[curWeek.SelectedIndex]);
                    curWeek.Items.Remove(curWeek.SelectedItem);
                    break;
            }
            
            
        }

        private void ContextMenu_Opening(object sender, CancelEventArgs e)
        {
            //clear the menu and add custom items
            ContextMenu.Items.Clear();
            ContextMenu.Items.Add("Удалить");
        }

        public void AddFiles_Click(object sender, System.EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = path;
            openFileDialog1.Filter = "Файлы Excel (*.xls; *.xlsx) | *.xls; *.xlsx";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "Выберите файлы";
            
            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                   switch (((Button)sender).Name)
                    {
                        case "AddFiles":
                            Rayons.Items.Add(Path.GetFileName(file));
                            list.Add(file);
                            CheckFileCount("Rayons");
                            break;
                        case "AddWeekFiles":
                            wednesdayReports.Items.Add(Path.GetFileName(file));
                            weekList.Add(file);
                            CheckFileCount("wednesdayReports");
                            break;
                        case "prevWeekBtn":
                            prevWeek.Items.Add(Path.GetFileName(file));
                            prevWeekList.Add(file);
                            CheckFileCount("prevWeek");
                            break;
                        case "curWeekBtn":
                            curWeek.Items.Add(Path.GetFileName(file));
                            curWeekList.Add(file);
                            CheckFileCount("curWeek");
                            break;
                    }
             }
          }
   }

        public void CheckFileCount(String listName)
        {
            bool flag = false;
            switch (listName)
            {
                case "Rayons":
                    if (Rayons.Items.Count == 26)
                    {
                        Errors.Nodes.Add("Файлов в списке:" + Rayons.Items.Count + @" \ 26");
                        Check.Enabled = true;
                    }
                    else
                    {
                        Errors.Nodes.Add("Файлов в списке:" + Rayons.Items.Count + @" \ 26");
                    }
                    break;
                case "wednesdayReports":
                    if (wednesdayReports.Items.Count == 2)
                    {
                        weekReportLog.Nodes.Add("Файлов в списке:" + wednesdayReports.Items.Count + @" \ 2");
                        weekReportBtn.Enabled = true;
                    }
                    else
                    {
                        weekReportLog.Nodes.Add("Файлов в списке:" + wednesdayReports.Items.Count + @" \ 2");
                    }
                    break;
                case "prevWeek":
                    if ((prevWeek.Items.Count == 26) && (curWeek.Items.Count == 26))
                    {
                        over10Log.Nodes.Add("Файлов в первом списке:" + prevWeek.Items.Count + @" \ 26");
                        over10Report.Enabled = true;
                    }
                    else
                    {
                        over10Log.Nodes.Add("Файлов в первом списке:" + prevWeek.Items.Count + @" \ 26");
                    }
                    break;
                case "curWeek":
                    if ((prevWeek.Items.Count == 26) && (curWeek.Items.Count == 26))
                    {
                        over10Log.Nodes.Add("Файлов во втором списке:" + curWeek.Items.Count + @" \ 26");
                        over10Report.Enabled = true;
                    }
                    else
                    {
                        over10Log.Nodes.Add("Файлов во втором списке:" + curWeek.Items.Count + @" \ 26");
                    }
                    break;
            }
        }

        private void Over10Report_Click(object sender, EventArgs e)
        {
           Over10Report();
        }

        private void weekReportBtn_Click(object sender, EventArgs e)
        {
            WeekReport();
        }

        public void CheckAndReporting(object sender, System.EventArgs e)
        {
            if (Process.GetProcessesByName("Excel").Any())
            {
                MessageBox.Show("Закройте 'Excel' и повторите попытку");
            }
            else
            {
                if (!CheckFile())
                {
                    DailyReport();
                }
                else
                {
                    MessageBox.Show("В ходе проверки файлов обнаружены ошибки. Список ошибок приведен ниже.");
                    dayReportPB.Value = dayReportPB.Maximum;
                }
            }

        }

        public void Over10Report()
        {
            int[] stat_col = new int[] { 8, 17, 26, 39, 44, 47 };
            int i, j, k, nFile;
            File.Copy(over10OutTemplates, over10OutPath, true);
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
          //  ExcelFile oFile = ExcelFile.Load(over10OutPath);
            over10PB.Value = 0;
            for (nFile = 0; nFile < curWeekList.Count; nFile++)
            {
                ExcelFile curFile = ExcelFile.Load(curWeekList[nFile].ToString());
                ExcelFile prevFile = ExcelFile.Load(prevWeekList[nFile].ToString());
                int row = 4, district = nFile;

                for (k = stat_col.GetLowerBound(0); k <= stat_col.GetUpperBound(0); k++)
                {
                    if (k == stat_col.GetLowerBound(0))
                    {
                        i = 2;
                    }
                    else
                    {
                        if (k == stat_col.GetUpperBound(0))
                        {
                            i = stat_col[k - 1] + 1;
                        }
                        else
                        {
                            i = stat_col[k - 1] + 3;
                        }
                    }
                    while (i < stat_col[k])
                    {
                        String product, chain, store, min_max;
                        float before, after, diff;
                        
                        chain = curFile.Worksheets.ActiveWorksheet.Cells[2, i].GetFormattedValue();
                        store = curFile.Worksheets.ActiveWorksheet.Cells[3, i].GetFormattedValue();
                        min_max = curFile.Worksheets.ActiveWorksheet.Cells[4, i].GetFormattedValue();

                        for (j = 0; j < rowNum; j++)
                        {
                            string curVal = curFile.Worksheets.ActiveWorksheet.Cells[j + rowOffset, i].GetFormattedValue();
                            string prevVal = prevFile.Worksheets.ActiveWorksheet.Cells[j + rowOffset, i].GetFormattedValue();
                            if (String.IsNullOrEmpty(curVal) && String.IsNullOrEmpty(prevVal))
                            {
                                diff = 0;
                            }
                            else
                            {
                                if (String.IsNullOrEmpty(curVal))
                                {
                                    diff = -100;
                                }
                                else 
                                {
                                    if (String.IsNullOrEmpty(prevVal))
                                    {
                                        diff = 100;
                                    }
                                    else
                                    {
                                        diff = (float.Parse(curVal) - float.Parse(prevVal)) / float.Parse(prevVal) * 100;
                                        if (diff >= 10)
                                        {
                                            product = curFile.Worksheets.ActiveWorksheet.Cells[j + rowOffset, 1].GetFormattedValue();
                                            before = float.Parse(prevFile.Worksheets.ActiveWorksheet.Cells[j + rowOffset, i].GetFormattedValue());
                                            after = float.Parse(curFile.Worksheets.ActiveWorksheet.Cells[j + rowOffset, i].GetFormattedValue());


                                            WriteToOver10(row, district, product, chain, store, min_max, before, after, diff);
                                            row++;
                                        }
                                    }
                                }
                            }
                           

                        }
                        i++;
                    }
                }
                over10PB.Value += 4;
            }
          // oFile.Save(over10OutPath);
        }

        public void WriteToOver10(int row, int district, String product, String chain, String store, String min_max, float before, float after, float diff)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile oFile = ExcelFile.Load(over10OutPath);

            oFile.Worksheets.ActiveWorksheet.Cells[row, district*8].Value = product;
            oFile.Worksheets.ActiveWorksheet.Cells[row, district * 8 + 1].Value = chain;
            oFile.Worksheets.ActiveWorksheet.Cells[row, district * 8 + 2].Value = store;
            oFile.Worksheets.ActiveWorksheet.Cells[row, district * 8 + 3].Value = min_max;
            oFile.Worksheets.ActiveWorksheet.Cells[row, district * 8 + 4].Value = before;
            oFile.Worksheets.ActiveWorksheet.Cells[row, district * 8 + 5].Value = after;
            oFile.Worksheets.ActiveWorksheet.Cells[row, district * 8 + 6].Value = diff;

            oFile.Save(over10OutPath);
        }
        
        public void WeekReport()
        {
            int[] dayColNum = new int[] { 2, 5, 8, 11, 14, 17 };
            int[] reportColNum = new int[] { 2, 8, 14, 20, 26, 32 };
            bool isPercent = false;

            File.Copy(weekOutTemplates, weekOutPath, true);
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile oFile = ExcelFile.Load(weekOutPath);
            TreeNode efile = new TreeNode(Path.GetFileName(weekOutPath));
            weekReportPB.Value = 0;

            for (int i = dayColNum.GetLowerBound(0); i <= dayColNum.GetUpperBound(0); i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    int colNum = reportColNum[i] + j;
                   if ((colNum == 7) || (colNum == 13) || (colNum == 19) || (colNum == 25) || (colNum == 31) ||
                   (colNum == 37))
                    {
                        isPercent = true;
                    }
                    if (j%2 == 0)
                    {
                        WriteColumn(colNum, LoadFromFile(dayColNum[i]+j/2, weekList[weekList.Count - 1].ToString()), oFile);
                    }
                    else
                    {
                        WriteColumn(colNum, CompareTwoDays(LoadFromFile(dayColNum[i]+ (int)Math.Floor((double)j / 2), weekList[weekList.Count - 1].ToString()), LoadFromFile(dayColNum[i]+(int)Math.Floor((double)j / 2), weekList[weekList.Count - 2].ToString()), isPercent), oFile);
                    }
                }
                weekReportPB.Value += 17;

            }
            oFile.Save(weekOutPath);
            efile.Nodes.Add(new TreeNode("Ошибок нет"));
            weekReportLog.Nodes.Add(efile);
            weekReportLog.ExpandAll();
            MessageBox.Show("Отчёт готов");
        }

        public float[] LoadFromFile(int colNum, String filePath)
        {
            float[] colVals = new float[rowNum];

                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile ef = ExcelFile.Load(filePath);
                ExcelWorksheet ws = ef.Worksheets.ActiveWorksheet;

                for (int j = 0; j < rowNum; j++)
                {
                    colVals[j] = float.Parse(ws.Cells[j + rowOffset, colNum].Value.ToString());
                }
               
            return colVals;
        }

        public float[] CompareTwoDays(float[] curDay, float[] prevDay, bool isPerscent)
        {
            float[] resVals = new float[rowNum];
            
            for (int j = 0; j < rowNum; j++)
            {
                if ( isPerscent == true) 
                {
                    resVals[j] = curDay[j] - prevDay[j];
                }
                else
                {
                    resVals[j] = (curDay[j] - prevDay[j])/prevDay[j]*100;
                }
            }

            return resVals;
        }

        public float[] AvgDaySum(int colNum)
        {
            float[,] colVals = new float[list.Count,rowNum];
            float[] AvgVals = new float[rowNum];
            int k = 0;
            int[] emptyRows = Enumerable.Repeat(26, rowNum).ToArray(); // счетчик для непустых строк в файле
            foreach (String file in list)
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile ef = ExcelFile.Load(file);
                ExcelWorksheet ws = ef.Worksheets.ActiveWorksheet;
                
                for (int j = 0; j < rowNum; j++)
                {
                    string _colVal = ws.Cells[j+rowOffset, colNum].GetFormattedValue();
                    if (String.IsNullOrEmpty(_colVal))
                    {
                        emptyRows[j]--;
                    }
                    else
                    {
                        colVals[k, j] = float.Parse(ws.Cells[j + rowOffset, colNum].Value.ToString());
                    }
                }
                
                k++;
            }
            for (int i = 0; i < list.Count; i++)
            {
                
                for (int j = 0; j < rowNum; j++)
                {
                    AvgVals[j] += colVals[i, j];
                }
            }
            for (int j = 0; j < rowNum; j++)
            {
                AvgVals[j] /= emptyRows[j];
            }
            return AvgVals;
        }

        public void WriteColumn(int colNum, float[] vals, ExcelFile oFile)
        {
            //File.Copy(outFile, dayOutPath);
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            //ExcelFile oFile = ExcelFile.Load(dayOutPath);
            // ExcelWorksheet ws = oFile.Worksheets.ActiveWorksheet;

            for (int i = 0; i < rowNum; i++)
            {
                oFile.Worksheets.ActiveWorksheet.Cells[i + rowOffset, colNum].Value = vals[i];
            }
           
        }

        public void DailyReport()
        {
            int[] dayColNum = new int[] { 8, 17, 26, 39, 42, 45 };
            int[] reportColNum = new int[] { 2, 5, 8, 11, 14, 17 };
            dayReportPB.Value = 52;

            File.Copy(dayOutTemplates, dayOutPath, true);
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile oFile = ExcelFile.Load(dayOutPath);
            
            for (int i = dayColNum.GetLowerBound(0); i <= dayColNum.GetUpperBound(0); i++)
            {
                WriteColumn(reportColNum[i], AvgDaySum(dayColNum[i]), oFile);
                WriteColumn(reportColNum[i]+1, AvgDaySum(dayColNum[i]+1), oFile);
                WriteColumn(reportColNum[i]+2, AvgDaySum(dayColNum[i]+2), oFile);
                dayReportPB.Value += 2;
                Application.DoEvents();
            }
            dayReportPB.Value = dayReportPB.Maximum;
            oFile.Save(dayOutPath);
            MessageBox.Show("Отчёт готов");
        }

        public bool CheckFile()
        {
            int[] stat_col = new int[] { 8, 17, 26, 39, 44, 47 };
            int i, j, k;
            bool flag = false;
            dayReportPB.Value = 0;
            foreach (String file in list)
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile ef = ExcelFile.Load(file);
                ExcelWorksheet ws = ef.Worksheets.ActiveWorksheet;
                TreeNode efile = new TreeNode(Path.GetFileName(file));

                for (i = 5; i < 45; i++)
                {
                    for (j = 2; j < 48; j++)
                    {
                        var numberFormat = ws.Cells[i, j].Style.NumberFormat;
                        if ((numberFormat != "0.00") && (numberFormat != "#,##0.00") && (numberFormat != "General") && (numberFormat != "#,##0") && (numberFormat != "0") && (numberFormat != "0.0"))
                        {
                            if (String.IsNullOrEmpty(ws.Cells[i, j].GetFormattedValue()))
                            {
                            }
                            else
                            {
                                flag = true;
                                efile.Nodes.Add("Ячейка [R" + (i + 1) + "C" + (j + 1) + "] имеет не числовой формат. Измените формат ячейки и повторите попытку.");
                            }
                        }
                    }
                }
                for (k = stat_col.GetLowerBound(0); k <= stat_col.GetUpperBound(0); k++)
                {
                    if (k == stat_col.GetLowerBound(0)) { i = 2; }
                    else
                    {
                        if (k == stat_col.GetUpperBound(0))
                        {
                            i = stat_col[k - 1] + 1;
                        }
                        else { i = stat_col[k - 1] + 3; }
                    }
                    while (i < stat_col[k])
                    {
                        for (j = 5; j < 45; j++)
                        {
                            string Min = ws.Cells[j, i].GetFormattedValue();
                            string Max = ws.Cells[j, i + 1].GetFormattedValue();
                            string Min_s = "[R" + (j + 1) + "C" + (i + 1) + "]";
                            string Max_s = "[R" + (j + 1) + "C" + (i + 2) + "]";
                            if ((String.IsNullOrEmpty(Min)) || String.IsNullOrEmpty(Max))
                            {
                                if ((String.IsNullOrEmpty(Min)) && String.IsNullOrEmpty(Max)) { }
                                else
                                {
                                    flag = true;
                                    efile.Nodes.Add(
                                        new TreeNode("Пустой минимум или максимум. Ячейка мин." + Min_s +
                                                     " , ячейка макс." + Max_s));
                                }
                            }
                            else
                            {
                                if (float.Parse(Min) > float.Parse(Max))
                                {
                                    flag = true;
                                    efile.Nodes.Add(new TreeNode("Минимум больше максимума. Ячейка мин." + Min_s + " , ячейка макс." + Max_s));
                                }
                            }
                        }
                        i = i + 2;
                    }

                }
                // после проверки каждого файла
                if (flag == false)
                {
                    efile.Nodes.Add(new TreeNode("Ошибок нет"));
                    Errors.Nodes.Add(efile);
                    Errors.ExpandAll();
                }
                else
                {
                    Errors.Nodes.Add(efile);
                    Errors.ExpandAll();
                }
                dayReportPB.Value += 2;
                Application.DoEvents();

            }


            return flag;
        }

        private void Monitoring_Load(object sender, EventArgs e)
        {

        }
    }
    }
    

