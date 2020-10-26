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
        private List<string> SelectedMaatregelId;
        private string RisicoID;
        public AddMaatregel(string risicoID, string discipline, string gevaar, string situatie, string gebeurtenis)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = KeuzeMenus.GetInstance();
            SelectedMaatregelId = new List<string>();
            RisicoID = risicoID;
            LoadData();


            textBoxIssueID.Text = risicoID;
            comboBoxDiscipline.SelectedIndex = comboBoxDiscipline.FindStringExact(discipline);
            comboBoxGevaar.SelectedIndex = comboBoxGevaar.FindStringExact(gevaar);
            textBoxSituatie.Text = situatie;
            textBoxGebeurtenis.Text = gebeurtenis;
        }

        private void LoadData()
        {
            dataGridViewTemplates.DataSource = comunicator.GetTemplateTable();
            dataGridViewMaatregelen.DataSource = comunicator.GetMaatregelTable();

            List<string> disciplinesList = keuzeMenus.GetDisciplinesMenu();
            foreach (string typeString in disciplinesList)
            {
                comboBoxDiscipline.Items.Add(typeString);
            }

            List<string> gevarenList = keuzeMenus.GetGevaarTypeMenu();
            foreach (string gevaar in gevarenList)
            {
                comboBoxGevaar.Items.Add(gevaar);
            }

            List<string> maatregelCategoryList = keuzeMenus.GetMaatregelCategoryMenu();
            foreach (string categoryString in maatregelCategoryList)
            {
                comboBoxMaatregelCategorie.Items.Add(categoryString);
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

        private void dataGridViewMaatregelen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string maatregelID = dataGridViewMaatregelen.SelectedRows[0].Cells[0].Value.ToString();
            if (!SelectedMaatregelId.Contains(maatregelID))
            {
                SelectedMaatregelId.Add(maatregelID);
                textBoxSelectedMaatregelen.Text += maatregelID + ", ";
            }
        }


        private void buttonCreateNewMaatregel_Click(object sender, EventArgs e)
        {
            Form editMaatregelen = new EditMaatregelen();
            editMaatregelen.Show();
        }

        private void buttonKoppelSelectedMaatregelen_Click(object sender, EventArgs e)
        {
                foreach (string maatregelId in SelectedMaatregelId)
                {
                    comunicator.AddMaatregelToIssue(RisicoID, maatregelId);
                }
                this.Close();
        }
    }
}
