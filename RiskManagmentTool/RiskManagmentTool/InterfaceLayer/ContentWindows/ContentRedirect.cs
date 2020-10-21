using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentRedirect : Form
    {
        public ContentRedirect()
        {
            InitializeComponent();
        }

        private void buttonZoekIssueNummer_Click(object sender, EventArgs e)
        {
            Form issueMaatregelNmr = new IssueMaatregelen();
            issueMaatregelNmr.Show();
        }
    }
}
