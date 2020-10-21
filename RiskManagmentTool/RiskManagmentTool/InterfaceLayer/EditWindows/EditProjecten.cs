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
        public EditProjecten(string projectNaam)
        {
            InitializeComponent();
            this.ProjectNaam = projectNaam;
            comunicator = new Datacomunication();
            LoadData();
        }

        private void LoadData()
        {

            textBoxProjectNaam.Text = ProjectNaam;
            //dataGridViewGekoppeldeObjecten.DataSource = comunicator.getObjectenTable();

        }

        private void dataGridViewGekoppeldeObjecten_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string objectNaam = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[0].Value.ToString();
            string ObjectType = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[1].Value.ToString();
            string ObjectBeschrijving = dataGridViewGekoppeldeObjecten.SelectedRows[0].Cells[2].Value.ToString();

            Form editObjecten = new EditObjecten(objectNaam,
                            ObjectType,
                            ObjectBeschrijving);//,

            editObjecten.Show();



        }

        private void buttonMakeNewObject_Click(object sender, EventArgs e)
        {
            Form initObject = new InitObject();
            initObject.Show();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Form exportObject = new ExportObject();
            exportObject.Show();
        }
    }
}
