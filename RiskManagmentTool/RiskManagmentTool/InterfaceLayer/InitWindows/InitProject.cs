using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.LogicLayer.Objects;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.InitWindows
{
    public partial class InitProject : Form
    {
        private Datacomunication comunicator;
        public InitProject()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
        }

        private void buttonCreateProject_Click(object sender, EventArgs e)
        {
            comunicator.MakeProject(textBoxProjectNaam.Text);
            this.Close();
        }
    }
}
