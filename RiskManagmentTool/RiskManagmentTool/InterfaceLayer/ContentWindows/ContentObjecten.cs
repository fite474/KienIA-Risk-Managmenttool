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

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentObjecten : Form
    {
        private Datacomunication comunicator;
        public ContentObjecten()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewObjecten.DataSource = comunicator.GetObjectenTable();

        }

        private void dataGridViewObjecten_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string objectId = comunicator.GetObjectIdByName(dataGridViewObjecten.SelectedRows[0].Cells[1].Value.ToString());


            if (!objectId.Equals("0"))
            {
                List<string> objectInfo = comunicator.GetObjectInfo(objectId);
                string projectId = objectInfo[0];
                string projectNaam = objectInfo[1];
                string objectNaam = objectInfo[2];
                string objectType = objectInfo[3];
                string objectOmschrijving = objectInfo[4];
                Form editObject = new EditObjecten(objectId, projectNaam, objectNaam, objectType, objectOmschrijving);
                editObject.Show();


            }

        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {

            //Form editObject = new EditObjecten();
            //editObject.Show();
        }

        private void dataGridViewObjecten_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewObjecten.ClearSelection();
        }
    }
}
