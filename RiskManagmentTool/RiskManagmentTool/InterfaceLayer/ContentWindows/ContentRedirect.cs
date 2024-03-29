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

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentRedirect : Form
    {
        private Datacomunication comunicator;
        public ContentRedirect()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
        }

        private void buttonZoekIssueNummer_Click(object sender, EventArgs e)
        {
            string zoekNummer = textBoxZoekIssueNummer.Text;
            string objectId = comunicator.GetObjectIdByIssueNmr(zoekNummer);


            if (!objectId.Equals("0"))
            {
                List<string> objectInfo = comunicator.GetObjectInfo(objectId);
                string projectId = objectInfo[0];
                string projectNaam = objectInfo[1];
                string objectNaam = objectInfo[2];
                string objectType = objectInfo[3];
                string objectOmschrijving = objectInfo[4];
                EditObjecten editObject = new EditObjecten(objectId, projectNaam, objectNaam, objectType, objectOmschrijving);
                editObject.OpenedFromRedirectionPage = true;
                editObject.RedirectionPageRequestedIssueID = int.Parse(zoekNummer);
                editObject.Show();

            }
            else
            {
                string message = "Geen zoekresultaten";
                string title = "Reminder Risico waardes";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);

                //if (result == DialogResult.Yes)
                //{
                //    //this.Close();
                //}
                //else
                //{
                //    // Do something  
                //}
            }

        }

        private void textBoxZoekIssueNummer_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxZoekIssueNummer.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBoxZoekIssueNummer.Text = textBoxZoekIssueNummer.Text.Remove(textBoxZoekIssueNummer.Text.Length - 1);
            }

        }
    }
}
