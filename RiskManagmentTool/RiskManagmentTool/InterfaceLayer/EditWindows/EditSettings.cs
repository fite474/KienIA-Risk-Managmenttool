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

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditSettings : Form
    {

        private Datacomunication comunicator;

        private string ProjectID;
        private string ProjectNaam;

        public EditSettings(string projectID, string projectNaam)
        {
            //doet niks
            InitializeComponent();
            ProjectID = projectID;
            ProjectNaam = projectNaam;

            textBoxProjectNaam.Text = ProjectNaam;
            comunicator = new Datacomunication();
        }

        private void LoadData()
        {


        }


        private void buttonSave_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void checkedListBoxRisicograaf_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBoxRisicograaf.Items.Count; ++ix)
                if (ix != e.Index) checkedListBoxRisicograaf.SetItemChecked(ix, false);
        }

        private void checkedListBoxExcelSettings_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBoxExcelSettings.Items.Count; ++ix)
                if (ix != e.Index) checkedListBoxExcelSettings.SetItemChecked(ix, false);
        }
    }
}
