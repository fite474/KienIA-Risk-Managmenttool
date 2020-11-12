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

namespace RiskManagmentTool.InterfaceLayer.WarningWindows
{
    public partial class CompareIssueRisicoBeoordeling : Form
    {
        private Datacomunication comunicator;

        private string CurrentIssueID;
        private string IssueToAddID;

        public CompareIssueRisicoBeoordeling(string currentIssueID, string issueToAddID)
        {
            InitializeComponent();
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;

            comunicator = new Datacomunication();

            CurrentIssueID = currentIssueID;
            IssueToAddID = issueToAddID;

            LoadDataCurrentObject();
            LoadDataCopiedItem();
        }

        private void LoadDataCurrentObject()
        {
            DataTable risicoBeoordelingData = comunicator.GetRisicoBeoordelingFromIssue(CurrentIssueID);


            List<string> issueInfo = comunicator.GetIssueInfo(CurrentIssueID);

            textBoxSituatie.Text = issueInfo[1];
            textBoxGebeurtenis.Text = issueInfo[2];
            textBoxGevaar.Text = issueInfo[3];


            textBoxIssueID.Text = CurrentIssueID;//risicoBeoordelingData.Columns[1].ToString();//Andere optie is Collums["name"]
            textBoxInit_Se.Text = risicoBeoordelingData.Rows[0].Field<int?>(2).ToString();//risicoBeoordelingData.Columns[2].ToString();
            textBoxInit_Fr.Text = risicoBeoordelingData.Rows[0].Field<int?>(3).ToString();
            textBoxInit_Pr.Text = risicoBeoordelingData.Rows[0].Field<int?>(4).ToString();
            textBoxInit_Av.Text = risicoBeoordelingData.Rows[0].Field<int?>(5).ToString();
            textBoxInit_Cl.Text = risicoBeoordelingData.Rows[0].Field<int?>(6).ToString();
            textBoxInit_Risico.Text = risicoBeoordelingData.Rows[0].Field<int?>(7).ToString();
            textBoxInit_Se_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(8).ToString();
            textBoxInit_Fr_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(9).ToString();
            textBoxInit_Pr_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(10).ToString();
            textBoxInit_Av_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(11).ToString();
            textBoxInit_Cl_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(12).ToString();
            textBoxInitRisico_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(13).ToString();
            textBoxRest_Se.Text = risicoBeoordelingData.Rows[0].Field<int?>(14).ToString();
            textBoxRest_Fr.Text = risicoBeoordelingData.Rows[0].Field<int?>(15).ToString();
            textBoxRest_Pr.Text = risicoBeoordelingData.Rows[0].Field<int?>(16).ToString();
            textBoxRest_Av.Text = risicoBeoordelingData.Rows[0].Field<int?>(17).ToString();
            textBoxRest_Cl.Text = risicoBeoordelingData.Rows[0].Field<int?>(18).ToString();
            textBoxRest_Risico.Text = risicoBeoordelingData.Rows[0].Field<int?>(19).ToString();
            textBoxRest_Se_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(20).ToString();
            textBoxRest_Fr_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(21).ToString();
            textBoxRest_Pr_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(22).ToString();
            textBoxRest_Av_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(23).ToString();
            textBoxRest_Cl_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(24).ToString();
            textBoxRest_Risico_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(25).ToString();
            checkBoxRest_Risico_Ok.Checked = risicoBeoordelingData.Rows[0].Field<string>(26).ToString() == "1";

        }

        private void LoadDataCopiedItem()
        {
            DataTable risicoBeoordelingDataCopiedItem = comunicator.GetRisicoBeoordelingFromIssue(IssueToAddID);

            List<string> issueInfo = comunicator.GetIssueInfo(IssueToAddID);

            textBoxSituatie_IssueToAdd.Text = issueInfo[1];
            textBoxGebeurtenis_IssueToAdd.Text = issueInfo[2];
            textBoxGevaar_IssueToAdd.Text = issueInfo[3];

            textBoxIssueID_IssueToAdd.Text = IssueToAddID;//risicoBeoordelingData.Columns[1].ToString();//Andere optie is Collums["name"]
            textBoxInit_Se_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(2).ToString();//risicoBeoordelingData.Columns[2].ToString();
            textBoxInit_Fr_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(3).ToString();
            textBoxInit_Pr_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(4).ToString();
            textBoxInit_Av_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(5).ToString();
            textBoxInit_Cl_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(6).ToString();
            textBoxInit_Risico_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(7).ToString();
            textBoxInit_Se_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(8).ToString();
            textBoxInit_Fr_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(9).ToString();
            textBoxInit_Pr_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(10).ToString();
            textBoxInit_Av_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(11).ToString();
            textBoxInit_Cl_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(12).ToString();
            textBoxInitRisico_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(13).ToString();
            textBoxRest_Se_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(14).ToString();
            textBoxRest_Fr_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(15).ToString();
            textBoxRest_Pr_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(16).ToString();
            textBoxRest_Av_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(17).ToString();
            textBoxRest_Cl_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(18).ToString();
            textBoxRest_Risico_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<int?>(19).ToString();
            textBoxRest_Se_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(20).ToString();
            textBoxRest_Fr_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(21).ToString();
            textBoxRest_Pr_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(22).ToString();
            textBoxRest_Av_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(23).ToString();
            textBoxRest_Cl_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(24).ToString();
            textBoxRest_Risico_Comment_IssueToAdd.Text = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(25).ToString();
            checkBoxRest_Risico_Ok_IssueToAdd.Checked = risicoBeoordelingDataCopiedItem.Rows[0].Field<string>(26).ToString() == "1";
        }
    }
}
