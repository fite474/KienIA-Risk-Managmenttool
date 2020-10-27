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
            textBoxIssueID.Text = IssueID;
            //textBoxProjectNaam.Text = projectNaam;
            //textBoxObjectNaam.Text = ObjectNaam;
            //textBoxOmschrijving.Text = objectOmschrijving;

        }





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
            string rest_Ok = "1";
            //if (true)
            //{

            comunicator.UpdateRisicoBeoordeling(issueID, init_Se, init_Fr, init_Pr, init_Av, init_Cl, init_Risico,
                                            init_Se_Comment, init_Fr_Comment, init_Pr_Comment, init_Av_Comment, init_Cl_Comment, init_Risico_Comment,
                                            rest_Se, rest_Fr, rest_Pr, rest_Av, rest_Cl, rest_Risico,
                                            rest_Se_Comment, rest_Fr_Comment, rest_Pr_Comment, rest_Av_Comment, rest_Cl_Comment, rest_Risico_Comment, rest_Ok);





            //}

        }
    }
}
