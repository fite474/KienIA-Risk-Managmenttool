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
using RiskManagmentTool.InterfaceLayer.AddWindows;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditObjecten : Form
    {
        private Datacomunication comunicator;
        private string ObjectNaam;
        private KeuzeMenus keuzeMenus;


        public EditObjecten()
        {
            InitializeComponent();
            SetInstellingen();
        }
        public EditObjecten(string projectNaam,
                            string objectNaam,
                            string objectType,
                            string objectOmschrijving)
        {

            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            LoadMenus();
            this.ObjectNaam = objectNaam;
            textBoxProjectNaam.Text = projectNaam;
            textBoxObjectNaam.Text = ObjectNaam;
            textBoxOmschrijving.Text = objectOmschrijving;
            comboBoxObjectType.SelectedIndex = comboBoxObjectType.FindStringExact(objectType);
            
            LoadData();
            SetInstellingen();

            //textBoxDiscipline.Text = riskDicipline;
            //textBoxGebruiksfase.Text = riskGebruiksfase;
            //textBoxBedienvorm.Text = riskGebruiker;
            //textBoxRiskGevarenzone.Text = riskGevarenzone;
        }

        private void LoadMenus()
        {
            List<string> typeObjectList = keuzeMenus.GetTypeObjectMenu();
            foreach (string typeString in typeObjectList)
            {
                comboBoxObjectType.Items.Add(typeString);
            }


        }
        private void LoadData()
        {
            //dataGridViewGekoppeldeIssues.DataSource = comunicator.getObjectIssues(ObjectNaam);
            ShowSolvedIssues();

        }

        private void ShowSolvedIssues()
        {
            //int i = 0;
            //foreach (DataGridViewRow row in dataGridViewGekoppeldeIssues.Rows)
            //{
            //    if (i > 2)//row.Cells[10].ToString())
            //    {
            //        row.DefaultCellStyle.ForeColor = Color.Red;
                    
            //    }
            //    i++;
            //}

        }

        private void SetInstellingen()
        {

            KeuzeMenus instellingen = new KeuzeMenus();
            List<CheckedListBox> menuBox = instellingen.GetKeuzeMenus();
            for (int i = 0; i < menuBox.Count; i++)
            {
                
                
                tabPage3.Controls.Add(menuBox[i]);
            }
            
            
        }

        private void buttonIssuesOplossen_Click(object sender, EventArgs e)
        {
            Form issueMaatregelen = new IssueMaatregelen();
            issueMaatregelen.Show();
        }

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            
            Form addTemplate = new AddTemplate();
            addTemplate.Show();
        }

        private void dataGridViewGekoppeldeIssues_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string issueId = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[0].Value.ToString();
            //string ObjectType = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[1].Value.ToString();
            //string ObjectBeschrijving = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[2].Value.ToString();

            Form issueMaatregelen = new IssueMaatregelen(issueId);
            issueMaatregelen.Show();



        }

        private void buttonAddRisico_Click(object sender, EventArgs e)
        {
            Form addRisico = new AddRisico(ObjectNaam);
            addRisico.Show();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Form exportObject = new ExportObject();
            exportObject.Show();
        }
    }
}
