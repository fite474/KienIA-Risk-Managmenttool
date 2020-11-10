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
            checkedListBoxWarningSettings.SetItemChecked(2, true);
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


        }

        private void MakeCustomBeoordeling()
        {
            //string issueID = IssueID;//textBoxIssueID.Text;
            //string init_Se = textBoxInit_Se.Text;
            //string init_Fr = textBoxInit_Fr.Text;
            //string init_Pr = textBoxInit_Pr.Text;
            //string init_Av = textBoxInit_Av.Text;
            //string init_Cl = textBoxInit_Cl.Text;
            //string init_Risico = textBoxInit_Risico.Text;
            //string init_Se_Comment = textBoxInit_Se_Comment.Text;
            //string init_Fr_Comment = textBoxInit_Fr_Comment.Text;
            //string init_Pr_Comment = textBoxInit_Pr_Comment.Text;
            //string init_Av_Comment = textBoxInit_Av_Comment.Text;
            //string init_Cl_Comment = textBoxInit_Cl_Comment.Text;
            //string init_Risico_Comment = textBoxInitRisico_Comment.Text;
            //string rest_Se = textBoxRest_Se.Text;
            //string rest_Fr = textBoxRest_Fr.Text;
            //string rest_Pr = textBoxRest_Pr.Text;
            //string rest_Av = textBoxRest_Av.Text;
            //string rest_Cl = textBoxRest_Cl.Text;
            //string rest_Risico = textBoxRest_Risico.Text;
            //string rest_Se_Comment = textBoxRest_Se_Comment.Text;
            //string rest_Fr_Comment = textBoxRest_Fr_Comment.Text;
            //string rest_Pr_Comment = textBoxRest_Pr_Comment.Text;
            //string rest_Av_Comment = textBoxRest_Av_Comment.Text;
            //string rest_Cl_Comment = textBoxRest_Cl_Comment.Text;
            //string rest_Risico_Comment = textBoxRest_Risico_Comment.Text;
            //string rest_Ok = checkBoxRest_Risico_Ok.Checked == true ? "1" : "0";//"1";

        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            Form compareIssueRisicoBeoordeling = new CompareIssueRisicoBeoordeling(ObjectIssueID);
            if (compareIssueRisicoBeoordeling.ShowDialog() == DialogResult.OK)
            {

                int x = 0;

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
            checkedListBoxCustomSettings.SetItemChecked(0, true);

            List<string> selectedMaatregelen = new List<string>();
            foreach (DataGridViewRow row in dataGridViewMaatregelenNewIssue.SelectedRows)
            {
                string selectedMaatregelID = row.Cells[0].Value.ToString();
                if (!selectedMaatregelen.Contains(selectedMaatregelID))
                {
                    selectedMaatregelen.Add(selectedMaatregelID);
                }
            }
            int x = 0;
        }

        private void dataGridViewMaatregelenCurrentIssue_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewMaatregelenCurrentIssue.SelectAll();
            
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
    }
}
