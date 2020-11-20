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
        private Risicograaf risicograaf;
        private string IssueID;
        private string test;
        public IssueRisicoDetails(string issueID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            risicograaf = new Risicograaf();
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
            test = textBoxInit_Se_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(8).ToString();
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
        public void SetReadOnlyMode()
        {
            textBoxIssueID.Enabled = false;//risicoBeoordelingData.Columns[1].ToString();//Andere optie is Collums["name"]
            textBoxInit_Se.Enabled = false; ;//risicoBeoordelingData.Columns[2].ToString();
            textBoxInit_Fr.Enabled = false;
            textBoxInit_Pr.Enabled = false;
            textBoxInit_Av.Enabled = false;
            textBoxInit_Cl.Enabled = false;
            textBoxInit_Risico.Enabled = false;
            textBoxInit_Se_Comment.Enabled = false;
            textBoxInit_Fr_Comment.Enabled = false;
            textBoxInit_Pr_Comment.Enabled = false;
            textBoxInit_Av_Comment.Enabled = false;
            textBoxInit_Cl_Comment.Enabled = false;
            textBoxInitRisico_Comment.Enabled = false;
            textBoxRest_Se.Enabled = false;
            textBoxRest_Fr.Enabled = false;
            textBoxRest_Pr.Enabled = false;
            textBoxRest_Av.Enabled = false;
            textBoxRest_Cl.Enabled = false;
            textBoxRest_Risico.Enabled = false;
            textBoxRest_Se_Comment.Enabled = false;
            textBoxRest_Fr_Comment.Enabled = false;
            textBoxRest_Pr_Comment.Enabled = false;
            textBoxRest_Av_Comment.Enabled = false;
            textBoxRest_Cl_Comment.Enabled = false;
            textBoxRest_Risico_Comment.Enabled = false;
            checkBoxRest_Risico_Ok.Enabled = false;
            buttonConfirm.Enabled = false;

        }

        private void CalculateInitRisk(int init_Se, int init_Fr, int init_Pr, int init_Av)
        {
            Tuple<int, int> initValues = risicograaf.CalculateSilMode(init_Se, init_Fr, init_Pr, init_Av);
            int init_Cl = initValues.Item1;
            int init_Risk = initValues.Item2;

            textBoxInit_Cl.Text = init_Cl.ToString();
            textBoxInit_Risico.Text = init_Risk.ToString();
        }

        private void CalculateRestRisk(int rest_Se, int rest_Fr, int rest_Pr, int rest_Av)
        {
            Tuple<int, int> restValues = risicograaf.CalculateSilMode(rest_Se, rest_Fr, rest_Pr, rest_Av);
            int rest_Cl = restValues.Item1;
            int rest_Risk = restValues.Item2;

            textBoxRest_Cl.Text = rest_Cl.ToString();
            textBoxRest_Risico.Text = rest_Risk.ToString();
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

        private void IssueRisicoDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBoxInit_Se_Comment.Text != test)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file...
                }
            }
        }

        private void checkedListBoxRisicograafMethode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBoxRisicograafMethode.Items.Count; ++ix)
                if (ix != e.Index) checkedListBoxRisicograafMethode.SetItemChecked(ix, false);
        }



        #region init values changed

        private void CheckInitValues()
        {
            int.TryParse(textBoxInit_Se.Text, out int seValue);
            int.TryParse(textBoxInit_Fr.Text, out int frValue);
            int.TryParse(textBoxInit_Pr.Text, out int prValue);
            int.TryParse(textBoxInit_Av.Text, out int avValue);

            if (seValue > 0 &&
                frValue > 0 &&
                prValue > 0 &&
                avValue > 0)
            {
                CalculateInitRisk(seValue, frValue, prValue, avValue);
            }
        }

        private void textBoxInit_Se_TextChanged(object sender, EventArgs e)
        {
            CheckInitValues();
        }

        private void textBoxInit_Fr_TextChanged(object sender, EventArgs e)
        {
            CheckInitValues();
        }

        private void textBoxInit_Pr_TextChanged(object sender, EventArgs e)
        {
            CheckInitValues();
        }

        private void textBoxInit_Av_TextChanged(object sender, EventArgs e)
        {
            CheckInitValues();
        }

        #endregion init values changed

        #region rest values changed

        private void CheckRestValues()
        {
            int.TryParse(textBoxRest_Se.Text, out int seValue);
            int.TryParse(textBoxRest_Fr.Text, out int frValue);
            int.TryParse(textBoxRest_Pr.Text, out int prValue);
            int.TryParse(textBoxRest_Av.Text, out int avValue);

            if (seValue > 0 &&
                frValue > 0 &&
                prValue > 0 &&
                avValue > 0)
            {
                CalculateRestRisk(seValue, frValue, prValue, avValue);
            }
        }

        private void textBoxRest_Se_TextChanged(object sender, EventArgs e)
        {
            CheckRestValues();
        }

        private void textBoxRest_Fr_TextChanged(object sender, EventArgs e)
        {
            CheckRestValues();
        }

        private void textBoxRest_Pr_TextChanged(object sender, EventArgs e)
        {
            CheckRestValues();
        }

        private void textBoxRest_Av_TextChanged(object sender, EventArgs e)
        {
            CheckRestValues();
        }


        #endregion rest values changed


    }
}
