using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RiskManagmentTool.LogicLayer;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    public partial class AddMaatregel : Form
    {
        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        private DataControler controler;
        private ViewsColumnNames viewsColumnNames;

        private List<string> SelectedMaatregelId;

        private string IssueID;
        private string ObjectNaam;
        private string ObjectID;
        private string GevaarID;

        private BindingSource maatregelenData;

        public AddMaatregel(string objectNaam, string objectID, string issueId, string discipline, string gevaar, string situatie, string gebeurtenis)
        {
            InitializeComponent();
            IssueID = issueId;
            
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus(objectID);
            controler = new DataControler(IssueID);
            viewsColumnNames = new ViewsColumnNames();
            SelectedMaatregelId = new List<string>();

            GevaarID = comunicator.GetGevaarIdByIssueID(issueId);

            LoadData();
            LoadComboboxes();

            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            

            textBoxIssueID.Text = IssueID;
            textBoxGevaarID.Text = GevaarID;
            textBoxDiscipline.Text = discipline;
            textBoxGevaarType.Text = gevaar;

            textBoxSituatie.Text = situatie;
            textBoxGebeurtenis.Text = gebeurtenis;
        }

        private void LoadData()
        {

            maatregelenData = comunicator.GetMaatregelTable();
            advancedDataGridViewMaatregelen.DataSource = maatregelenData;

            dataGridViewObjectIssues.DataSource = comunicator.GetAllIssuesWithGevaarID(GevaarID);


        }

        private void LoadComboboxes()
        {
            //List<string> disciplinesList = keuzeMenus.GetDisciplinesMenu();
            //foreach (string typeString in disciplinesList)
            //{
            //    comboBoxDiscipline.Items.Add(typeString);
            //}

            //List<string> gevarenList = keuzeMenus.GetGevaarTypeMenu();
            //foreach (string gevaar in gevarenList)
            //{
            //    comboBoxGevaar.Items.Add(gevaar);
            //}

            //Dictionary<int, string> maatregelCategoryList = keuzeMenus.GetMaatregelCategoryMenu();
            //foreach (KeyValuePair<int, string> kvp in maatregelCategoryList)
            //{
            //    comboBoxMaatregelCategorie.Items.Add(kvp.Value);
            //}




            List<string> objectNamenList = keuzeMenus.GetObjectNamen();
            foreach (string objectNaam in objectNamenList)
            {
                //if (objectNaam != ObjectNaam)
                //{
                    comboBoxObjectenWeergave.Items.Add(objectNaam);
                //}
            }

            List<string> templateNamenList = keuzeMenus.GetTemplateNamen();
            foreach (string templateNaam in templateNamenList)
            {
                comboBoxWeergaveTemplate.Items.Add(templateNaam);
            }

        }

        private void dataGridViewTemplateMaatregelen_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string templateId = dataGridViewTemplateMaatregelen.SelectedRows[0].Cells[0].Value.ToString();
            //string ObjectType = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[1].Value.ToString();
            //string ObjectBeschrijving = dataGridViewGekoppeldeIssues.SelectedRows[0].Cells[2].Value.ToString();

            //Form editTemplates = new EditTemplates(templateId);
            //editTemplates.Show();

            //Form issueMaatregelen = new IssueMaatregelen(issueId);
            //issueMaatregelen.Show();



        }

        private void buttonCreateNewMaatregel_Click(object sender, EventArgs e)
        {
            Form editMaatregelen = new EditMaatregelen();
            editMaatregelen.ShowDialog();
            LoadData();
        }

        private void buttonKoppelSelectedMaatregelen_Click(object sender, EventArgs e)
        {
            string maatregelID = "";
            foreach (DataGridViewRow row in advancedDataGridViewMaatregelen.SelectedRows)
            {
                maatregelID = row.Cells[0].Value.ToString();

                if (!SelectedMaatregelId.Contains(maatregelID))
                {
                    SelectedMaatregelId.Add(maatregelID);
                    //textBoxSelectedMaatregelen.Text += maatregelID + ", ";
                }
                //    if (!SelectedTemplateIssueId.Contains(maatregelID))
                //{
                //    SelectedTemplateIssueId.Add(maatregelID);
                //}
            }
            advancedDataGridViewMaatregelen.ClearSelection();
            controler.CheckIssueForDubbleMaatregelenAndAddNewOnes(SelectedMaatregelId);
            SelectedMaatregelId.Clear();
            this.Close();             
        }

        private void comboBoxWeergaveTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxWeergaveTemplate.SelectedItem.ToString();

            dataGridViewTemplateMaatregelen.DataSource = comunicator.GetObjectIssuesByObjectName(selectedTemplateName);
        }

        private void dataGridViewObjectIssues_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (dataGridViewObjectIssues.ColumnCount - 1); i++)
            {
                dataGridViewObjectIssues.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (dataGridViewObjectIssues.Columns[i + 1].Width > 400)
                {
                    dataGridViewObjectIssues.Columns[i + 1].Width = 400;
                }
            }

            dataGridViewObjectIssues.ClearSelection();
        }

        private void dataGridViewObjectIssues_DoubleClick(object sender, EventArgs e)
        {
            string clickedIssueId = dataGridViewObjectIssues.SelectedRows[0].Cells[viewsColumnNames.IssueIDColumn].Value.ToString();//[0].Value.ToString();
            string clickedObjectNaam = dataGridViewObjectIssues.SelectedRows[0].Cells[0].Value.ToString();
            AddMaatregelenFromOtherIssue addMaatregelenFromOtherIssue = new AddMaatregelenFromOtherIssue(clickedObjectNaam, IssueID, clickedIssueId);
            addMaatregelenFromOtherIssue.Show();
        }

        private void advancedDataGridViewMaatregelen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (advancedDataGridViewMaatregelen.ColumnCount - 1); i++)
            {
                //column in breedte uitrekken aan de hand van text size
                advancedDataGridViewMaatregelen.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (advancedDataGridViewMaatregelen.Columns[i + 1].Width > 400)
                {
                    //max column breedte is 400 px
                    advancedDataGridViewMaatregelen.Columns[i + 1].Width = 400;
                }
            }
            advancedDataGridViewMaatregelen.ClearSelection();

        }

        private void advancedDataGridViewMaatregelen_SortStringChanged(object sender, EventArgs e)
        {
            this.maatregelenData.Sort = this.advancedDataGridViewMaatregelen.SortString;
        }

        private void advancedDataGridViewMaatregelen_FilterStringChanged(object sender, EventArgs e)
        {
            this.maatregelenData.Filter = this.advancedDataGridViewMaatregelen.FilterString;
        }
    }
}
