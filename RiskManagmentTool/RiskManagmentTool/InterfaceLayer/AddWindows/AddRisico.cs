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
    public partial class AddRisico : Form
    {
        private Datacomunication comunicator;
        private DataControler controler;
        private string ObjectNaam;
        private string ObjectID;
        private KeuzeMenus keuzeMenus;

        private List<string> SelectedGevarenId;
        private List<string> SelectedObjectIssueId;
        private List<string> SelectedTemplateIssueId;
        private List<string> SelectedTemplateGevaarId;




        public AddRisico(string objectNaam, string objectID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            controler = new DataControler(objectID);

            SelectedGevarenId = new List<string>();
            SelectedObjectIssueId = new List<string>();
            SelectedTemplateIssueId = new List<string>();
            SelectedTemplateGevaarId = new List<string>();

            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewLosseItems.DataSource = comunicator.GetGevarenTable();
            textBoxObjectNaam.Text = ObjectNaam;

            

            LoadComboboxes();
        }



        private void LoadComboboxes()
        {

            List<string> disciplinesList = keuzeMenus.GetDisciplinesMenu();
            foreach (string typeString in disciplinesList)
            {
                comboBoxDiscipline.Items.Add(typeString);
            }

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
            //    comunicator.AddIssueToObject(ObjectID, objectIssueId);
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

        private void comboBoxWeergaveObjectNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedObjectName = comboBoxWeergaveObjectNaam.SelectedItem.ToString();
            dataGridViewWeergaveUitObjecten.DataSource = comunicator.GetSelectedObjectIssues(selectedObjectName, SelectedObjectIssueId);
        }

        private void comboBoxWeergaveTemplateNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxWeergaveTemplateNaam.SelectedItem.ToString();
            if (SelectedTemplateGevaarId.Count >= 1)
            {
                dataGridViewWeergaveGevarenUitTemplate.DataSource = comunicator.GetSelectedTemplateGevaren(selectedTemplateName, SelectedTemplateGevaarId);

            }
            if (SelectedTemplateIssueId.Count >= 1)
            {
                dataGridViewWeergaveIssuesUitTemplate.DataSource = comunicator.GetSelectedTemplateIssues(selectedTemplateName, SelectedTemplateIssueId);

            }
        }

        private void comboBoxViewTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxViewTemplate.SelectedItem.ToString();

            dataGridViewTemplateViewIssues.DataSource = comunicator.GetTemplateIssuesByName(selectedTemplateName);

            dataGridViewTemplateViewGevaren.DataSource = comunicator.GetTemplateGevarenByName(selectedTemplateName);
        }

        private void comboBoxViewObjectNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewObjectView.DataSource = comunicator.GetObjectIssuesByObjectName(comboBoxViewObjectNaam.SelectedItem.ToString());
            SelectedObjectIssueId.Clear();
        }

        private void dataGridViewTemplateViewGevaren_DoubleClick(object sender, EventArgs e)
        {
            
            //string gevaarID = dataGridViewRisicos.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void dataGridViewObjectView_DoubleClick(object sender, EventArgs e)
        {

            //string gevaarID = dataGridViewRisicos.SelectedRows[0].Cells[0].Value.ToString();
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

            //controler.CheckObjectForDubbleGevaren(SelectedGevarenId);
            //SelectedGevarenId.Clear();
            dataGridViewWeergaveLosseItems.DataSource = comunicator.GetSelectedGevaren(SelectedGevarenId);
        }





        private void buttonAddFromTemplateGevaren_Click(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxViewTemplate.SelectedItem.ToString();
            if (!comboBoxWeergaveTemplateNaam.Items.Contains(selectedTemplateName))
            {
                comboBoxWeergaveTemplateNaam.Items.Add(selectedTemplateName);
            }
            string gevaarID = "";
            foreach (DataGridViewRow row in dataGridViewTemplateViewGevaren.SelectedRows)
            {
                gevaarID = row.Cells[0].Value.ToString();
                if (!SelectedTemplateGevaarId.Contains(gevaarID))
                {
                    SelectedTemplateGevaarId.Add(gevaarID);
                }
            }
            dataGridViewTemplateViewGevaren.ClearSelection();

            List<string> temp = controler.CheckObjectForDubbleGevaren(SelectedTemplateGevaarId);
            SelectedTemplateGevaarId = temp;
            //SelectedTemplateGevaarId.Clear();
        }




        private void buttonAddFromTemplateIssues_Click(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxViewTemplate.SelectedItem.ToString();
            if (!comboBoxWeergaveTemplateNaam.Items.Contains(selectedTemplateName))
            {
                comboBoxWeergaveTemplateNaam.Items.Add(selectedTemplateName);
            }

            string issueID = "";
            foreach (DataGridViewRow row in dataGridViewTemplateViewIssues.SelectedRows)
            {
                issueID = row.Cells[0].Value.ToString();

                if (!SelectedTemplateIssueId.Contains(issueID))
                {
                    SelectedTemplateIssueId.Add(issueID);
                }
            }
            dataGridViewTemplateViewIssues.ClearSelection();
            controler.CheckObjectForDubbleGevarenUitIssues(SelectedTemplateIssueId);
            
            //SelectedTemplateIssueId.Clear();
            //CheckForDubble();
        }




        private void buttonAddFromObject_Click(object sender, EventArgs e)
        {
            string selectedObjectName = comboBoxViewObjectNaam.SelectedItem.ToString();
            if (!comboBoxWeergaveObjectNaam.Items.Contains(selectedObjectName))
            {
                comboBoxWeergaveObjectNaam.Items.Add(selectedObjectName);
            }

            string issueID = "";
            foreach (DataGridViewRow row in dataGridViewObjectView.SelectedRows)
            {
                issueID = row.Cells[0].Value.ToString();
                if (!SelectedObjectIssueId.Contains(issueID))
                {
                    SelectedObjectIssueId.Add(issueID);
                }
            }
            controler.CheckObjectForDubbleGevarenUitIssues(SelectedObjectIssueId);
            dataGridViewObjectView.ClearSelection();

        }
    }
}
