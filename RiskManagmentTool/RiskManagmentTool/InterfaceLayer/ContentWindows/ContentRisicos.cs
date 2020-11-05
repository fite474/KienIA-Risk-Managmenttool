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
        public ContentRisicos()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            LoadData();

        }

        private void LoadData()
        {
            dataGridViewRisicos.DataSource = comunicator.GetGevarenTable();

        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form editRisicosForm = new EditRisicos();

            editRisicosForm.Show();
        }

        private void dataGridViewRisicos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string riskId = dataGridViewRisicos.SelectedRows[0].Cells[0].Value.ToString();
            string riskBeschrijving = dataGridViewRisicos.SelectedRows[0].Cells[1].Value.ToString();
            string riskGevolg = dataGridViewRisicos.SelectedRows[0].Cells[2].Value.ToString();
            //string riskDiscipline = dataGridViewRisicos.SelectedRows[0].Cells[3].Value.ToString();
            //string riskGebruiksfase = dataGridViewRisicos.SelectedRows[0].Cells[4].Value.ToString();
            //string riskGebruiker = dataGridViewRisicos.SelectedRows[0].Cells[5].Value.ToString();
            //string riskGevarenzone = dataGridViewRisicos.SelectedRows[0].Cells[6].Value.ToString();
            //string riskSeverity = dataGridViewRisicos.SelectedRows[0].Cells[7].Value.ToString();
            //string riskFrequency = dataGridViewRisicos.SelectedRows[0].Cells[8].Value.ToString();
            //string riskProbability = dataGridViewRisicos.SelectedRows[0].Cells[9].Value.ToString();
            //string riskAvoidance = dataGridViewRisicos.SelectedRows[0].Cells[10].Value.ToString();

            Form editRisicosForm = new EditRisicos(riskBeschrijving,
                            riskGevolg);//,
                            //riskDiscipline,
                            //riskGebruiksfase,
                            //riskGebruiker,
                            //riskGevarenzone);
            //                riskSeverity,
            //                riskFrequency,
            //                riskProbability,
            //                riskAvoidance);
            editRisicosForm.Show();
            //RefreshTable();


        }

        private void dataGridViewRisicos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (dataGridViewRisicos.ColumnCount - 1); i++)
            {
                dataGridViewRisicos.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells );
                if (dataGridViewRisicos.Columns[i + 1].Width > 400)
                {
                    dataGridViewRisicos.Columns[i + 1].Width = 400;
                }
            }
        }
    }
}
