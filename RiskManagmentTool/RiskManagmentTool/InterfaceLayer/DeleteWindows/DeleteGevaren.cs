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
    public partial class DeleteGevaren : Form
    {
        private Datacomunication comunicator;

        private List<string> SelectedGevarenId; 
        private string ObjectNaam;
        private string ObjectID;

        public DeleteGevaren(string objectNaam, string objectID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();

            this.ObjectNaam = objectNaam;
            this.ObjectID = objectID;
            SelectedGevarenId = new List<string>();


            LoadData();
        }

        private void LoadData()
        {
            dataGridViewGekoppeldeGevaren.DataSource = comunicator.GetObjectIssues(ObjectID);
            textBoxObjectNaam.Text = ObjectNaam;
        }

        private void buttonDeleteSelection_Click(object sender, EventArgs e)
        {
            string issueID = "";
            string messageGevarenId = "";
            foreach (DataGridViewRow row in dataGridViewGekoppeldeGevaren.SelectedRows)
            {
                issueID = row.Cells[0].Value.ToString();
                if (!SelectedGevarenId.Contains(issueID))
                {
                    SelectedGevarenId.Add(issueID);
                    messageGevarenId += issueID + ", ";
                }
            }

            string message = "Weet u zeker dat u de gevaren met ID: "+ messageGevarenId +" \n " +
                             "wilt verwijderen?";
            string title = "Reminder Risico waardes";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                foreach (string issueId in SelectedGevarenId)
                {
                    comunicator.DeleteIssueFromObject(ObjectID, issueId);
                }
            }
            else
            {
                // Do something  
            }

            
            
        }

        private void dataGridViewGekoppeldeGevaren_SelectionChanged(object sender, EventArgs e)
        {
            textBoxSelectedItems.Text = string.Empty;
            string issueID = "";
            foreach (DataGridViewRow row in dataGridViewGekoppeldeGevaren.SelectedRows)
            {
                issueID = row.Cells[0].Value.ToString();
                textBoxSelectedItems.Text += issueID + ", ";
            }

        }
    }
    
}
