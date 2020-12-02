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

namespace RiskManagmentTool.InterfaceLayer.DeleteWindows
{
    public partial class DeleteGekoppeldeMaatregelen : Form
    {
        private Datacomunication comunicator;

        private string IssueID;

        public DeleteGekoppeldeMaatregelen(string issueID)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            IssueID = issueID;


            LoadData();

        }

        private void LoadData()
        {
            dataGridViewIssueMaatregelen.DataSource = comunicator.GetIssueMaatregelen(IssueID);

        }
    }
}
