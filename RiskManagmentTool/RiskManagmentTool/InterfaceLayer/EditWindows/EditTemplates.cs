﻿using System;
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
        private List<string> SelectedGevarenId;
        private List<string> SelectedIssuesId;
        private string TemplateID;

        public EditTemplates(string templateId)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = KeuzeMenus.GetInstance();
            SelectedGevarenId = new List<string>();
            SelectedIssuesId = new List<string>();
            TemplateID = templateId;
            LoadData();
            LoadCombobox();
        }

        private void LoadData()
        {
            textBoxSelectedIssues.Text = "";
            textBoxTemplateID.Text = TemplateID;

            dataGridViewAddIssue.DataSource = comunicator.GetAllIssues();
            dataGridViewAddGevaar.DataSource = comunicator.GetGevarenTable();
            //dataGridViewAddIssue.ClearSelection();
            
        }

        private void LoadCombobox()
        {
            List<string> templateTypesList = keuzeMenus.GetTemplateTypesMenu();
            foreach (string typeString in templateTypesList)
            {
                comboBoxTemplateType.Items.Add(typeString);
            }

            List<string> templateToepassingList = keuzeMenus.GetTemplateToepassingenMenu();
            foreach (string typeString in templateToepassingList)
            {
                comboBoxTemplateToepassing.Items.Add(typeString);
            }

        }

        private void ReloadTemplateData()
        {
            dataGridViewGekoppeldeGevaren.DataSource = comunicator.GetTemplateGevaren(TemplateID);
            dataGridViewGekoppeldeIssues.DataSource = comunicator.GetTemplateIssues(TemplateID);

        }



        private void buttonConfirmSelection_Click(object sender, EventArgs e)
        {
            foreach (string gevaarId in SelectedGevarenId)
            {
                comunicator.AddGevaarToTemplate(TemplateID, gevaarId);
            }
            foreach (string issueId in SelectedIssuesId)
            {
                comunicator.AddIssueToTemplate(TemplateID, issueId);
            }
            ReloadTemplateData();
        }

        private void dataGridViewAddIssue_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string issueID = dataGridViewAddIssue.SelectedRows[0].Cells[0].Value.ToString();
            //foreach (string selected in SelectedGevarenId)
            //{
            if (!SelectedIssuesId.Contains(issueID))
            {
                SelectedIssuesId.Add(issueID);
                textBoxSelectedIssues.Text += issueID + ", ";
            }
            // }



            //list int selectie id's add gevaar id


            //Form editProjecten = new EditProjecten(projectNaam);//,

            //editProjecten.Show();



        }

        private void buttonAddSelection_Click(object sender, EventArgs e)
        {
           // for (int i = dataGridViewAddIssue.SelectedRows.Count - 1; i >= 0; i--)
           // {
           //     textBoxSelectedIssues.Text += dataGridViewAddIssue.SelectedRows[i].Cells[0].Value.ToString();
                
           //     // ...
           // }
           //// = dataGridViewAddIssue.SelectedRows[0].Cells[0].Value.ToString();
           // dataGridViewAddIssue.ClearSelection();
        }

        private void dataGridViewAddIssue_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewAddIssue.ClearSelection();
        }
    }
}
