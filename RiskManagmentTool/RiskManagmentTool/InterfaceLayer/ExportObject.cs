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
            dataGridViewCompleteBeoordeling.DataSource = comunicator.GetObjectIssues(ObjectID);
            

        }

        private void buttonConfirmExport_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //int i = 0;
            //int j = 0;

            for (int i = 1; i < dataGridViewCompleteBeoordeling.Columns.Count + 1; i++)
            {
                xlWorkSheet.Cells[1, i] = dataGridViewCompleteBeoordeling.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i <= dataGridViewCompleteBeoordeling.RowCount - 1; i++)
            {
                for (int j = 0; j <= dataGridViewCompleteBeoordeling.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGridViewCompleteBeoordeling[j, i];
                    xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }

            xlWorkBook.SaveAs("csharp.net-informations.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file c:\\csharp.net-informations.xls");
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
