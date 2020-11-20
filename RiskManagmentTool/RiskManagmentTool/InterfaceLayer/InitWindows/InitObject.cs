﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.InitWindows
{
    public partial class InitObject : Form
    {
        private string ProjectId;
        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        public InitObject(string projectId, string projectNaam)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            this.ProjectId = projectId;
            LoadData(projectNaam);
        }

        private void LoadData(string projectNaam)
        {
            textBoxProjectNaam.Text = projectNaam;
            FillCombobox();
        }

        private void buttonCreateObject_Click(object sender, EventArgs e)
        {
            string projectId = ProjectId;
            string projectNaam = textBoxProjectNaam.Text;
            string objectNaam = textBoxObjectNaam.Text;
            string objectType = comboBoxObjectType.SelectedItem.ToString();
            string objectOmschrijving = textBoxObjectOmschrijving.Text;
            int objectID = comunicator.MakeObject(projectId, projectNaam, objectNaam, objectType, objectOmschrijving);
            
            Form editObject = new EditObjecten(objectID.ToString(), projectNaam, objectNaam, objectType, objectOmschrijving);
            editObject.Show();
            this.Close();
        }

        private void FillCombobox()
        {
            //combobox project lijsten
            Dictionary<int, string> typeObjectList = keuzeMenus.GetTypeObjectMenu();
            foreach (KeyValuePair<int, string> kvp in typeObjectList)
            {
                comboBoxObjectType.Items.Add(kvp.Value);
            }

            //List<string> objectTypes = comunicator.GetObjectTypes();
            //foreach (string typeString in objectTypes)
            //{
            //    comboBoxObjectType.Items.Add(typeString);
            //}
        }
    }
}
