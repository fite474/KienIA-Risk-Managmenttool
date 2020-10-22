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
using RiskManagmentTool.LogicLayer;
using RiskManagmentTool.InterfaceLayer.InitWindows;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentProjecten : Form
    {

        private Datacomunication comunicator;
        public ContentProjecten()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            LoadProjects();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            Form initProject = new InitProject();
            initProject.Show();
            //Form editProjecten = new EditProjecten();
            //editProjecten.Show();
        }

        private void LoadProjects()
        {
            dataGridViewProjecten.DataSource = comunicator.GetProjectenTable();

        }

        private void dataGridViewProjecten_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string projectId= dataGridViewProjecten.SelectedRows[0].Cells[0].Value.ToString();
            string projectNaam = dataGridViewProjecten.SelectedRows[0].Cells[1].Value.ToString();
            ShowEditProject(projectId, projectNaam);
            //Form editProjecten = new EditProjecten(projectNaam);//,

            //editProjecten.Show();



        }

        private void ShowEditProject(string projectId, string projectNaam)
        {
            Form editProjecten = new EditProjecten(projectId, projectNaam);//activeForm = contentForm;
            editProjecten.TopLevel = false;
            editProjecten.FormBorderStyle = FormBorderStyle.None;
            editProjecten.Dock = DockStyle.Fill;
            this.panelEditProject.Controls.Add(editProjecten);
            this.panelEditProject.Tag = editProjecten;
            editProjecten.BringToFront();
            editProjecten.Show();
        }
    }
}
