using System;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using GemBox.Spreadsheet;
using System.Linq;
using System.Diagnostics;

namespace Monitoring
{
    public partial class Monitoring : Form
    {
        
        ArrayList list = new ArrayList();
        int rowNum = 40;  // Кол-во строк в файле
        int rowOffset = 5; // Смещение нужных строк в файле
        static string outPathDay = Directory.GetCurrentDirectory() + @"\day_out\";
        static string outPathWeek = Directory.GetCurrentDirectory() + @"\week_out\";
        string dayOutTemplates = Directory.GetCurrentDirectory() + @"\templates\day_report.xlsx";
        string weekOutTemplates = Directory.GetCurrentDirectory() + @"\templates\week_report.xlsx";
        string dayOutPath = outPathDay + "day_" + DateTime.Now.ToString("dd.MM.yyyy") + ".xlsx";
        string weekOutPath = outPathWeek + "week_" + DateTime.Now.ToString("dd.MM.yyyy") + ".xlsx";
        public Monitoring()
        {
            InitializeComponent();
            AddFiles.Click += AddFiles_Click;
            Check.Click += CheckAndReporting;
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
                    Rayons.Items.Add(Path.GetFileName(file));
                    list.Add(file);
                    list.Sort();
                }
            }
        }

        public void WeekReport()
        {
            int[] dayColNum = new int[] { 2, 5, 8, 11, 14, 17 };
            int[] reportColNum = new int[] { 2, 8, 14, 20, 26, 32 };

            File.Copy(weekOutTemplates, weekOutPath);
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile oFile = ExcelFile.Load(weekOutPath);

            for (int i = dayColNum.GetLowerBound(0); i <= dayColNum.GetUpperBound(0); i++)
            {
                WriteColumn(reportColNum[i], AvgWednesday(dayColNum[i],1), oFile);
                WriteColumn(reportColNum[i] + 1, CompareWednesday(reportColNum[i] + 1, AvgWednesday(dayColNum[i], 1), AvgWednesday(dayColNum[i], 2)), oFile);
                WriteColumn(reportColNum[i] + 2, AvgWednesday(dayColNum[i] + 1,1), oFile);
                WriteColumn(reportColNum[i] + 3, CompareWednesday(reportColNum[i] + 3, AvgWednesday(dayColNum[i] + 1, 1), AvgWednesday(dayColNum[i] + 1, 2)), oFile);
                WriteColumn(reportColNum[i] + 4, AvgWednesday(dayColNum[i] + 2,1), oFile);
                WriteColumn(reportColNum[i] + 5, CompareWednesday(reportColNum[i] + 5, AvgWednesday(dayColNum[i]+2,1), AvgWednesday(dayColNum[i] + 2, 2)), oFile);

            }
            oFile.Save(weekOutPath);
        }

        public float[] AvgWednesday(int colNum, int elementOffset)
        {
            float[] colVals = new float[rowNum];

                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                ExcelFile ef = ExcelFile.Load(list[list.Count-elementOffset].ToString());
                ExcelWorksheet ws = ef.Worksheets.ActiveWorksheet;

                for (int j = 0; j < rowNum; j++)
                {
                    colVals[j] = float.Parse(ws.Cells[j + rowOffset, colNum].Value.ToString());
                }
               
            return colVals;
        }

        public float[] CompareWednesday(int colNum, float[] curDay, float[] prevDay)
        {
            float[] resVals = new float[rowNum];
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile ef = ExcelFile.Load(list[list.Count-2].ToString());
            ExcelWorksheet ws = ef.Worksheets.ActiveWorksheet;

            for (int j = 0; j < rowNum; j++)
            {
                if ((colNum == 7) || (colNum == 13) || (colNum == 19) || (colNum == 25) || (colNum == 31) ||
                    (colNum == 37))
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

            File.Copy(dayOutTemplates, dayOutPath);
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile oFile = ExcelFile.Load(dayOutPath);
            
            for (int i = dayColNum.GetLowerBound(0); i <= dayColNum.GetUpperBound(0); i++)
            {
                WriteColumn(reportColNum[i], AvgDaySum(dayColNum[i]), oFile);
                WriteColumn(reportColNum[i]+1, AvgDaySum(dayColNum[i]+1), oFile);
                WriteColumn(reportColNum[i]+2, AvgDaySum(dayColNum[i]+2), oFile);
            }
            oFile.Save(dayOutPath);
        }
       
        public void CheckAndReporting(object sender, System.EventArgs e)
        {
            if (Process.GetProcessesByName("Excel").Any())
            {
                MessageBox.Show("Закройте 'Excel' и повторите попытку");
            }
            else
            {
                int[] stat_col = new int[] { 8, 17, 26, 39, 44, 47};
                int i, j, k;
                bool flag = false;
                foreach (String file in list)
                {
                    SpreadsheetInfo.SetLicense("");
                    ExcelFile ef = ExcelFile.Load(file);
                    ExcelWorksheet ws = ef.Worksheets.ActiveWorksheet;
                    TreeNode efile = new TreeNode(Path.GetFileName(file));

                    for (i = 5; i < 45; i++)
                    {
                        for (j = 2; j < 48; j++)
                        {
                            ws.Cells[i, j].Style.NumberFormat = "0.00";
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
                                    if ((String.IsNullOrEmpty(Min)) && String.IsNullOrEmpty(Max))
                                    {
                                    }
                                    else
                                    {
                                        flag = true;
                                        efile.Nodes.Add(new TreeNode("Пустой минимум или максимум. Ячейка мин." + Min_s + " , ячейка макс." + Max_s));

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
                    if (flag == false)
                    {
                        efile.Nodes.Add(new TreeNode("Ошибок нет"));
                        Errors.Nodes.Add(efile);
                    }
                    else { Errors.Nodes.Add(efile); }
                   // ef.Save(file);
               }
                //DailyReport();
                WeekReport();
               // WriteColumn(2, AvgDaySum(8), dayOutTemplates);
            }

            }
        }
    }
    

