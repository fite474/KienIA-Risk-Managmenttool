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
        private string ObjectID;
        private KeuzeMenus keuzeMenus;


        public EditObjecten()
        {
            InitializeComponent();
            SetInstellingen();
        }
        public EditObjecten(string objectID,
                            string projectNaam,
                            string objectNaam,
                            string objectType,
                            string objectOmschrijving)
        {

            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = KeuzeMenus.GetInstance();//new KeuzeMenus();
            LoadMenus();
            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            textBoxProjectNaam.Text = projectNaam;
            textBoxObjectNaam.Text = ObjectNaam;
            textBoxOmschrijving.Text = objectOmschrijving;
            comboBoxObjectType.SelectedIndex = comboBoxObjectType.FindStringExact(objectType);
            
            LoadData();
            SetInstellingen();

            //textBoxDiscipline.Text = riskDiscipline;
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
            dataGridViewGekoppeldeIssues.DataSource = comunicator.GetObjectIssues(ObjectID);
            //dataGridViewGekoppeldeIssues.DataSource = comunicator.GetObjectIssuesFull(ObjectID);
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

            //KeuzeMenus instellingen = new KeuzeMenus();
            List<CheckedListBox> menuBox = keuzeMenus.GetKeuzeMenus();
            for (int i = 0; i < menuBox.Count; i++)
            {
                
                
                tabPage3.Controls.Add(menuBox[i]);
            }
            
            
        }

        private void buttonIssuesOplossen_Click(object sender, EventArgs e)
        {
            //Form issueMaatregelen = new IssueMaatregelen();
            //issueMaatregelen.Show();
        }

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            
            Form addTemplate = new AddTemplate();
            addTemplate.Show();
        }

        private void dataGridViewGekoppeldeIssues_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string issueId = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[0].Value.ToString();
            string situatie = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[1].Value.ToString();
            string gebeurtenis = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[2].Value.ToString();

            string discipline = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[3].Value.ToString();
            string gevaar = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[9].Value.ToString();

            string init_Risico = "";
            string init_Risico_Beschrijving = "";
            string rest_Risico = "";
            string rest_Risico_Beschrijving = "";



            Form issueMaatregelen = new IssueMaatregelen(ObjectNaam, ObjectID ,issueId, 
                                                         discipline, gevaar, situatie, gebeurtenis,
                                                         init_Risico, init_Risico_Beschrijving,
                                                         rest_Risico, rest_Risico_Beschrijving);
            issueMaatregelen.Show();



        }

        private void buttonAddRisico_Click(object sender, EventArgs e)
        {
            Form addRisico = new AddRisico(ObjectNaam, ObjectID);
            addRisico.Show();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Form exportObject = new ExportObject(comunicator.GetObjectIssues(ObjectID));
            exportObject.Show();
        }
    }
}
