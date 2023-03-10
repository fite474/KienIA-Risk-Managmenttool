using System;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentRisicos : Form
    {
        private Datacomunication comunicator;

        private BindingSource gevarenData;

        private string objectId = "-1";

        public ContentRisicos()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
        }

        private void LoadData()
        {
            gevarenData = comunicator.GetGlobalGevarenTable();
            advancedDataGridViewGevaren.DataSource = gevarenData;
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form editRisicosForm = new EditRisicos(objectId);

            editRisicosForm.ShowDialog();
            LoadData();
        }

        private void advancedDataGridViewGevaren_SortStringChanged(object sender, EventArgs e)
        {
            this.gevarenData.Sort = this.advancedDataGridViewGevaren.SortString;
        }

        private void advancedDataGridViewGevaren_FilterStringChanged(object sender, EventArgs e)
        {
            this.gevarenData.Filter = this.advancedDataGridViewGevaren.FilterString;
        }

        private void advancedDataGridViewGevaren_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (advancedDataGridViewGevaren.ColumnCount - 1); i++)
            {
                advancedDataGridViewGevaren.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (advancedDataGridViewGevaren.Columns[i + 1].Width > 400)
                {
                    advancedDataGridViewGevaren.Columns[i + 1].Width = 400;
                }
            }

            advancedDataGridViewGevaren.ClearSelection();
            Cursor.Current = Cursors.Default;
        }

        private void advancedDataGridViewGevaren_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string gevaarId = advancedDataGridViewGevaren.SelectedRows[0].Cells[0].Value.ToString();


                Form editRisicosForm = new EditRisicos(gevaarId, "-1");
                editRisicosForm.ShowDialog();
                LoadData();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }

        }

        private void ContentRisicos_Load(object sender, EventArgs e)
        {
                LoadData();
        }
    }
}
