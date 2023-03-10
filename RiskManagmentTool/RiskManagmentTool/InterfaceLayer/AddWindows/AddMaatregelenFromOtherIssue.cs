using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    public partial class AddMaatregelenFromOtherIssue : Form
    {
        private Datacomunication comunicator;

        private string OtherIssueID;
        private string CurrentIssueID;
        private List<string> SelectedMaatregelId;
        private DataControler controler;

        private BindingSource issueMaatregelenData;

        public AddMaatregelenFromOtherIssue(string objectNaam, string currentIssueID, string otherIssueID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            SelectedMaatregelId = new List<string>();
            
            OtherIssueID = otherIssueID;
            CurrentIssueID = currentIssueID;
            controler = new DataControler(CurrentIssueID);
            textBoxIssueID.Text = otherIssueID;
            //textBoxGevaarID.Text
            textBoxObjectNaam.Text = objectNaam;

            LoadData();
        }

        private void LoadData()
        {
            issueMaatregelenData = comunicator.GetIssueMaatregelen(OtherIssueID);
            advancedDataGridViewIssueMaatregelen.DataSource = issueMaatregelenData;

        }

        private void buttonAddSelection_Click(object sender, EventArgs e)
        {
            string maatregelID = "";
            foreach (DataGridViewRow row in advancedDataGridViewIssueMaatregelen.SelectedRows)
            {
                maatregelID = row.Cells[0].Value.ToString();

                if (!SelectedMaatregelId.Contains(maatregelID))
                {
                    SelectedMaatregelId.Add(maatregelID);
                    //textBoxSelectedMaatregelen.Text += maatregelID + ", ";
                }

            }
            advancedDataGridViewIssueMaatregelen.ClearSelection();
            controler.CheckIssueForDubbleMaatregelen(SelectedMaatregelId);
            SelectedMaatregelId.Clear();
            this.Close();
        }


        private void advancedDataGridViewIssueMaatregelen_FilterStringChanged(object sender, EventArgs e)
        {
            this.issueMaatregelenData.Filter = this.advancedDataGridViewIssueMaatregelen.FilterString;
        }

        private void advancedDataGridViewIssueMaatregelen_SortStringChanged(object sender, EventArgs e)
        {
            this.issueMaatregelenData.Sort = this.advancedDataGridViewIssueMaatregelen.SortString;
        }
    }
}
