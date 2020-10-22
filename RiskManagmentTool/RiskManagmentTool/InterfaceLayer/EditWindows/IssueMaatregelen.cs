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
using RiskManagmentTool.InterfaceLayer.AddWindows;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class IssueMaatregelen : Form
    {
        private Datacomunication comunicator;
        private int issueNmr;
        public IssueMaatregelen()
        {
            issueNmr = 0;
            InitializeComponent();
            LoadData();
        }
        public IssueMaatregelen(string issueId)
        {
            InitializeComponent();
            LoadData();
            textBoxNaamObject.Text = issueId;
            issueNmr = 0;
        }

        private void LoadData()
        {
            comunicator = new Datacomunication();
            dataGridViewIssueMaatregelen.DataSource = comunicator.GetMaatregelTable();

        }

        private void buttonRisicoDetails_Click(object sender, EventArgs e)
        {
            Form issueRisicoDetails = new IssueRisicoDetails();
            issueRisicoDetails.Show();
        }

        private void buttonAddNewMaatregel_Click(object sender, EventArgs e)
        {
            Form addMaatregel = new AddMaatregel();
            addMaatregel.Show();
        }

        private void buttonNextIssue_Click(object sender, EventArgs e)
        {
            string message = "Weet u zeker dat de risico waardes ook correct zijn?";
            string title = "Reminder Risico waardes";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                //this.Close();
            }
            else
            {
                // Do something  
            }
            issueNmr++;
            textBoxNaamObject.Text = issueNmr.ToString();
        }
    }
}
