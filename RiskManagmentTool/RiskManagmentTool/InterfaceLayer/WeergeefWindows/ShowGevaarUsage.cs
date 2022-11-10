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
using RiskManagmentTool.InterfaceLayer.EditWindows;

namespace RiskManagmentTool.InterfaceLayer.WeergeefWindows
{
    public partial class ShowGevaarUsage : Form
    {
        private Datacomunication comunicator;

        private string GevaarID;

        public ShowGevaarUsage(string gevaarId)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            GevaarID = gevaarId;
            LoadData();
        }

        private void LoadData()
        {
            dataGridViewGevaarUsage.DataSource = comunicator.GetAllIssuesWithGevaarID(GevaarID);


        }

        private void dataGridViewGevaarUsage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string zoekNummer = dataGridViewGevaarUsage.SelectedRows[0].Cells[1].Value.ToString(); ;
                string objectId = comunicator.GetObjectIdByIssueNmr(zoekNummer);

                if (!objectId.Equals("0"))
                {
                    List<string> objectInfo = comunicator.GetObjectInfo(objectId);
                    string projectId = objectInfo[0];
                    string projectNaam = objectInfo[1];
                    string objectNaam = objectInfo[2];
                    string objectType = objectInfo[3];
                    string objectOmschrijving = objectInfo[4];
                    Form editObject = new EditObjecten(objectId, projectNaam, objectNaam, objectType, objectOmschrijving);
                    editObject.ShowDialog();
                }
            }
            catch (Exception err)
            {

                Console.WriteLine(err);
            }
            LoadData();
        }
    }
}
