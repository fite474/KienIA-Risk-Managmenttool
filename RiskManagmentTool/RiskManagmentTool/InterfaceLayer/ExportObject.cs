using System;
using System.Data;
using System.Windows.Forms;
using RiskManagmentTool.LogicLayer;
using Syncfusion.XlsIO;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace RiskManagmentTool.InterfaceLayer
{
    public partial class ExportObject : Form
    {
        private Datacomunication comunicator;
        private string ObjectID;

        private BindingSource completeExportData;

        private enum ExportMode
        {
            emptyExcel,
            KienIA_Template,
            RWS_Template
        }







        public ExportObject(string objectID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            ObjectID = objectID;
            LoadData();
            checkedListBoxTemplate.SetItemChecked(1, true);
        }

        private void LoadData()
        {

            //completeExportData = comunicator.GetExportView(ObjectID); ;
            completeExportData = comunicator.GetExportViewRWSTemplate(ObjectID); ;

            advancedDataGridViewCompleteBeoordeling.DataSource = completeExportData;


            //dataGridViewCompleteBeoordeling.DataSource = comunicator.GetExportView(ObjectID);
            textBoxObjectName.Text = comunicator.GetObjectNameById(ObjectID);
        }








        //backup
        // private void buttonConfirmExport_Click(object sender, EventArgs e)
        //{
           
        //    string userInputFileName = textBoxUserInputFileName.Text;
        //    if (userInputFileName.Equals(""))
        //    {
        //        userInputFileName = "No Title";
        //    }
        //    userInputFileName += ".xls";
        //    Microsoft.Office.Interop.Excel.Application xlApp;
        //    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        //    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        //    object misValue = System.Reflection.Missing.Value;

        //    xlApp = new Microsoft.Office.Interop.Excel.Application();
        //    xlWorkBook = xlApp.Workbooks.Add(misValue);

        //    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //    //uitlijnen text center
        //    Microsoft.Office.Interop.Excel.Range last = xlWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
        //    Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.get_Range("A1", last);
        //    range.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

        //    //uitlijnen text boven
        //    range.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;



        //    //maak alle column headers aan in excel sheet
        //    for (int i = 1; i < advancedDataGridViewCompleteBeoordeling.Columns.Count + 1; i++)
        //    {
        //        xlWorkSheet.Cells[1, i] = advancedDataGridViewCompleteBeoordeling.Columns[i - 1].HeaderText;
        //        //xlWorkSheet.Cells.ColumnWidth = 50;

        //    }


        //    int imageColumn = advancedDataGridViewCompleteBeoordeling.ColumnCount - 1;

        //    //schrijf all data per rij in excel sheet
        //    for (int i = 0; i <= advancedDataGridViewCompleteBeoordeling.RowCount - 1; i++)
        //    {
        //        for (int j = 0; j <= advancedDataGridViewCompleteBeoordeling.ColumnCount - 1; j++)
        //        {
        //            DataGridViewCell cell = advancedDataGridViewCompleteBeoordeling[j, i];
        //            string text = (cell.Value != null)? cell.Value.ToString() : "";
        //            string correctText = text.Replace("*ENTER*", "\n\n");
        //            if (j == imageColumn)
        //            {
        //                try//TODO fix image column
        //                {
        //                    Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
        //                    float Left = (float)((double)oRange.Left);
        //                    float Top = (float)((double)oRange.Top);
        //                    const float ImageSize = 128;

        //                    //TODO change add picture to byte[]
        //                    xlWorkSheet.Shapes.AddPicture(text, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
        //                    //xlWorkSheet.Shapes.AddPicture(text, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 300, 45);
        //                    // xlWorkSheet.Cells[i + 2, j + 1] =
        //                    Console.WriteLine("row = " + i);
        //                }
        //                catch (Exception err)
        //                {
        //                    xlWorkSheet.Cells[i + 2, j + 1] = correctText;
        //                    Console.WriteLine(err);
        //                }
        //            }
        //            else
        //            {
        //                xlWorkSheet.Cells[i + 2, j + 1] = correctText;//cell.Value;
        //            }


        //        }
        //    }
        //    //xlWorkSheet.Columns.st = 200;// AllocatedRange.AutoFitRows();
        //    //"csharp.net-informations.xls"

        //    //TODO fix saving location on any pc
        //    try
        //    {
        //        xlWorkBook.SaveAs(userInputFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        //        xlWorkBook.Close(true, misValue, misValue);
        //        xlApp.Quit();

        //        releaseObject(xlWorkSheet);
        //        releaseObject(xlWorkBook);
        //        releaseObject(xlApp);

        //        MessageBox.Show("Excel file created , you can find the file at 'this pc/documents/'" + userInputFileName);
        //    }
        //    catch (Exception error)
        //    {
        //        MessageBox.Show(error.ToString() + "\n\n error code: export 129");

        //    }

        //}


        private Microsoft.Office.Interop.Excel.Workbook GetTemplate(Application xlApp)
        {
            Microsoft.Office.Interop.Excel.Workbook template;
            switch (this.checkedListBoxTemplate.CheckedIndices[0])
            {
                case 0://KienIA template, start without template
                    template = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
                    break;
                case 1://RWS tempalte
                    string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string xslLocation = Path.Combine(executableLocation, "excelTemplates\\template 20141210 V1_1 RWS.xlsm");
                    template = xlApp.Workbooks.Add(xslLocation);
                    break;
                default:
                    template = null;
                    MessageBox.Show("Error selecting workbook ,130");
                    break;
            }

            return template;
        }




        private void buttonConfirmExport_Click(object sender, EventArgs e)
        {
           // this.ExportToExcel();

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
            //  xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkBook = GetTemplate(xlApp);//xlApp.Workbooks.Add("template 20141210 V1_1 RWS.xlsm");

            //bepalen op welke pagina geexporteerd zal worden
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //uitlijnen text center
            Microsoft.Office.Interop.Excel.Range last = xlWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
            Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.get_Range("A1", last);



            //maak alle column headers aan in excel sheet
            for (int i = 1; i < advancedDataGridViewCompleteBeoordeling.Columns.Count + 1; i++)
            {
                xlWorkSheet.Cells[1, i] = advancedDataGridViewCompleteBeoordeling.Columns[i - 1].HeaderText;
            }


            int imageColumn = advancedDataGridViewCompleteBeoordeling.ColumnCount - 1;

            //schrijf all data per rij in excel sheet
            for (int i = 0; i <= advancedDataGridViewCompleteBeoordeling.RowCount - 1; i++)
            {
                for (int j = 0; j <= advancedDataGridViewCompleteBeoordeling.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = advancedDataGridViewCompleteBeoordeling[j, i];
                    string text = (cell.Value != null)? cell.Value.ToString() : "";
                    string correctText = text.Replace("*ENTER*", "\n\n");
                    if (j == imageColumn)
                    {
                        try//TODO fix image column
                        {
                            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                            float Left = (float)((double)oRange.Left);
                            float Top = (float)((double)oRange.Top);
                            const float ImageSize = 128;

                            //TODO change add picture to byte[]
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
                        //xlWorkSheet.Cells[i + 2, j + 1] = correctText;
                        xlWorkSheet.Cells[i + 2, j + 1] = correctText;

                    }


                }
            }
            //xlWorkSheet.Columns.st = 200;// AllocatedRange.AutoFitRows();
            //"csharp.net-informations.xls"

            //TODO fix saving location on any pc
            try
            {
                xlWorkBook.SaveAs(userInputFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("Excel file created , you can find the file at 'this pc/documents/'" + userInputFileName);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString() + "\n\n error code: export 129");

            }

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

        private void advancedDataGridViewIssueMaatregelen_FilterStringChanged(object sender, EventArgs e)
        {
            this.completeExportData.Filter = this.advancedDataGridViewCompleteBeoordeling.FilterString;
        }

        private void advancedDataGridViewIssueMaatregelen_SortStringChanged(object sender, EventArgs e)
        {
            this.completeExportData.Sort = this.advancedDataGridViewCompleteBeoordeling.SortString;
        }

        private void advancedDataGridViewCompleteBeoordeling_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (advancedDataGridViewCompleteBeoordeling.ColumnCount - 2); i++)
            {
                advancedDataGridViewCompleteBeoordeling.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (advancedDataGridViewCompleteBeoordeling.Columns[i + 1].Width > 400)
                {
                    advancedDataGridViewCompleteBeoordeling.Columns[i + 1].Width = 400;
                }
            }

            advancedDataGridViewCompleteBeoordeling.ClearSelection();
        }

        private void checkedListBoxTemplate_SelectedValueChanged(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(
            () => updateDatagrid()));
           
            
        }

        private void updateDatagrid()
        {
            switch (this.checkedListBoxTemplate.CheckedIndices[0])
            {
                case 0://KienIA template
                    completeExportData = comunicator.GetExportView(ObjectID); ;
                    advancedDataGridViewCompleteBeoordeling.DataSource = completeExportData;
                    break;
                case 1://RWS tempalte
                    completeExportData = comunicator.GetExportViewRWSTemplate(ObjectID); ;
                    advancedDataGridViewCompleteBeoordeling.DataSource = completeExportData;
                    break;
                default:

                    MessageBox.Show("Error switiching templates data ,131");
                    break;
            }
        }
    }
}
