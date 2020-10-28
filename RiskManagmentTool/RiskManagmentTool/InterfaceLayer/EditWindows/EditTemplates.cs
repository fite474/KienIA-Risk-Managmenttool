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

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditTemplates : Form
    {
        private Datacomunication comunicator;
        public EditTemplates()
        {
            InitializeComponent();
            comunicator = new Datacomunication();

            LoadData();
        }

        private void LoadData()
        {
            textBoxSelectedIssues.Text = "";


            dataGridViewAddIssue.DataSource = comunicator.GetGevarenTable();
            

            dataGridViewAddGevaar.DataSource = comunicator.GetGevarenTable();

            dataGridViewAddIssue.ClearSelection();

        }

        private void buttonConfirmSelection_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddSelection_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewAddIssue.SelectedRows.Count - 1; i >= 0; i--)
            {
                textBoxSelectedIssues.Text += dataGridViewAddIssue.SelectedRows[i].Cells[0].Value.ToString();
                
                // ...
            }
           // = dataGridViewAddIssue.SelectedRows[0].Cells[0].Value.ToString();
            dataGridViewAddIssue.ClearSelection();
        }

        private void dataGridViewAddIssue_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewAddIssue.ClearSelection();
        }
    }
}
