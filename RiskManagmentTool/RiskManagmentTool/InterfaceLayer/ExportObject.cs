using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer
{
    public partial class ExportObject : Form
    {
        private Datacomunication comunicator;
        private string ObjectID;
        public ExportObject(string objectID)//DataTable data)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            ObjectID = objectID;
            LoadData();//;data);
        }

        private void LoadData()//DataTable data)
        {
            //dataGridViewCompleteBeoordeling.DataSource = data;
            //dataGridViewCompleteBeoordeling.DataSource = comunicator.GetObjectIssues(ObjectID);
            dataGridViewCompleteBeoordeling.DataSource = comunicator.GetExportView(ObjectID);
            textBoxObjectName.Text = comunicator.GetObjectNameById(ObjectID);

        }

        private void buttonConfirmExport_Click(object sender, EventArgs e)
        {
            string userInputFileName = textBoxUserInputFileName.Text;
            if (userInputFileName.Equals(""))
            {
                userInputFileName = "No Title";
            }
            userInputFileName += ".xls";
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //uitlijnen text center
            Microsoft.Office.Interop.Excel.Range last = xlWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.get_Range("A1", last);
            range.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            
            //uitlijnen text boven
            range.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;


            //int i = 0;
            //int j = 0;


            //maak alle column headers aan in excel sheet
            for (int i = 1; i < dataGridViewCompleteBeoordeling.Columns.Count + 1; i++)
            {
                xlWorkSheet.Cells[1, i] = dataGridViewCompleteBeoordeling.Columns[i - 1].HeaderText;
                //xlWorkSheet.Cells.ColumnWidth = 50;
                
            }


            int imageColumn = dataGridViewCompleteBeoordeling.ColumnCount - 1;

            //schrijf all data per rij in excel sheet
            for (int i = 0; i <= dataGridViewCompleteBeoordeling.RowCount - 1; i++)
            {
                for (int j = 0; j <= dataGridViewCompleteBeoordeling.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridViewCompleteBeoordeling[j, i];
                    string text = cell.Value.ToString();
                    string correctText = text.Replace("*ENTER*", "\n\n");
                    if (j == imageColumn)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                            float Left = (float)((double)oRange.Left);
                            float Top = (float)((double)oRange.Top);
                            const float ImageSize = 128;
                            xlWorkSheet.Shapes.AddPicture(text, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
                            //xlWorkSheet.Shapes.AddPicture(text, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 300, 45);
                            // xlWorkSheet.Cells[i + 2, j + 1] =
                            Console.WriteLine("row = " + i);
                        }
                        catch (Exception err)
                        {
                            xlWorkSheet.Cells[i + 2, j + 1] = correctText;
                            Console.WriteLine(err);
                        }
                    }
                    else
                    {
                        xlWorkSheet.Cells[i + 2, j + 1] = correctText;//cell.Value;
                    }
                    

                }
            }
            //xlWorkSheet.Columns.st = 200;// AllocatedRange.AutoFitRows();
            //"csharp.net-informations.xls"
            xlWorkBook.SaveAs(userInputFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file at c:\\Documents\\" + userInputFileName);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        //Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
        //// creating new WorkBook within Excel application  
        //Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
        //// creating new Excelsheet in workbook  
        //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
        //// see the excel sheet behind the program  
        //excel.Visible = true;
        //// get the reference of first sheet. By default its name is Sheet1.  
        //// store its reference to worksheet  
        //worksheet = workbook.Sheets[0];
        //worksheet = workbook.ActiveSheet;
        //// changing the name of active sheet  
        //worksheet.Name = "Exported from gridview";
        //// storing header part in Excel  
        //for (int i = 1; i < dataGridViewCompleteBeoordeling.Columns.Count + 1; i++)
        //{
        //    worksheet.Cells[1, i] = dataGridViewCompleteBeoordeling.Columns[i - 1].HeaderText;
        //}
        //// storing Each row and column value to excel sheet  
        //for (int i = 0; i < dataGridViewCompleteBeoordeling.Rows.Count - 1; i++)
        //{
        //    for (int j = 0; j < dataGridViewCompleteBeoordeling.Columns.Count; j++)
        //    {
        //        worksheet.Cells[i + 2, j + 1] = dataGridViewCompleteBeoordeling.Rows[i].Cells[j].Value.ToString();
        //    }
        //}
        //// save the application  
        //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        //// Exit from the application  
        //excel.Quit();
    //}
    
    }
}
