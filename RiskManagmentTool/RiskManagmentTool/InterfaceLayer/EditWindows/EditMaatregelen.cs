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
    public partial class EditMaatregelen : Form
    {

        private Datacomunication comunicator;
        private KeuzeMenus keuzeMenus;
        public EditMaatregelen()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            LoadMenus();
        }

        public EditMaatregelen(string maatregelID, string maatregelNaam, string maatregelCategory, string maatregelNorm)
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            keuzeMenus = new KeuzeMenus();
            LoadMenus();
            textBoxMaatregelNaam.Text = maatregelNaam;
        }



        private void LoadMenus()
        {
            Dictionary<int, string> maatregelNormList = keuzeMenus.GetMaatregelNormMenu();
            foreach (KeyValuePair<int, string> kvp in maatregelNormList)
            {
                comboBoxMaatregelNorm.Items.Add(kvp.Value);
            }

            Dictionary<int, string> maatregelCategoryList = keuzeMenus.GetMaatregelCategoryMenu();
            foreach (KeyValuePair<int, string> kvp in maatregelCategoryList)
            {
                comboBoxMaatregelCategory.Items.Add(kvp.Value);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string maatregelNaam = textBoxMaatregelNaam.Text;
            string maatregelNorm = comboBoxMaatregelNorm.SelectedItem.ToString();
            string maatregelCategory = comboBoxMaatregelCategory.SelectedItem.ToString();
            comunicator.MakeMaatregel(maatregelNaam, maatregelNorm, maatregelCategory);
            this.Close();
        }
    }
}
