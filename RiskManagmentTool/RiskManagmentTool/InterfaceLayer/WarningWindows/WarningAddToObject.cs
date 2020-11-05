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

namespace RiskManagmentTool.InterfaceLayer.WarningWindows
{
    public partial class WarningAddToObject : Form
    {
        private Datacomunication comunicator;
        private string ObjectIssueID;
        public WarningAddToObject()
        {

            InitializeComponent();

            comunicator = new Datacomunication();
        }

        public void MakeWarningOnIssue(string objectId, string objectIssueId, string issueToAddId, string gevaarId)
        {
            List<string> issueInfo = comunicator.GetIssueInfo(objectIssueId);
            ObjectIssueID = objectIssueId;
            textBoxGevaarId.Text = gevaarId;
            textBoxObjectIssueId.Text = issueInfo[0];
            textBoxSituatie.Text = issueInfo[1];
            textBoxGebeurtenis.Text = issueInfo[2];
            textBoxIssueToAddID.Text = issueToAddId;


            dataGridViewMaatregelenCurrentIssue.DataSource = comunicator.GetIssueMaatregelen(objectIssueId);
            dataGridViewMaatregelenNewIssue.DataSource = comunicator.GetIssueMaatregelen(issueToAddId);

            int x = 0;

        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Form issueRisicoDetails = new IssueRisicoDetails(ObjectIssueID);
            issueRisicoDetails.Show();

        }
    }
}
