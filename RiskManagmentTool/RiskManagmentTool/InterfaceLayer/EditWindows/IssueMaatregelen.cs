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
using RiskManagmentTool.InterfaceLayer.AddWindows;
using RiskManagmentTool.InterfaceLayer.DeleteWindows;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class IssueMaatregelen : Form
    {
        private Datacomunication comunicator;
        //private int issueNmr;
        private string IssueID;
        private string ObjectID;
        private string ObjectNaam;
        private KeuzeMenus keuzeMenus;
        private ImageHandler ImageHandler;

        private string Discipline;
        private string Gevaar;
        private string Situatie;
        private string Gebeurtenis;

        private int RisicograafSetting; //0 = SIL 1 = pl
        private int IssueState;

        private bool ReadOnlyMode;


        public IssueMaatregelen(string objectNaam, string objectId, string issueId,
                                string discipline, string gevaar, string situatie, string gebeurtenis)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            ImageHandler = new ImageHandler();
            Discipline = discipline;
            Gevaar = gevaar;
            Situatie = situatie;
            Gebeurtenis = gebeurtenis;
            ReadOnlyMode = false;
            IssueID = issueId;
            ObjectID = objectId;
            ObjectNaam = objectNaam;

            LoadData();
            //
            LoadIssueText();
            SetIssueImage();

        }

        private void LoadIssueText()
        {
            textBoxNaamObject.Text = ObjectNaam;//objectNaam;
            textBoxIssueID.Text = IssueID;
            textBoxGevaar.Text = Gevaar;
            textBoxDiscipline.Text = Discipline;

            textBoxSituatie.Text = Situatie;
            textBoxGebeurtenis.Text = Gebeurtenis;



            //checkBoxIssueOK.Checked = comunicator.GetIssueState(IssueID) == "1";

            DataTable risicoBeoordelingData = comunicator.GetRisicoBeoordelingFromIssue(IssueID);
            textBoxInit_Risico.Text = risicoBeoordelingData.Rows[0].Field<int?>(7).ToString();
            textBoxInit_Risico_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(13).ToString();
            textBoxRest_Risico.Text = risicoBeoordelingData.Rows[0].Field<int?>(19).ToString();
            textBoxRest_Risico_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(25).ToString();
            checkBoxRest_Risico_OK.Checked = risicoBeoordelingData.Rows[0].Field<string>(26).ToString() == "1";
            risicoBeoordelingData.Dispose();

        }




        private void LoadData()
        {
            LoadRisicoBeoordelingDetails();
            dataGridViewIssueMaatregelen.DataSource = comunicator.GetIssueMaatregelen(IssueID);


            List<string> objectSettings = comunicator.GetObjectSettings(ObjectID);
            string risicograaf = objectSettings[0];
            if (risicograaf.Equals("0"))
            {
                RisicograafSetting = 0;
            }
            else if (risicograaf.Equals("1"))
            {
                RisicograafSetting = 1;
            }

            

        }

        private void LoadRisicoBeoordelingDetails()
        {
            DataTable risicoBeoordelingData = comunicator.GetRisicoBeoordelingFromIssue(IssueID);
            textBoxInit_Risico.Text = risicoBeoordelingData.Rows[0].Field<int?>(7).ToString();
            textBoxInit_Risico_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(13).ToString();
            textBoxRest_Risico.Text = risicoBeoordelingData.Rows[0].Field<int?>(19).ToString();
            textBoxRest_Risico_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(25).ToString();
            checkBoxRest_Risico_OK.Checked = risicoBeoordelingData.Rows[0].Field<string>(26).ToString() == "1";


            IssueState = int.Parse(comunicator.GetIssueState(IssueID));//risicoBeoordelingData.Rows[0].Field<int>(27);
            checkedListBoxIssueCompletionState.SetItemChecked(IssueState, true);


            //checkedListBoxIssueCompletionState.Item
        }

        public void SetReadOnlyMode()
        {

            checkBoxIssueOK.Enabled = false;
            buttonAddNewMaatregel.Enabled = false;
            buttonDeleteMaatregelen.Enabled = false;
            ReadOnlyMode = true;

        }

        private void SetIssueImage()
        {
            //get object image(ObjectID)
            string filePath = comunicator.GetIssueImage(IssueID);//@"C:\Users\mauri\Documents\1AVANS\Stage\1 Stage Bestanden\Pieter_de_Hooghbrug.jpg";
            try
            {
                pictureBoxIssueImage.Image = new Bitmap(filePath);
                pictureBoxIssueImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception e)
            {

                Console.WriteLine($"The file was not found: '{e}'");
            }

        }



        private void buttonRisicoDetails_Click(object sender, EventArgs e)
        {
            IssueRisicoDetails issueRisicoDetails = new IssueRisicoDetails(IssueID, RisicograafSetting);
            if (ReadOnlyMode)
            {
                issueRisicoDetails.SetReadOnlyMode();
            }

            issueRisicoDetails.ShowDialog();
            LoadData();
        }

        private void buttonAddNewMaatregel_Click(object sender, EventArgs e)
        {
            Form addMaatregel = new AddMaatregel(ObjectNaam, ObjectID,  IssueID, Discipline, Gevaar, Situatie, Gebeurtenis);
            addMaatregel.ShowDialog();
            LoadData();
        }

        //private void buttonNextIssue_Click(object sender, EventArgs e)
        //{
        //    string message = "Weet u zeker dat de risico waardes ook correct zijn?";
        //    string title = "Reminder Risico waardes";
        //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        //    DialogResult result = MessageBox.Show(message, title, buttons);
        //    if (result == DialogResult.Yes)
        //    {
        //        //this.Close();
        //    }
        //    else
        //    {
        //        // Do something  
        //    }
        //    //issueNmr++;
        //    //textBoxIssueID.Text = issueNmr.ToString();
        //}

        private void dataGridViewIssueMaatregelen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            dataGridViewIssueMaatregelen.ClearSelection();
        }

        private void checkBoxIssueOK_CheckedChanged(object sender, EventArgs e)
        {
            //string issueState = checkBoxIssueOK.Checked == true ? "1" : "0";
            //comunicator.UpdateIssueState(IssueID, IssueState);
        }

        private void buttonDeleteMaatregelen_Click(object sender, EventArgs e)
        {
            DeleteGekoppeldeMaatregelen deleteGekoppeldeMaatregelen = new DeleteGekoppeldeMaatregelen(IssueID);
            deleteGekoppeldeMaatregelen.ShowDialog();
            LoadData();
        }

        private void pictureBoxIssueImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {

                string imageFilePath = ImageHandler.ChangeLocation(open.FileName);


                // display image in picture box  
                pictureBoxIssueImage.Image = new Bitmap(imageFilePath);//open.FileName);
                pictureBoxIssueImage.SizeMode = PictureBoxSizeMode.StretchImage;
                // image file path 
                comunicator.AddImageToIssue(IssueID, imageFilePath);

            }
        }

        private void buttonShowRisk_Click(object sender, EventArgs e)
        {
            string gevaarID = comunicator.GetGevaarIdByIssueID(IssueID);
            EditRisicos editRisicos = new EditRisicos(gevaarID);
            editRisicos.SetReadOnlyMode();
            editRisicos.ShowDialog();
        }

        private void checkedListBoxIssueCompletionState_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            for (int ix = 0; ix < checkedListBoxIssueCompletionState.Items.Count; ++ix)
                if (ix != e.Index) checkedListBoxIssueCompletionState.SetItemChecked(ix, false);
                else IssueState = ix;
            
            
        }

        private void checkedListBoxIssueCompletionState_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int ix = 0; ix < checkedListBoxIssueCompletionState.Items.Count; ++ix)
                if (checkedListBoxIssueCompletionState.GetItemChecked(ix))
                {
                    IssueState = ix;
                    
                }
            comunicator.UpdateIssueState(IssueID, IssueState);
        }
    }
}
