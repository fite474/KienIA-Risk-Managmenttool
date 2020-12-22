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
using RiskManagmentTool.InterfaceLayer.InitWindows;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditProjecten : Form
    {
        private Datacomunication comunicator;
        private string ProjectNaam;
        private string ProjectId;
        public EditProjecten(string projectId, string projectNaam)
        {
            InitializeComponent();
            this.ProjectId = projectId;
            this.ProjectNaam = projectNaam;

            comunicator = new Datacomunication();
            LoadData();
        }

        private void LoadData()
        {
            textBoxProjectNaam.Text = ProjectNaam;
            dataGridViewGekoppeldeObjecten.DataSource = comunicator.GetObjectenFromProject(ProjectId);
        }

        private void dataGridViewGekoppeldeObjecten_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string projectID = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[0].Value.ToString();
                string projectNaam = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[1].Value.ToString();
                string objectNaam = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[2].Value.ToString();
                string objectType = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[3].Value.ToString();
                string objectOmschrijving = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[4].Value.ToString();

                Form editObject = new EditObjecten(projectID, projectNaam, objectNaam, objectType, objectOmschrijving);
                editObject.Show();
            }
            catch (Exception err)
            {

                Console.WriteLine(err);
            }
           

        }

        private void buttonMakeNewObject_Click(object sender, EventArgs e)
        {
            Form initObject = new InitObject(ProjectId, ProjectNaam);
            initObject.Show();
        }

        private void dataGridViewGekoppeldeObjecten_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewGekoppeldeObjecten.ClearSelection();
        }

        private void buttonEditSettings_Click(object sender, EventArgs e)
        {
            EditSettings editSettings = new EditSettings(ProjectId, ProjectNaam);
            editSettings.ShowDialog();
 
        }
    }
}
