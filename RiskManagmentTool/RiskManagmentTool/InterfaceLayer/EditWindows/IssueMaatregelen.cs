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

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class IssueMaatregelen : Form
    {
        private Datacomunication comunicator;
        //private int issueNmr;
        private string IssueID;
        private string ObjectID;
        private KeuzeMenus keuzeMenus;

        private string Discipline;
        private string Gevaar;
        private string Situatie;
        private string Gebeurtenis;


        public IssueMaatregelen(string objectNaam, string objectId, string issueId,
                                string discipline, string gevaar, string situatie, string gebeurtenis,
                                string init_Risico, string init_Risico_Beschrijving,
                                string rest_Risico, string rest_Risico_Beschrijving)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            Discipline = discipline;
            Gevaar = gevaar;
            Situatie = situatie;
            Gebeurtenis = gebeurtenis;

            IssueID = issueId;
            ObjectID = objectId;

            LoadMenus();
            LoadData();
            //
            textBoxNaamObject.Text = objectNaam;
            textBoxIssueID.Text = issueId;
            comboBoxDiscipline.SelectedIndex = comboBoxDiscipline.FindStringExact(Discipline);
            comboBoxGevaar.SelectedIndex = comboBoxGevaar.FindStringExact(Gevaar);
            textBoxSituatie.Text = Situatie;
            textBoxGebeurtenis.Text = Gebeurtenis;
            textBoxInit_Risico.Text = init_Risico;
            textBoxInit_Risico_Comment.Text = init_Risico_Beschrijving;
            textBoxRest_Risico.Text = rest_Risico;
            textBoxRest_Risico_Comment.Text = rest_Risico_Beschrijving;

            checkBoxIssueOK.Checked = comunicator.GetIssueState(IssueID) == "1";
            //string rest_Ok = checkBoxRest_Risico_Ok.Checked == true ? "1" : "0";

        }

        private void LoadMenus()
        {
            List<string> disciplineList = keuzeMenus.GetDisciplinesMenu();
            foreach (string discipline in disciplineList)
            {
                comboBoxDiscipline.Items.Add(discipline);
            }

            List<string> gevarenList = keuzeMenus.GetGevaarTypeMenu();
            foreach (string gevaar in gevarenList)
            {
                comboBoxGevaar.Items.Add(gevaar);
            }
        }

        private void LoadData()
        {
            dataGridViewIssueMaatregelen.DataSource = comunicator.GetIssueMaatregelen(IssueID);
        }

        private void buttonRisicoDetails_Click(object sender, EventArgs e)
        {
            Form issueRisicoDetails = new IssueRisicoDetails(IssueID);
            issueRisicoDetails.Show();
        }

        private void buttonAddNewMaatregel_Click(object sender, EventArgs e)
        {
            Form addMaatregel = new AddMaatregel(IssueID, Discipline, Gevaar, Situatie, Gebeurtenis);
            addMaatregel.Show();
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
    }
}
