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
        private string ObjectNaam;
        private string ObjectID;
        private KeuzeMenus keuzeMenus;
        private List<string> SelectedGevarenId;
        //public AddRisico()
        //{
        //    InitializeComponent();
        //    comunicator = new Datacomunication();
        //    LoadData();
        //}
        public AddRisico(string objectNaam, string objectID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = KeuzeMenus.GetInstance();
            SelectedGevarenId = new List<string>();
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
                   // comboBoxWeergaveObjectNaam.Items.Add(objectNaam);
                }
            }

            List<string> templateNamenList = keuzeMenus.GetTemplateNamen();
            foreach (string templateNaam in templateNamenList)
            {
                comboBoxViewTemplate.Items.Add(templateNaam);
                //comboBoxWeergaveTemplateNaam.Items.Add(templateNaam);
            }

        }

        




        private void buttonVoegSelectieToe_Click(object sender, EventArgs e)
        {
            //for list selectie id, datacom . add gevaar to object
            foreach (string gevaarId in SelectedGevarenId)
            {
                comunicator.AddGevaarToObject(ObjectID, gevaarId);
            }
            this.Close();
        }

        private void buttonCreateNewGevaar_Click(object sender, EventArgs e)
        {
            Form editRisicosForm = new EditRisicos();
            editRisicosForm.ShowDialog();
            dataGridViewLosseItems.DataSource = comunicator.GetGevarenTable();
        }

        private void dataGridViewRisicos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string gevaarID = dataGridViewLosseItems.SelectedRows[0].Cells[0].Value.ToString();
                if (!SelectedGevarenId.Contains(gevaarID))
                {
                    SelectedGevarenId.Add(gevaarID);
                    textBoxSelectedItems.Text += gevaarID + ", ";
                }
        }

        private void comboBoxDiscipline_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewLosseItems.DataSource = comunicator.GetGevarenTableByDiscipline(comboBoxDiscipline.SelectedItem.ToString());
        }

        private void comboBoxWeergaveObjectNaam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxWeergaveTemplateNaam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxViewTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewTemplateViewIssues.DataSource = comunicator.GetTemplateGevarenByName(comboBoxViewTemplate.SelectedItem.ToString());//TemplateID);
            dataGridViewTemplateViewGevaren.DataSource = comunicator.GetTemplateIssuesByName(comboBoxViewTemplate.SelectedItem.ToString());//TemplateID);
        }

        private void comboBoxViewObjectNaam_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewObjectView.DataSource = comunicator.GetObjectIssuesByObjectName(comboBoxViewObjectNaam.SelectedItem.ToString());
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






            dataGridViewLosseItems.ClearSelection();

        }





        private void buttonAddFromTemplateGevaren_Click(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxViewTemplate.SelectedItem.ToString();
            if (!comboBoxWeergaveTemplateNaam.Items.Contains(selectedTemplateName))
            {
                comboBoxWeergaveTemplateNaam.Items.Add(selectedTemplateName);
            }





            dataGridViewTemplateViewGevaren.ClearSelection();

        }




        private void buttonAddFromTemplateIssues_Click(object sender, EventArgs e)
        {
            string selectedTemplateName = comboBoxViewTemplate.SelectedItem.ToString();
            if (!comboBoxWeergaveTemplateNaam.Items.Contains(selectedTemplateName))
            {
                comboBoxWeergaveTemplateNaam.Items.Add(selectedTemplateName);
            }
            




            dataGridViewTemplateViewIssues.ClearSelection();

        }




        private void buttonAddFromObject_Click(object sender, EventArgs e)
        {
            string selectedObjectName = comboBoxViewObjectNaam.SelectedItem.ToString();
            if (!comboBoxWeergaveObjectNaam.Items.Contains(selectedObjectName))
            {
                comboBoxWeergaveObjectNaam.Items.Add(selectedObjectName);
            }



            dataGridViewObjectView.ClearSelection();

        }
    }
}
