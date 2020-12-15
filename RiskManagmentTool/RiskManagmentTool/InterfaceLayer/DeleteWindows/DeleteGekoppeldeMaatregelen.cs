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

namespace RiskManagmentTool.InterfaceLayer.DeleteWindows
{
    public partial class DeleteGekoppeldeMaatregelen : Form
    {
        private Datacomunication comunicator;

        private string IssueID;

        public DeleteGekoppeldeMaatregelen(string issueID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            IssueID = issueID;


            LoadData();

        }

        private void LoadData()
        {
            dataGridViewIssueMaatregelen.DataSource = comunicator.GetIssueMaatregelen(IssueID);

        }

        private void dataGridViewIssueMaatregelen_SelectionChanged(object sender, EventArgs e)
        {
            textBoxSelectedItems.Text = string.Empty;
            string maatregelID = "";
            foreach (DataGridViewRow row in dataGridViewIssueMaatregelen.SelectedRows)
            {
                maatregelID = row.Cells[0].Value.ToString();
                textBoxSelectedItems.Text += maatregelID + ", ";
            }
        }

        private void dataGridViewIssueMaatregelen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewIssueMaatregelen.ClearSelection();
        }

        private void buttonDeleteSelection_Click(object sender, EventArgs e)
        {
            //string issueID = "";
            //string messageGevarenId = "";
            //foreach (DataGridViewRow row in dataGridViewIssueMaatregelen.SelectedRows)
            //{
            //    issueID = row.Cells[0].Value.ToString();
            //    if (!SelectedGevarenId.Contains(issueID))
            //    {
            //        SelectedGevarenId.Add(issueID);
            //        messageGevarenId += issueID + ", ";
            //    }
            //}

            //string message = "Weet u zeker dat u de gevaren met ID: " + messageGevarenId + " \n " +
            //                 "wilt verwijderen?";
            //string title = "Reminder Risico waardes";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons);
            //if (result == DialogResult.Yes)
            //{
            //    foreach (string issueId in SelectedGevarenId)
            //    {
            //        comunicator.DeleteIssueFromObject(ObjectID, issueId);
            //    }
            //    this.Close();
            //}
            //else
            //{
            //    // Do something  
            //}
        }
    }
}
