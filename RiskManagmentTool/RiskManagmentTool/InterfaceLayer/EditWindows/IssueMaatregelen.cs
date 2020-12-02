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

        private bool ReadOnlyMode;


        public IssueMaatregelen(string objectNaam, string objectId, string issueId,
                                string discipline, string gevaar, string situatie, string gebeurtenis,
                                string init_Risico, string init_Risico_Beschrijving,
                                string rest_Risico, string rest_Risico_Beschrijving)
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




            //textBoxInit_Risico.Text = init_Risico;
            //textBoxInit_Risico_Comment.Text = init_Risico_Beschrijving;
            //textBoxRest_Risico.Text = rest_Risico;
            //textBoxRest_Risico_Comment.Text = rest_Risico_Beschrijving;

            checkBoxIssueOK.Checked = comunicator.GetIssueState(IssueID) == "1";

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
            
        }

        private void LoadRisicoBeoordelingDetails()
        {
            DataTable risicoBeoordelingData = comunicator.GetRisicoBeoordelingFromIssue(IssueID);
            textBoxInit_Risico.Text = risicoBeoordelingData.Rows[0].Field<int?>(7).ToString();
            textBoxInit_Risico_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(13).ToString();
            textBoxRest_Risico.Text = risicoBeoordelingData.Rows[0].Field<int?>(19).ToString();
            textBoxRest_Risico_Comment.Text = risicoBeoordelingData.Rows[0].Field<string>(25).ToString();
            checkBoxRest_Risico_OK.Checked = risicoBeoordelingData.Rows[0].Field<string>(26).ToString() == "1";
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
            IssueRisicoDetails issueRisicoDetails = new IssueRisicoDetails(IssueID);
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

        private void buttonNextIssue_Click(object sender, EventArgs e)
        {
            string message = "Weet u zeker dat de risico waardes ook correct zijn?";
            string title = "Reminder Risico waardes";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                //this.Close();
            }
            else
            {
                // Do something  
            }
            //issueNmr++;
            //textBoxIssueID.Text = issueNmr.ToString();
        }

        private void dataGridViewIssueMaatregelen_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewIssueMaatregelen.ClearSelection();
        }

        private void checkBoxIssueOK_CheckedChanged(object sender, EventArgs e)
        {
            string issueState = checkBoxIssueOK.Checked == true ? "1" : "0";
            comunicator.UpdateIssueState(IssueID, issueState);
        }

        private void buttonDeleteMaatregelen_Click(object sender, EventArgs e)
        {
            DeleteGekoppeldeMaatregelen deleteGekoppeldeMaatregelen = new DeleteGekoppeldeMaatregelen(IssueID);
            deleteGekoppeldeMaatregelen.Show();
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
    }
}
