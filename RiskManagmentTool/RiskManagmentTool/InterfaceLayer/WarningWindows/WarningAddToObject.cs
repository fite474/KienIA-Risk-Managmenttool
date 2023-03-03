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
        private bool switchToCustomMaatregelen;
        private bool switchToCustomBeoordeling;

        


        private Datacomunication comunicator;
        private string ObjectIssueID;
        private string IssueToAddID;
        private DataControler controler;


        public WarningAddToObject()
        {

            InitializeComponent();
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            comunicator = new Datacomunication();
            
            
            SetSelectionSettings();
        }

        private void SetSelectionSettings()
        {
            switchToCustomMaatregelen = true;
            switchToCustomBeoordeling = true;
            checkedListBoxWarningSettings.SetItemChecked(0, true);
            checkedListBoxWarningSettings.SetItemChecked(1, true);
            //checkedListBoxWarningSettings.SetItemChecked(2, true);
        }

        public void MakeWarningOnIssue(string objectId, string objectIssueId, string issueToAddId, string gevaarId)
        {
            List<string> issueInfo = comunicator.GetIssueInfo(objectIssueId);
            ObjectIssueID = objectIssueId;
            IssueToAddID = issueToAddId;
            controler = new DataControler(objectIssueId);

            textBoxGevaarId.Text = gevaarId;
            textBoxObjectIssueId.Text = issueInfo[0];
            textBoxSituatie.Text = issueInfo[1];
            textBoxGebeurtenis.Text = issueInfo[2];
            textBoxGevaar.Text = issueInfo[3];

            textBoxIssueToAddID.Text = issueToAddId;

            textBoxWarningMessage.Text = "Het huidige object bevat al een issue waarbij het gevaar ID overeen" +
                " komt met het issue dat u probeert toe te voegen. \n" +
                "Maak een keuze wat u wilt overnemen van het gekozen issue";

            textBoxHelp.Text = "Selecteer de maatregelen die u wilt overnemen en druk vervolgens op 'Save'. ";

            dataGridViewMaatregelenCurrentIssue.DataSource = comunicator.GetIssueMaatregelen(objectIssueId);
            dataGridViewMaatregelenNewIssue.DataSource = comunicator.GetIssueMaatregelen(issueToAddId);
            
        }

        //public void MakeWarningOnMaatregelen()
        //{

        //    textBoxWarningMessage.Text = "Het huidige object bevat al een issue waarbij het gevaar ID overeen" +
        //        " komt met het issue dat u probeert toe te voegen. \n" +
        //        "Maak een keuze wat u wilt overnemen van het gekozen issue";

        //}

       

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Form compareIssueRisicoBeoordeling = new CompareIssueRisicoBeoordeling(ObjectIssueID, IssueToAddID);
            if (compareIssueRisicoBeoordeling.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            compareIssueRisicoBeoordeling.Dispose();
            //issueRisicoDetails.Show();

        }

        private void SwitchCheckState()
        {
            //if (checkedListBoxWarningSettings.GetItemChecked(3) && switchToCustomMaatregelen == true)
            //{
            //    switchToCustomMaatregelen = false;
                
            //}
            //if (checkedListBoxWarningSettings.GetItemChecked(4) && switchToCustomBeoordeling == true)
            //{
            //    switchToCustomBeoordeling = false;
            //}

        }

        private void checkedListBoxWarningSettings_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //this.BeginInvoke((MethodInvoker)(
            //() => SwitchCheckState()));
        }

        private void buttonOnlySelectedMaatregelen_Click(object sender, EventArgs e)
        {
            //checkedListBoxCustomSettings.SetItemChecked(0, true);

            //List<string> selectedMaatregelen = new List<string>();
            //foreach (DataGridViewRow row in dataGridViewMaatregelenNewIssue.SelectedRows)
            //{
            //    string selectedMaatregelID = row.Cells[0].Value.ToString();
            //    if (!selectedMaatregelen.Contains(selectedMaatregelID))
            //    {
            //        selectedMaatregelen.Add(selectedMaatregelID);
            //    }
            //}
            //int x = 0;
        }

        private void dataGridViewMaatregelenCurrentIssue_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewMaatregelenCurrentIssue.ClearSelection();//SelectAll();
            
        }

        private void dataGridViewMaatregelenNewIssue_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewMaatregelenNewIssue.ClearSelection();
        }

        private void dataGridViewMaatregelenNewIssue_SelectionChanged(object sender, EventArgs e)
        {
            //int rowIndex = 0;
            //foreach (DataGridViewRow row in dataGridViewMaatregelenNewIssue.Rows)
            //{
                
            //    if (row.Selected)
            //    {
            //        string maatregelID = row.Cells[0].Value.ToString();
            //        dataGridViewMaatregelenCurrentIssue.Rows[rowIndex].Selected = false;
            //    }
            //    else
            //    {
            //        dataGridViewMaatregelenCurrentIssue.Rows[rowIndex].Selected = true;
            //    }
            //    rowIndex++;
            //}
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            List<string> SelectedGevarenId = new List<string>();
            string gevaarID = "";
            foreach (DataGridViewRow row in dataGridViewMaatregelenNewIssue.SelectedRows)
            {
                gevaarID = row.Cells[0].Value.ToString();
                if (!SelectedGevarenId.Contains(gevaarID))
                {
                    SelectedGevarenId.Add(gevaarID);
                }
            }

            dataGridViewMaatregelenNewIssue.ClearSelection();
            controler.CheckIssueForDubbleMaatregelen(SelectedGevarenId);



            this.Close();
        }
    }
}
