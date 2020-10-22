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
    public partial class AddMaatregel : Form
    {
        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        public AddMaatregel()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = KeuzeMenus.GetInstance();
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewTemplates.DataSource = comunicator.getTemplateTable();
            List<string> disciplinesList = keuzeMenus.GetDisciplinesMenu();
            foreach (string typeString in disciplinesList)
            {
                comboBoxDiscipline.Items.Add(typeString);
            }

        }

        private void dataGridViewTemplates_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string templateId = dataGridViewTemplates.SelectedRows[0].Cells[0].Value.ToString();
            //string ObjectType = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[1].Value.ToString();
            //string ObjectBeschrijving = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[2].Value.ToString();

            Form editTemplates = new EditTemplates();
            editTemplates.Show();

            //Form issueMaatregelen = new IssueMaatregelen(issueId);
            //issueMaatregelen.Show();



        }
    }
}
