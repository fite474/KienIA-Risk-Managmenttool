using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ProjectItem : UserControl
    {
        public ProjectItem(String projectNaam)
        {
            InitializeComponent();
            LoadDetails(projectNaam);
        }

        private void LoadDetails(string ProjectNaam)
        {
            labelProjectNaam.Text = ProjectNaam;
        }

        private void buttonOpenProject_Click(object sender, EventArgs e)
        {
            EditProjecten editProjecten = new EditProjecten();
            editProjecten.Show();
        }
    }
}
