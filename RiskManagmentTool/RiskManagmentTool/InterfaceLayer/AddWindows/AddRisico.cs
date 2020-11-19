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
using RiskManagmentTool.InterfaceLayer.InitWindows;

namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    public partial class AddRisico : Form
    {
        private Datacomunication comunicator;
        private DataControler controler;
        private string ObjectNaam;
        private string ObjectID;
        private KeuzeMenus keuzeMenus;
        private ViewsColumnNames viewsColumnNames;

        private List<string> SelectedGevarenId;
        private List<string> SelectedObjectIssueId;
        private List<string> SelectedTemplateIssueId;
        //private List<string> SelectedTemplateGevaarId;




        public AddRisico(string objectNaam, string objectID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            controler = new DataControler(objectID);
            viewsColumnNames = new ViewsColumnNames();

            SelectedGevarenId = new List<string>();
            SelectedObjectIssueId = new List<string>();
            SelectedTemplateIssueId = new List<string>();
            //SelectedTemplateGevaarId = new List<string>();

            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewLosseItems.DataSource = comunicator.GetGevarenTable();
            textBoxObjectNaam.Text = ObjectNaam;
            SetAddSettings();
            

            LoadComboboxes();
        }



        private void LoadComboboxes()
        {

            //List<string> disciplinesList = keuzeMenus.GetDisciplinesMenu();
            //foreach (string typeString in disciplinesList)
            //{
            //    comboBoxDiscipline.Items.Add(typeString);
            //}

            List<string> objectNamenList = keuzeMenus.GetObjectNamen();
            foreach (string objectNaam in objectNamenList)
            {
                if (objectNaam != ObjectNaam)
                {
                    comboBoxViewObjectNaam.Items.Add(objectNaam);
                }
            }

            List<string> templateNamenList = keuzeMenus.GetTemplateNamen();
            foreach (string templateNaam in templateNamenList)
            {
                comboBoxViewTemplate.Items.Add(templateNaam);
            }

        }

    
        private void SetAddSettings()
        {
            checkedListBoxAddSettings.SetItemChecked(0, true);
            checkedListBoxAddSettings.SetItemChecked(1, true);
            checkedListBoxAddSettings.SetItemChecked(2, true);
        }

        private void HandleAddWithSettings(List<string> GevarenIdToAdd)
        {
            //foreach (string gevaarToAddID in GevarenIdToAdd)
            //{
            //    int addedIssueID = comunicator.AddGevaarToObject(ObjectID, gevaarToAddID);
            //    if (checkedListBoxAddSettings.GetItemChecked(0))// 0 is maatregelen
            //    {
            //        comunicator.AddMaatregelToIssue();
            //    }
            //    if (checkedListBoxAddSettings.GetItemChecked(1))//1 is risico beoordeling
            //    {

            //    }
            //    if (checkedListBoxAddSettings.GetItemChecked(2))// 2 is verifieren
            //    {

            //    }
            //}
            
           // comunicator.AddGevaarToObject(ObjectID, );
        }
        

        private void buttonVoegSelectieToe_Click(object sender, EventArgs e)
        {
            //for list selectie id, datacom . add gevaar to object



            //foreach (string gevaarId in SelectedGevarenId)
            //{
            //    comunicator.AddGevaarToObject(ObjectID, gevaarId);
            //}

            //foreach (string templateGevaarId in SelectedTemplateGevaarId)
            //{
            //    comunicator.AddGevaarToObject(ObjectID, templateGevaarId);
            //}

            //foreach (string templateIssueId in SelectedTemplateIssueId)
            //{
            //    comunicator.AddIssueToObject(ObjectID, templateIssueId);
            //}

            //foreach (string objectIssueId in SelectedObjectIssueId)
            //{
             //   comunicator.AddIssueToObject(ObjectID, objectIssueId);
            //}
            //this.Close();
        }

        private void buttonCreateNewGevaar_Click(object sender, EventArgs e)
        {
            Form editRisicosForm = new EditRisicos();
            editRisicosForm.ShowDialog();
            dataGridViewLosseItems.DataSource = comunicator.GetGevarenTable();
        }

        private void dataGridViewRisicos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string gevaarID = dataGridViewLosseItems.SelectedRows[0].Cells[0].Value.ToString();
            //    if (!SelectedGevarenId.Contains(gevaarID))
            //    {
            //        SelectedGevarenId.Add(gevaarID);
            //        textBoxSelectedItems.Text += gevaarID + ", ";
            //    }
        }

        private void comboBoxDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewLosseItems.DataSource = comunicator.GetGevarenTableByDiscipline(comboBoxDiscipline.SelectedItem.ToString());
        }





        private void comboBoxViewTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxViewTemplate.SelectedItem.ToString();

            dataGridViewTemplateViewIssues.DataSource = comunicator.GetTemplateIssuesByName(selectedTemplateName);

            //dataGridViewTemplateViewGevaren.DataSource = comunicator.GetTemplateGevarenByName(selectedTemplateName);
        }

        private void comboBoxViewObjectNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewObjectView.DataSource = comunicator.GetObjectIssuesByObjectName(comboBoxViewObjectNaam.SelectedItem.ToString());
            SelectedObjectIssueId.Clear();
        }



        private void dataGridViewObjectView_DoubleClick(object sender, EventArgs e)
        {
            string issueId = dataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.IssueIDColumn].Value.ToString();//[0].Value.ToString();
            string situatie = dataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeSituatieColumn].Value.ToString();
            string gebeurtenis = dataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeGebeurtenisColumn].Value.ToString();

            string discipline = dataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.GevaarDisciplineColumn].Value.ToString();
            string gevaar = dataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.GevaarGevaarTypeColumn].Value.ToString();

            string init_Risico = "";
            string init_Risico_Beschrijving = "";
            string rest_Risico = "";
            string rest_Risico_Beschrijving = "";

            IssueMaatregelen issueMaatregelen = new IssueMaatregelen(ObjectNaam, ObjectID, issueId,
                                                         discipline, gevaar, situatie, gebeurtenis,
                                                         init_Risico, init_Risico_Beschrijving,
                                                         rest_Risico, rest_Risico_Beschrijving);
            issueMaatregelen.SetReadOnlyMode();
            issueMaatregelen.ShowDialog();
        }

        private void dataGridViewTemplateViewIssues_DoubleClick(object sender, EventArgs e)
        {
            string issueId = dataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.IssueIDColumn].Value.ToString();//[0].Value.ToString();
            string situatie = dataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeSituatieColumn].Value.ToString();
            string gebeurtenis = dataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeGebeurtenisColumn].Value.ToString();

            string discipline = dataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarDisciplineColumn].Value.ToString();
            string gevaar = dataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarGevaarTypeColumn].Value.ToString();

            string init_Risico = "";
            string init_Risico_Beschrijving = "";
            string rest_Risico = "";
            string rest_Risico_Beschrijving = "";

            IssueMaatregelen issueMaatregelen = new IssueMaatregelen(comboBoxViewTemplate.SelectedItem.ToString(), "", issueId,
                                                         discipline, gevaar, situatie, gebeurtenis,
                                                         init_Risico, init_Risico_Beschrijving,
                                                         rest_Risico, rest_Risico_Beschrijving);
            issueMaatregelen.SetReadOnlyMode();
            issueMaatregelen.ShowDialog();
        }


        private void buttonAddSingleItems_Click(object sender, EventArgs e)
        {
            string gevaarID = "";
            foreach (DataGridViewRow row in dataGridViewLosseItems.SelectedRows)
            {
                gevaarID = row.Cells[0].Value.ToString();
                if (!SelectedGevarenId.Contains(gevaarID))
                {
                    SelectedGevarenId.Add(gevaarID);
                }
            }

            dataGridViewLosseItems.ClearSelection();
            List<string> temp = controler.CheckObjectForDubbleGevaren(SelectedGevarenId);
            SelectedGevarenId = temp;


            foreach (string gevaarToAddID in SelectedGevarenId)
            {
                comunicator.AddGevaarToObject(ObjectID, gevaarToAddID);
            }
            
            //controler.CheckObjectForDubbleGevaren(SelectedGevarenId);
            //SelectedGevarenId.Clear();
            //dataGridViewWeergaveLosseItems.DataSource = comunicator.GetSelectedGevaren(SelectedGevarenId);
        }








        private void buttonAddFromTemplateIssues_Click(object sender, EventArgs e)
        {
            //string selectedTemplateName = comboBoxViewTemplate.SelectedItem.ToString();
            //if (!comboBoxWeergaveTemplateNaam.Items.Contains(selectedTemplateName))
            //{
            //    comboBoxWeergaveTemplateNaam.Items.Add(selectedTemplateName);
            //}

            string issueID = "";
            foreach (DataGridViewRow row in dataGridViewTemplateViewIssues.SelectedRows)
            {
                issueID = row.Cells[0].Value.ToString();

                if (!SelectedTemplateIssueId.Contains(issueID))
                {
                    SelectedTemplateIssueId.Add(issueID);
                }
            }
            //dataGridViewTemplateViewIssues.ClearSelection();
            List<string> temp = controler.CheckObjectForDubbleGevarenUitIssues(SelectedTemplateIssueId);


            SelectedTemplateIssueId = temp;
            foreach (string gevaarToAddID in SelectedTemplateIssueId)
            {
                //comunicator.AddGevaarToObject(ObjectID, gevaarToAddID);
            }

            //SelectedTemplateIssueId.Clear();
            //CheckForDubble();
        }




        private void buttonAddFromObject_Click(object sender, EventArgs e)
        {
            //string selectedObjectName = comboBoxViewObjectNaam.SelectedItem.ToString();
            //if (!comboBoxWeergaveObjectNaam.Items.Contains(selectedObjectName))
            //{
            //    comboBoxWeergaveObjectNaam.Items.Add(selectedObjectName);
            //}

            string issueID = "";
            foreach (DataGridViewRow row in dataGridViewObjectView.SelectedRows)
            {
                issueID = row.Cells[0].Value.ToString();
                if (!SelectedObjectIssueId.Contains(issueID))
                {
                    SelectedObjectIssueId.Add(issueID);
                }
            }
            List<string> temp = controler.CheckObjectForDubbleGevarenUitIssues(SelectedObjectIssueId);
            // dataGridViewObjectView.ClearSelection();
            SelectedObjectIssueId = temp;

            bool addMaatregelen = checkedListBoxAddSettings.GetItemChecked(0);
            bool addRisicoBeoordeling = checkedListBoxAddSettings.GetItemChecked(1);
            bool issueNeedsToVirify = checkedListBoxAddSettings.GetItemChecked(2);

            foreach (string gevaarToAddID in SelectedObjectIssueId)
            {
                comunicator.AddIssueToObject(ObjectID, gevaarToAddID, addMaatregelen, addRisicoBeoordeling, issueNeedsToVirify);
            }

        }

        private void dataGridViewLosseItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewLosseItems.ClearSelection();
        }

        private void dataGridViewTemplateViewIssues_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewTemplateViewIssues.ClearSelection();
        }

        private void dataGridViewObjectView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewObjectView.ClearSelection();
        }

        private void buttonCreateNewTemplate_Click(object sender, EventArgs e)
        {
            Form initTemplate = new InitTemplate();
            if (initTemplate.ShowDialog() == DialogResult.OK)
            {

                string templateID = comunicator.GetLastTemplateID();
                initTemplate.Dispose();
                Form editTemplate = new EditTemplates(templateID);
                editTemplate.ShowDialog();
            }
            else
            {

                initTemplate.Dispose();
                //this.txtResult.Text = "Cancelled";
            }
            

            
        }


    }
}
