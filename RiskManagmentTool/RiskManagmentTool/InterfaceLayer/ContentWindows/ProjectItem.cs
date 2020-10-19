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
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ProjectItem : UserControl
    {
        private Datacomunication comunicator;
        public ProjectItem(String projectNaam)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            LoadDetails(projectNaam);
            
            
        }

        private void LoadDetails(string ProjectNaam)
        {
            labelProjectNaam.Text = ProjectNaam;
            List<string> gekoppeldeObjecten = comunicator.GetGekoppeldeObjecten();
            for (int i = 0; i < gekoppeldeObjecten.Count; i++)
            {
                listBoxGekoppeldeObjecten.Items.Add(gekoppeldeObjecten[i]);//.ToString());
            }
            
        }

        private void buttonOpenProject_Click(object sender, EventArgs e)
        {
            EditProjecten editProjecten = new EditProjecten();
            editProjecten.Show();
        }
    }
}
