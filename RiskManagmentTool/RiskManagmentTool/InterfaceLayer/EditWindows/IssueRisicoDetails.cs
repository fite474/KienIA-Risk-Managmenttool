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

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class IssueRisicoDetails : Form
    {
        private Datacomunication comunicator;
        private string IssueID;
        public IssueRisicoDetails(string issueID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            IssueID = issueID;
            LoadData();
        }

        private void LoadData()
        {
            //textBoxIssueID.Text = IssueID;
            DataTable risicoBeoordelingData = comunicator.GetRisicoBeoordelingFromIssue(IssueID);

            //DataRow row = risicoBeoordelingData.Rows[1];

            textBoxIssueID.Text = IssueID;//risicoBeoordelingData.Columns[1].ToString();//Andere optie is Collums["name"]
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

        //



        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            string issueID = IssueID;//textBoxIssueID.Text;
            string init_Se = textBoxInit_Se.Text;
            string init_Fr = textBoxInit_Fr.Text;
            string init_Pr = textBoxInit_Pr.Text;
            string init_Av = textBoxInit_Av.Text;
            string init_Cl = textBoxInit_Cl.Text;
            string init_Risico = textBoxInit_Risico.Text;
            string init_Se_Comment = textBoxInit_Se_Comment.Text;
            string init_Fr_Comment = textBoxInit_Fr_Comment.Text;
            string init_Pr_Comment = textBoxInit_Pr_Comment.Text;
            string init_Av_Comment = textBoxInit_Av_Comment.Text;
            string init_Cl_Comment = textBoxInit_Cl_Comment.Text;
            string init_Risico_Comment = textBoxInitRisico_Comment.Text;
            string rest_Se = textBoxRest_Se.Text;
            string rest_Fr = textBoxRest_Fr.Text;
            string rest_Pr = textBoxRest_Pr.Text;
            string rest_Av = textBoxRest_Av.Text;
            string rest_Cl = textBoxRest_Cl.Text;
            string rest_Risico = textBoxRest_Risico.Text;
            string rest_Se_Comment = textBoxRest_Se_Comment.Text;
            string rest_Fr_Comment = textBoxRest_Fr_Comment.Text;
            string rest_Pr_Comment = textBoxRest_Pr_Comment.Text;
            string rest_Av_Comment = textBoxRest_Av_Comment.Text;
            string rest_Cl_Comment = textBoxRest_Cl_Comment.Text;
            string rest_Risico_Comment = textBoxRest_Risico_Comment.Text;
            string rest_Ok = checkBoxRest_Risico_Ok.Checked == true? "1" : "0";//"1";
            //if (true)
            //{

            comunicator.UpdateRisicoBeoordeling(issueID, init_Se, init_Fr, init_Pr, init_Av, init_Cl, init_Risico,
                                            init_Se_Comment, init_Fr_Comment, init_Pr_Comment, init_Av_Comment, init_Cl_Comment, init_Risico_Comment,
                                            rest_Se, rest_Fr, rest_Pr, rest_Av, rest_Cl, rest_Risico,
                                            rest_Se_Comment, rest_Fr_Comment, rest_Pr_Comment, rest_Av_Comment, rest_Cl_Comment, rest_Risico_Comment, rest_Ok);
            //}
            this.Close();
        }
    }
}
