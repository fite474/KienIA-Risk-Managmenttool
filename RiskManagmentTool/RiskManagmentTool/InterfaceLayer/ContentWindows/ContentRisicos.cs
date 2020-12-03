using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentRisicos : Form
    {
        private Datacomunication comunicator;

        private BindingSource gevarenData;

        public ContentRisicos()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            //LoadData();

        }

        private void LoadData()
        {
            //dataGridViewRisicos.DataSource = comunicator.GetGevarenTable();
            gevarenData = comunicator.GetGevarenTable();

            advancedDataGridViewGevaren.DataSource = gevarenData;//comunicator.GetGevarenTable();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form editRisicosForm = new EditRisicos();

            editRisicosForm.Show();
        }

        //private void dataGridViewRisicos_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    string gevaarId = dataGridViewRisicos.SelectedRows[0].Cells[0].Value.ToString();


        //    Form editRisicosForm = new EditRisicos(gevaarId);
        //    editRisicosForm.ShowDialog();
        //    LoadData();


        //    //Form editRisicosForm = new EditRisicos(riskBeschrijving,
        //    //                riskGevolg);//,
        //    //                //riskDiscipline,
        //    //                //riskGebruiksfase,
        //    //                //riskGebruiker,
        //    //                //riskGevarenzone);
        //    ////                riskSeverity,
        //    ////                riskFrequency,
        //    ////                riskProbability,
        //    ////                riskAvoidance);
        //    //editRisicosForm.Show();
        //    //RefreshTable();


        //}

        //private void dataGridViewRisicos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    for (int i = 0; i < (dataGridViewRisicos.ColumnCount - 1); i++)
        //    {
        //        dataGridViewRisicos.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells );
        //        if (dataGridViewRisicos.Columns[i + 1].Width > 400)
        //        {
        //            dataGridViewRisicos.Columns[i + 1].Width = 400;
        //        }
        //    }

        //    dataGridViewRisicos.ClearSelection();
        //}

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
                string gevaarId = advancedDataGridViewGevaren.SelectedRows[0].Cells[0].Value.ToString();


                Form editRisicosForm = new EditRisicos(gevaarId);
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
