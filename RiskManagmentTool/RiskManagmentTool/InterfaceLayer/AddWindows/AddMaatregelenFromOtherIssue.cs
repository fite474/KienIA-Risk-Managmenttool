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

namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    public partial class AddMaatregelenFromOtherIssue : Form
    {
        private Datacomunication comunicator;

        private string OtherIssueID;
        private string CurrentIssueID;
        public AddMaatregelenFromOtherIssue(string objectNaam, string currentIssueID, string otherIssueID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            OtherIssueID = otherIssueID;
            CurrentIssueID = currentIssueID;

            textBoxIssueID.Text = otherIssueID;
            textBoxObjectNaam.Text = objectNaam;

            LoadData();

            

        }

        private void LoadData()
        {
            dataGridViewIssueMaatregelen.DataSource = comunicator.GetIssueMaatregelen(OtherIssueID);

        }
    }
}
