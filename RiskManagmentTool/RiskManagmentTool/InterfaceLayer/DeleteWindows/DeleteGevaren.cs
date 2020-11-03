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
            string gevaarID = "";
            string messageGevarenId = "";
            foreach (DataGridViewRow row in dataGridViewGekoppeldeGevaren.SelectedRows)
            {
                gevaarID = row.Cells[0].Value.ToString();
                if (!SelectedGevarenId.Contains(gevaarID))
                {
                    SelectedGevarenId.Add(gevaarID);
                    messageGevarenId += gevaarID + ", ";
                }
            }

            string message = "Weet u zeker dat u de gevaren met ID: "+ messageGevarenId +" \n " +
                             "wilt verwijderen?";
            string title = "Reminder Risico waardes";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                comunicator.DeleteIssuesFromObject(ObjectID, SelectedGevarenId);
            }
            else
            {
                // Do something  
            }
            
        }
    }
    
}
