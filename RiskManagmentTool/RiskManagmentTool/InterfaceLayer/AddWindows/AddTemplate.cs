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
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    public partial class AddTemplate : Form
    {
        private Datacomunication comunicator;
        public AddTemplate()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewTemplates.DataSource = comunicator.getTemplateTable();
            for (int i = 0; i < checkedListBoxSelectOptions.Items.Count; i++)
            {
                checkedListBoxSelectOptions.SetItemCheckState(i, CheckState.Checked);
            }

        }

        private void buttonAutoSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxObjectEigenschappen.Items.Count; i++)
            {
                checkedListBoxObjectEigenschappen.SetItemCheckState(i, CheckState.Checked);
            }
            dataGridViewSelectedTemplates.DataSource = comunicator.getTemplateTable();
            dataGridViewTemplates.DataSource = null;
        }

        private void buttonKoppelSelectie_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonVerifieerKoppeling_Click(object sender, EventArgs e)
        {
            Form issueMaatregelen = new IssueMaatregelen();
            issueMaatregelen.Show();
        }
    }
}
