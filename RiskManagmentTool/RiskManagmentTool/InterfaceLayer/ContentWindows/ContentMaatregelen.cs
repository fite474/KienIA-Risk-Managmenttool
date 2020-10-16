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
using RiskManagmentTool.LogicLayer.Objects;
using RiskManagmentTool.LogicLayer.Objects.Core;
using RiskManagmentTool.InterfaceLayer.EditWindows;


namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentMaatregelen : Form
    {
        //private Form editMaatregelenForm;
        //private MainWindow mainWindowForm;
        private Datacomunication comunicator;
        public ContentMaatregelen()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            RefreshTable();
        }


        private void CreateIssue()
        {

            
            Item issue = new Item
            {
                ItemType = ItemType.Issue,
                ItemData = new IssueObject
                {
                    IssueId = "",
                    IssueBeschrijving = "",
                    IssueGevolg = "",
                    IssueDicipline = "",
                    IssueGebruiksfase = "",
                    IssueGebruiker = "",
                    IssueGevarenzone = "",
                    IssueSeverity = "",
                    IssueFrequency = "",
                    IssueProbability = "",
                    IssueAvoidance = "",
                    Verificatie = VerificatieStatus.Volledig
                }
            };
        }
        private void RefreshTable()
        {
            dataGridViewMaatregelen.DataSource = comunicator.getTable();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form editMaatregelenForm = new EditMaatregelen();
            //mainWindowForm.OpenContentWindow(editMaatregelenForm);
            editMaatregelenForm.Show();
        }
    }
}
