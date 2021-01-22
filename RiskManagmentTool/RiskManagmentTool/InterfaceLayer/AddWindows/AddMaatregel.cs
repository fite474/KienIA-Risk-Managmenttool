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
            keuzeMenus = new KeuzeMenus();
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
            //dataGridViewMaatregelen.DataSource = comunicator.GetMaatregelTable();
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

        private void dataGridViewMaatregelen_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //string maatregelID = dataGridViewMaatregelen.SelectedRows[0].Cells[0].Value.ToString();
            //if (!SelectedMaatregelId.Contains(maatregelID))
            //{
            //    SelectedMaatregelId.Add(maatregelID);
            //    textBoxSelectedMaatregelen.Text += maatregelID + ", ";
            //}
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
            controler.CheckIssueForDubbleMaatregelen(SelectedMaatregelId);
            SelectedMaatregelId.Clear();
            this.Close();

            //foreach (string maatregelId in SelectedMaatregelId)
            //    {
            //        comunicator.AddMaatregelToIssue(IssueID, maatregelId);
            //    }
             
        }

        //private void dataGridViewMaatregelen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    dataGridViewMaatregelen.ClearSelection();
        //}

        private void comboBoxWeergaveTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxWeergaveTemplate.SelectedItem.ToString();

            dataGridViewTemplateMaatregelen.DataSource = comunicator.GetObjectIssuesByObjectName(selectedTemplateName);
        }

        //private void comboBoxObjectenWeergave_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //dataGridViewObjectIssues.DataSource = comunicator.GetObjectIssuesByObjectName(comboBoxObjectenWeergave.SelectedItem.ToString());
        //}

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

            //string issueId = dataGridViewObjectIssues.SelectedRows[0].Cells[viewsColumnNames.IssueIDColumn].Value.ToString();//[0].Value.ToString();
            //string situatie = dataGridViewObjectIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeSituatieColumn].Value.ToString();
            //string gebeurtenis = dataGridViewObjectIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeGebeurtenisColumn].Value.ToString();

            //string discipline = dataGridViewObjectIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarDisciplineColumn].Value.ToString();
            //string gevaar = dataGridViewObjectIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarGevaarTypeColumn].Value.ToString();

            //string init_Risico = "";
            //string init_Risico_Beschrijving = "";
            //string rest_Risico = "";
            //string rest_Risico_Beschrijving = "";

            ////string objectNaam = comunicator.GetObjectIdByIssueNmr


            //Form issueMaatregelen = new IssueMaatregelen(ObjectNaam, ObjectID, issueId,
            //                                             discipline, gevaar, situatie, gebeurtenis,
            //                                             init_Risico, init_Risico_Beschrijving,
            //                                             rest_Risico, rest_Risico_Beschrijving);
            //issueMaatregelen.ShowDialog();
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
