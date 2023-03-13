using System;
using System.Collections.Generic;
using System.Data;
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
        private int RisicograafSetting;

        public IssueRisicoDetails(string issueID, int risicograafSetting)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            risicograaf = new Risicograaf();
            IssueID = issueID;
            RisicograafSetting = risicograafSetting;
            SetMode(RisicograafSetting);
            LoadData();
        }

        private void SetMode(int risicograafSetting)
        {
            checkedListBoxRisicograafMethode.SetItemChecked(risicograafSetting, true);

            if (risicograafSetting == 0)
            {
                UseSILMode();
            }
            else if (risicograafSetting == 1)
            {
                UsePLMode();
            }

        }

        private void LoadData()
        {
            List<string> issueInfo = comunicator.GetIssueInfo(IssueID);

            //textBoxObjectIssueId.Text = issueInfo[0];
            textBoxSituatie.Text = issueInfo[1];
            textBoxGebeurtenis.Text = issueInfo[2];
            textBoxGevaarType.Text = issueInfo[3];


            //textBoxIssueID.Text = IssueID;
            DataTable risicoBeoordelingData = comunicator.GetRisicoBeoordelingFromIssue(IssueID);

            //DataRow row = risicoBeoordelingData.Rows[1];
            
            textBoxIssueID.Text = IssueID;
            textBoxInit_Se.Text = risicoBeoordelingData.Rows[0].Field<int?>(2).ToString();
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

            //set comboboxes right

            comboBoxInit_Se.SelectedIndex = comboBoxInit_Se.FindString(textBoxInit_Se.Text);
            comboBoxInit_Fr.SelectedIndex = comboBoxInit_Fr.FindString(textBoxInit_Fr.Text);
            comboBoxInit_Pr.SelectedIndex = comboBoxInit_Pr.FindString(textBoxInit_Pr.Text);
            comboBoxInit_Av.SelectedIndex = comboBoxInit_Av.FindString(textBoxInit_Av.Text);


            comboBoxRest_Se.SelectedIndex = comboBoxRest_Se.FindString(textBoxRest_Se.Text);
            comboBoxRest_Fr.SelectedIndex = comboBoxRest_Fr.FindString(textBoxRest_Fr.Text);
            comboBoxRest_Pr.SelectedIndex = comboBoxRest_Pr.FindString(textBoxRest_Pr.Text);
            comboBoxRest_Av.SelectedIndex = comboBoxRest_Av.FindString(textBoxRest_Av.Text);



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

        private void UseSILMode()
        {
            //init se
            comboBoxInit_Se.Items.Add("1 scratches, bruises that are cured by first aid or similar;");
            comboBoxInit_Se.Items.Add("2 more severe scratches, bruises, stabbing, which require medical attention from professionals;");
            comboBoxInit_Se.Items.Add("3 normally irreversible injury; it will be slightly difficult to continue work after healing;");
            comboBoxInit_Se.Items.Add("4 irreversible injury in such a way that it will be very difficult to continue work after healing, if possible at all.");
            //init fr
            comboBoxInit_Fr.Items.Add("2 interval between exposure is more than a year; ");
            comboBoxInit_Fr.Items.Add("3 interval between exposure is more than two weeks but less than or equal to a year;");
            comboBoxInit_Fr.Items.Add("4 interval between exposure is more than a day but less than or equal to two weeks;");
            comboBoxInit_Fr.Items.Add("5 interval between exposure is more than an hour but less than or equal to a day");
            comboBoxInit_Fr.Items.Add("6 interval less than or equal to an hour.");
            //init pr
            comboBoxInit_Pr.Items.Add("1 Negligible");
            comboBoxInit_Pr.Items.Add("2 Rarely:");
            comboBoxInit_Pr.Items.Add("3 Possible:");
            comboBoxInit_Pr.Items.Add("4 Likely");
            comboBoxInit_Pr.Items.Add("5 Very high");
            //init av
            comboBoxInit_Av.Items.Add("1 Likely");
            comboBoxInit_Av.Items.Add("3 Possible");
            comboBoxInit_Av.Items.Add("5 Impossible");


            //rest se
            comboBoxRest_Se.Items.Add("1 scratches, bruises that are cured by first aid or similar;");
            comboBoxRest_Se.Items.Add("2 more severe scratches, bruises, stabbing, which require medical attention from professionals;");
            comboBoxRest_Se.Items.Add("3 normally irreversible injury; it will be slightly difficult to continue work after healing;");
            comboBoxRest_Se.Items.Add("4 irreversible injury in such a way that it will be very difficult to continue work after healing, if possible at all.");
            //rest fr
            comboBoxRest_Fr.Items.Add("2 interval between exposure is more than a year; ");
            comboBoxRest_Fr.Items.Add("3 interval between exposure is more than two weeks but less than or equal to a year;");
            comboBoxRest_Fr.Items.Add("4 interval between exposure is more than a day but less than or equal to two weeks;");
            comboBoxRest_Fr.Items.Add("5 interval between exposure is more than an hour but less than or equal to a day");
            comboBoxRest_Fr.Items.Add("6 interval less than or equal to an hour.");
            //rest pr
            comboBoxRest_Pr.Items.Add("1 Negligible");
            comboBoxRest_Pr.Items.Add("2 Rarely:");
            comboBoxRest_Pr.Items.Add("3 Possible:");
            comboBoxRest_Pr.Items.Add("4 Likely");
            comboBoxRest_Pr.Items.Add("5 Very high");
            //rest av
            comboBoxRest_Av.Items.Add("1 Likely");
            comboBoxRest_Av.Items.Add("3 Possible");
            comboBoxRest_Av.Items.Add("5 Impossible");


        }

        private void UsePLMode()
        {
            //Risk assessment using risk graph figuur a.3

            //start : severity S1 = slightly, S2 = serious

            //S1 -> exposure F1 seldom, F2 frequent geen verschil 

            //s1 -> probability of exposure o1 very low, o2 low -> A1, a2 = 1
            //s1 -> prob o3 high,  = A1, a2 = 2


            //----------------------------------------
            //s2 -> F1 seldom, f2 frequent
            //f1 -> o1 -> a1 possible, a2 impossible = 2
            //f1 -> o2 + a1 = 2.     o2 + a2 = 3
            //f1 -> o3 + a1 = 3.     o3 + a2 = 4
            //init se
            comboBoxInit_Se.Items.Add("1 Slightly");
            comboBoxInit_Se.Items.Add("2 Serious");

            //init fr
            comboBoxInit_Fr.Items.Add("1 Seldom");
            comboBoxInit_Fr.Items.Add("2 Frequent");

            //init pr
            comboBoxInit_Pr.Items.Add("1 Very low");
            comboBoxInit_Pr.Items.Add("2 Low");
            comboBoxInit_Pr.Items.Add("3 High");

            //init av
            comboBoxInit_Av.Items.Add("1 Possible");
            comboBoxInit_Av.Items.Add("2 Impossible");



            //rest se
            comboBoxRest_Se.Items.Add("1 Slightly");
            comboBoxRest_Se.Items.Add("2 Serious");
            //rest fr
            comboBoxRest_Fr.Items.Add("1 Seldom");
            comboBoxRest_Fr.Items.Add("2 Frequent");

            //rest pr
            comboBoxRest_Pr.Items.Add("1 Very low");
            comboBoxRest_Pr.Items.Add("2 Low");
            comboBoxRest_Pr.Items.Add("3 High");
            //rest av
            comboBoxRest_Av.Items.Add("1 Possible");
            comboBoxRest_Av.Items.Add("2 Impossible");

        }

        private void CalculateInitRisk(int init_Se, int init_Fr, int init_Pr, int init_Av)
        {
            if (RisicograafSetting == 0)
            {
                Tuple<int, int> initValues = risicograaf.CalculateSilMode(init_Se, init_Fr, init_Pr, init_Av);
                int init_Cl = initValues.Item1;
                int init_Risk = init_Se * init_Cl;//initValues.Item2;
                int colorValue = initValues.Item2;
                textBoxInit_Cl.Text = init_Cl.ToString();
                textBoxInit_Risico.Text = init_Risk.ToString();
            }
            else if (RisicograafSetting == 1)
            {
                Tuple<int, int> initValues = risicograaf.CalculatePlMode(init_Se, init_Fr, init_Pr, init_Av);
                int init_Cl = initValues.Item1;
                int init_Risk = init_Se * init_Cl;//initValues.Item2;
                int colorValue = initValues.Item2;
                textBoxInit_Cl.Text = init_Cl.ToString();
                textBoxInit_Risico.Text = init_Risk.ToString();
            }
            //Tuple<int, int> initValues = risicograaf.CalculateSilMode(init_Se, init_Fr, init_Pr, init_Av);

            
        }

        private void CalculateRestRisk(int rest_Se, int rest_Fr, int rest_Pr, int rest_Av)
        {
            if (RisicograafSetting == 0)
            {
                Tuple<int, int> restValues = risicograaf.CalculateSilMode(rest_Se, rest_Fr, rest_Pr, rest_Av);
                int rest_Cl = restValues.Item1;
                int rest_Risk = rest_Se * rest_Cl;//initValues.Item2;
                int colorValue = restValues.Item2;

                textBoxRest_Cl.Text = rest_Cl.ToString();
                textBoxRest_Risico.Text = rest_Risk.ToString();
            }
            else if (RisicograafSetting == 1)
            {
                Tuple<int, int> restValues = risicograaf.CalculatePlMode(rest_Se, rest_Fr, rest_Pr, rest_Av);
                int rest_Cl = restValues.Item1;
                int rest_Risk = rest_Se * rest_Cl;//initValues.Item2;
                int colorValue = restValues.Item2;
                textBoxRest_Cl.Text = rest_Cl.ToString();
                textBoxRest_Risico.Text = rest_Risk.ToString();
            }



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
            //if (textBoxInit_Se_Comment.Text != test)
            //{
            //    // Display a MsgBox asking the user to save changes or abort.
            //    if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
            //       MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        // Cancel the Closing event from closing the form.
            //        e.Cancel = true;
            //        // Call method to save file...
            //    }
            //}
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

        #region init comboboxes
        private void comboBoxInit_Se_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxInit_Se.Text = (comboBoxInit_Se.SelectedIndex + 1).ToString();
        }

        private void comboBoxInit_Fr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RisicograafSetting == 0)
            {
                textBoxInit_Fr.Text = (comboBoxInit_Fr.SelectedIndex + 2).ToString();
            }
            else if (RisicograafSetting == 1)
            {
                textBoxInit_Fr.Text = (comboBoxInit_Fr.SelectedIndex + 1).ToString();
            }
        }

        private void comboBoxInit_Pr_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxInit_Pr.Text = (comboBoxInit_Pr.SelectedIndex + 1).ToString();
        }

        private void comboBoxInit_Av_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RisicograafSetting == 0)
            {
                textBoxInit_Av.Text = ((comboBoxInit_Av.SelectedIndex * 2) + 1).ToString();
            }
            else if (RisicograafSetting == 1)
            {
                textBoxInit_Av.Text = (comboBoxInit_Av.SelectedIndex + 1).ToString();
            }
            
        }
        #endregion init comboboxes

        #region rest comboboxes
        private void comboBoxRest_Se_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxRest_Se.Text = (comboBoxRest_Se.SelectedIndex + 1).ToString();
        }

        private void comboBoxRest_Fr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RisicograafSetting == 0)
            {
                textBoxRest_Fr.Text = (comboBoxRest_Fr.SelectedIndex + 2).ToString();
            }
            else if (RisicograafSetting == 1)
            {
                textBoxRest_Fr.Text = (comboBoxRest_Fr.SelectedIndex + 1).ToString();
            }
            
        }

        private void comboBoxRest_Pr_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxRest_Pr.Text = (comboBoxRest_Pr.SelectedIndex + 1).ToString();
        }

        private void comboBoxRest_Av_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RisicograafSetting == 0)
            {
                textBoxRest_Av.Text = ((comboBoxRest_Av.SelectedIndex * 2) + 1).ToString();
            }
            else if (RisicograafSetting == 1)
            {
                textBoxRest_Av.Text = (comboBoxRest_Av.SelectedIndex  + 1).ToString();
            }
            
        }
        #endregion rest comboboxes
    }
}
