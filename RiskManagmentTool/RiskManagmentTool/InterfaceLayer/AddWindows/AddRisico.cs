using System;
using System.Collections.Generic;
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



        private BindingSource gevarenData;
        private BindingSource objectGevarenData;
        private BindingSource templateGevarenData;

        public AddRisico(string objectNaam, string objectID)
        {
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            controler = new DataControler(objectID);
            viewsColumnNames = new ViewsColumnNames();

            SelectedGevarenId = new List<string>();
            SelectedObjectIssueId = new List<string>();
            SelectedTemplateIssueId = new List<string>();

            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;

            LoadData();
            textBoxObjectNaam.Text = ObjectNaam;
            SetAddSettings();
            LoadComboboxes();
        }

        private void LoadData()
        {
            gevarenData = comunicator.GetGlobalGevarenTable();
            advancedDataGridViewLosseItems.DataSource = gevarenData;
        }



        private void LoadComboboxes()
        {

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
        }

        private void buttonCreateNewGevaar_Click(object sender, EventArgs e)
        {
            Form editRisicosForm = new EditRisicos(ObjectID);
            editRisicosForm.ShowDialog();
            LoadData();
        }

        private void comboBoxViewTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string selectedTemplateName = comboBoxViewTemplate.SelectedItem.ToString();

            templateGevarenData = comunicator.GetObjectIssuesByObjectName(selectedTemplateName);
            advancedDataGridViewTemplateViewIssues.DataSource = templateGevarenData;
            //dataGridViewTemplateViewIssues.DataSource = comunicator.GetTemplateIssuesByName(selectedTemplateName);

            //dataGridViewTemplateViewGevaren.DataSource = comunicator.GetTemplateGevarenByName(selectedTemplateName);
        }

        private void comboBoxViewObjectNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            objectGevarenData = comunicator.GetObjectIssuesByObjectName(comboBoxViewObjectNaam.SelectedItem.ToString());
            advancedDataGridViewObjectView.DataSource = objectGevarenData;
            //dataGridViewObjectView.DataSource = comunicator.GetObjectIssuesByObjectName(comboBoxViewObjectNaam.SelectedItem.ToString());
            SelectedObjectIssueId.Clear();
        }

        private void advancedDataGridViewObjectView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string issueId = advancedDataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.IssueIDColumn].Value.ToString();//[0].Value.ToString();
                string situatie = advancedDataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeSituatieColumn].Value.ToString();
                string gebeurtenis = advancedDataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeGebeurtenisColumn].Value.ToString();

                string discipline = advancedDataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.GevaarDisciplineColumn].Value.ToString();
                string gevaar = advancedDataGridViewObjectView.SelectedRows[0].Cells[viewsColumnNames.GevaarGevaarTypeColumn].Value.ToString();


                IssueMaatregelen issueMaatregelen = new IssueMaatregelen(ObjectNaam, ObjectID, issueId,
                                                             discipline, gevaar, situatie, gebeurtenis);
                issueMaatregelen.SetReadOnlyMode();
                issueMaatregelen.ShowDialog();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
           
        }

        private void advancedDataGridViewTemplateViewIssues_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string issueId = advancedDataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.IssueIDColumn].Value.ToString();//[0].Value.ToString();
                string situatie = advancedDataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeSituatieColumn].Value.ToString();
                string gebeurtenis = advancedDataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarlijkeGebeurtenisColumn].Value.ToString();

                string discipline = advancedDataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarDisciplineColumn].Value.ToString();
                string gevaar = advancedDataGridViewTemplateViewIssues.SelectedRows[0].Cells[viewsColumnNames.GevaarGevaarTypeColumn].Value.ToString();


                IssueMaatregelen issueMaatregelen = new IssueMaatregelen(comboBoxViewTemplate.SelectedItem.ToString(), "", issueId,
                                                             discipline, gevaar, situatie, gebeurtenis);
                issueMaatregelen.SetReadOnlyMode();
                issueMaatregelen.ShowDialog();
            }
            catch (Exception err)
            {
                Console.WriteLine(err); ;
            }
           
        }



        private void buttonAddSingleItems_Click(object sender, EventArgs e)
        {
            string gevaarID = "";
            foreach (DataGridViewRow row in advancedDataGridViewLosseItems.SelectedRows)
            {
                gevaarID = row.Cells[0].Value.ToString();
                if (!SelectedGevarenId.Contains(gevaarID))
                {
                    SelectedGevarenId.Add(gevaarID);
                }
            }

            advancedDataGridViewLosseItems.ClearSelection();
            List<string> temp = controler.CheckObjectForDubbleGevaren(SelectedGevarenId);
            SelectedGevarenId = temp;


            foreach (string gevaarToAddID in SelectedGevarenId)
            {
                comunicator.AddGevaarToObject(ObjectID, gevaarToAddID);
            }
            this.Close();
        }



        private void buttonAddFromTemplateIssues_Click(object sender, EventArgs e)
        {


            string issueID = "";
            foreach (DataGridViewRow row in advancedDataGridViewTemplateViewIssues.SelectedRows)
            {
                issueID = row.Cells[1].Value.ToString();

                if (!SelectedTemplateIssueId.Contains(issueID))
                {
                    SelectedTemplateIssueId.Add(issueID);
                }
            }

            
            List<string> temp = controler.CheckObjectForDubbleGevarenUitIssues(SelectedTemplateIssueId);


            SelectedTemplateIssueId = temp;


            bool addMaatregelen = checkedListBoxAddSettings.GetItemChecked(0);
            bool addRisicoBeoordeling = checkedListBoxAddSettings.GetItemChecked(1);
            //bool issueNeedsToVirify = checkedListBoxAddSettings.GetItemChecked(2);

            foreach (string gevaarToAddID in SelectedTemplateIssueId)
            {
                comunicator.AddIssueToObject(ObjectID, gevaarToAddID, addMaatregelen, addRisicoBeoordeling);//, issueNeedsToVirify);
            }

            this.Close();
            //foreach (string gevaarToAddID in SelectedTemplateIssueId)
            //{
            //    //comunicator.AddGevaarToObject(ObjectID, gevaarToAddID);
            //}

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
            foreach (DataGridViewRow row in advancedDataGridViewObjectView.SelectedRows)
            {
                issueID = row.Cells[1].Value.ToString();
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
            //bool issueNeedsToVirify = checkedListBoxAddSettings.GetItemChecked(2);

            foreach (string gevaarToAddID in SelectedObjectIssueId)
            {
                comunicator.AddIssueToObject(ObjectID, gevaarToAddID, addMaatregelen, addRisicoBeoordeling);//, issueNeedsToVirify);
            }
            this.Close();
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

        private void advancedDataGridViewLosseItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void advancedDataGridViewLosseItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (advancedDataGridViewLosseItems.ColumnCount - 1); i++)
            {
                advancedDataGridViewLosseItems.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (advancedDataGridViewLosseItems.Columns[i + 1].Width > 400)
                {
                    advancedDataGridViewLosseItems.Columns[i + 1].Width = 400;
                }
            }

            advancedDataGridViewLosseItems.ClearSelection();
            Cursor.Current = Cursors.Default;
        }

        private void advancedDataGridViewLosseItems_FilterStringChanged(object sender, EventArgs e)
        {
            this.gevarenData.Filter = this.advancedDataGridViewLosseItems.FilterString;
        }

        private void advancedDataGridViewLosseItems_SortStringChanged(object sender, EventArgs e)
        {
            this.gevarenData.Sort = this.advancedDataGridViewLosseItems.SortString;
        }



        private void advancedDataGridViewObjectView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (advancedDataGridViewObjectView.ColumnCount - 1); i++)
            {
                advancedDataGridViewObjectView.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (advancedDataGridViewObjectView.Columns[i + 1].Width > 400)
                {
                    advancedDataGridViewObjectView.Columns[i + 1].Width = 400;
                }
            }

            advancedDataGridViewObjectView.ClearSelection();
            Cursor.Current = Cursors.Default;
            
        }

        private void advancedDataGridViewObjectView_FilterStringChanged(object sender, EventArgs e)
        {
            this.objectGevarenData.Filter = this.advancedDataGridViewObjectView.FilterString;
        }

        private void advancedDataGridViewObjectView_SortStringChanged(object sender, EventArgs e)
        {
            this.objectGevarenData.Sort = this.advancedDataGridViewObjectView.SortString;
        }

        private void AddRisico_Load(object sender, EventArgs e)
        {
            //gevarenData = comunicator.GetGevarenTable();
            //advancedDataGridViewLosseItems.DataSource = gevarenData;



        }

        private void advancedDataGridViewTemplateViewIssues_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < (advancedDataGridViewTemplateViewIssues.ColumnCount - 1); i++)
            {
                advancedDataGridViewTemplateViewIssues.AutoResizeColumn((i + 1), DataGridViewAutoSizeColumnMode.AllCells);
                if (advancedDataGridViewTemplateViewIssues.Columns[i + 1].Width > 400)
                {
                    advancedDataGridViewTemplateViewIssues.Columns[i + 1].Width = 400;
                }
            }

            advancedDataGridViewTemplateViewIssues.ClearSelection();
            Cursor.Current = Cursors.Default;
        }
    }
}
