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
    public partial class EditObjecten : Form
    {
        private Datacomunication comunicator;
        private string objectNaam;
        public EditObjecten()
        {
            InitializeComponent();
            SetInstellingen();
        }
        public EditObjecten(string objectNaam,
                            string objectType,
                            string objectOmschrijving)//,
                                              //string riskDicipline,
                                              //string riskGebruiksfase,
                                              //string riskGebruiker,
                                              //string riskGevarenzone)
        {

            InitializeComponent();
            this.objectNaam = objectNaam;
            comboBoxObjectType.Items.Add(objectType);

            textBoxObjectNaam.Text = objectNaam;
            comboBoxObjectType.SelectedIndex = 0;
            textBoxOmschrijving.Text = objectOmschrijving;
            comunicator = new Datacomunication();
            LoadData();
            SetInstellingen();

            //textBoxDiscipline.Text = riskDicipline;
            //textBoxGebruiksfase.Text = riskGebruiksfase;
            //textBoxBedienvorm.Text = riskGebruiker;
            //textBoxRiskGevarenzone.Text = riskGevarenzone;
        }

        private void LoadData()
        {
            dataGridViewGekoppeldeIssues.DataSource = comunicator.getObjectIssues(objectNaam);

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
    }
}
