using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class IssueMaatregelen : Form
    {
        public IssueMaatregelen()
        {
            InitializeComponent();
        }

        private void buttonRisicoDetails_Click(object sender, EventArgs e)
        {
            Form issueRisicoDetails = new IssueRisicoDetails();
            issueRisicoDetails.Show();
        }
    }
}
