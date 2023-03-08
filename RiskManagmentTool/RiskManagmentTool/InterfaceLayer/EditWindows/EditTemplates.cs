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
        private KeuzeMenus keuzeMenus;
        private DataControler controler;

        private List<string> SelectedGevarenId;
        private List<string> SelectedIssuesId;

        private List<string> GekoppeldeGevarenId;
        private List<string> GekoppeldeIssuesId;

        private string TemplateID;


        private BindingSource TemplateData;
        private BindingSource AllGevarenData;
        private BindingSource ObjectIssuesData;

        public EditTemplates(string templateId)
        {
            InitializeComponent();
            TemplateID = templateId;
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            controler = new DataControler(TemplateID);

            SelectedGevarenId = new List<string>();
            SelectedIssuesId = new List<string>();

            GekoppeldeGevarenId = new List<string>();
            GekoppeldeIssuesId = new List<string>();

            
            LoadData();
            LoadCombobox();
        }

        private void LoadData()
        {
            //textBoxSelectedIssues.Text = "";
            textBoxTemplateID.Text = TemplateID;


            GekoppeldeGevarenId = comunicator.GetGekoppeldeGevarenFromTemplateAsList(TemplateID);
            GekoppeldeIssuesId = comunicator.GetGekoppeldeIssuesFromTemplateAsList(TemplateID);


            AllGevarenData = comunicator.GetGlobalGevarenTable();
            advancedDataGridViewAllGevaren.DataSource = AllGevarenData;

            ReloadTemplateData();


        }

        private void LoadCombobox()
        {
            Dictionary<int, string> templateTypesList = keuzeMenus.GetTemplateTypesMenu();
            foreach (KeyValuePair<int, string> kvp in templateTypesList)
            {
                comboBoxTemplateType.Items.Add(kvp.Value);
            }

            Dictionary<int, string> templateToepassingList = keuzeMenus.GetTemplateToepassingenMenu();
            foreach (KeyValuePair<int, string> kvp in templateToepassingList)
            {
                comboBoxTemplateToepassing.Items.Add(kvp.Value);
            }

            List<string> objectNamenList = keuzeMenus.GetObjectNamen();
            foreach (string objectNaam in objectNamenList)
            {
                
                    comboBoxViewObjectNaam.Items.Add(objectNaam);
                
            }
        }

        private void ReloadTemplateData()
        {

            TemplateData = comunicator.GetTemplateIssues(TemplateID);
            advancedDataGridViewGekoppeldeIssues.DataSource = TemplateData;

        }



        private void buttonVerwijderIssues_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddFromObjecten_Click(object sender, EventArgs e)
        {
            string issueID = "";
            foreach (DataGridViewRow row in advancedDataGridViewObjectIssues.SelectedRows)
            {
                issueID = row.Cells[0].Value.ToString();
                SelectedIssuesId.Add(issueID);

            }
            foreach (string issueId in SelectedIssuesId)
            {
                comunicator.AddIssueToTemplate(TemplateID, issueId);
            }
            ReloadTemplateData();
        }

        private void buttonAddFromGevaren_Click(object sender, EventArgs e)
        {
            string gevaarID = "";
            foreach (DataGridViewRow row in advancedDataGridViewAllGevaren.SelectedRows)
            {
                gevaarID = row.Cells[0].Value.ToString();
                SelectedGevarenId.Add(gevaarID);
                
            }
            foreach (string gevaarId in SelectedGevarenId)
            {
                comunicator.AddGevaarToTemplate(TemplateID, gevaarId);
            }
            ReloadTemplateData();
        }

        private void comboBoxViewObjectNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObjectIssuesData = comunicator.GetObjectIssuesByObjectName(comboBoxViewObjectNaam.SelectedItem.ToString());
            advancedDataGridViewObjectIssues.DataSource = ObjectIssuesData;
            //dataGridViewObjectView.DataSource = comunicator.GetObjectIssuesByObjectName(comboBoxViewObjectNaam.SelectedItem.ToString());
            SelectedIssuesId.Clear();
        }
    }
}
