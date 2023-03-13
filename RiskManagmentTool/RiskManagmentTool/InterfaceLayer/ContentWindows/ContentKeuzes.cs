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

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class ContentKeuzes : Form
    {
        private List<MenuTableName> menuTableNames;

        private string objectId;
        private string objectNaam;

        private Datacomunication comunicator;
        public ContentKeuzes()//global page. found from the home menu
        {
            this.objectId = "-1";
            InitializeComponent();
            comunicator = new Datacomunication();
            InitComboBoxObjects();


            InitDropdownBox();

            this.comboBoxObjectName.SelectedIndex = 0;

        }

        public ContentKeuzes(string objectId, string objectNaam)// after initing a new object
        {
            this.objectId = objectId;
            InitializeComponent();
            comunicator = new Datacomunication();
            InitComboBoxObjects();

            this.panelTopBar.Height = 100;
            this.objectNaam = objectNaam;
            this.InitWindowText();
        }


        private void InitWindowText()
        {
            this.labelObjectNaam.Visible = true;
            this.labelObjectNaam.Text = labelObjectNaam.Text + this.objectNaam;

            this.labelUitlegPagina.Visible = true;
            this.labelUitlegPagina.Text = "Op deze pagina kunt u eenvoudig voor elke categorie opties toevoegen die specifiek bij dit object horen";

            this.buttonNext.Visible = true;
  
        }

        private void InitComboBoxNames()
        {
            menuTableNames = new List<MenuTableName>
            {
                MenuTableName.ObjectTypes,
                MenuTableName.Gevolgen,
                MenuTableName.Gevarenzones,
                MenuTableName.GevaarTypes,
                MenuTableName.Gebruiksfases,
                MenuTableName.Gebruikers,
                MenuTableName.Disciplines,
                MenuTableName.Bedienvormen,
                MenuTableName.Taken,
                MenuTableName.Normen,
                MenuTableName.Categories//,
                //MenuTableName.TemplateTypes,
                //MenuTableName.TemplateToepassing
            };
        }


        private void InitComboBoxObjects()
        {
            InitComboBoxNames();
            foreach (MenuTableName menuName in menuTableNames)
            {
                KeuzesItem keuzesItem = new KeuzesItem(menuName, objectId)
                {
                    Dock = DockStyle.Fill,
                    MenuTableName = menuName                
                };
                tableLayoutPanelKeuzes.Controls.Add(keuzesItem);
                
            }
            Cursor.Current = Cursors.Default;
        }

        private void InitDropdownBox()
        {
            this.comboBoxObjectName.Items.Add("Global");
            List<string> objectNames = new List<string>();
            objectNames = this.comunicator.GetObjectNamen();



            foreach (string objectName in objectNames)
            {
                this.comboBoxObjectName.Items.Add(objectName);

            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxObjectName_SelectedIndexChanged(object sender, EventArgs e)
        {

            string selectedObjectID = "ERROR";

            if (this.comboBoxObjectName.SelectedItem.ToString().Equals("Global"))
            {
                selectedObjectID = "-1";
            }
            else
            {
                selectedObjectID = this.comunicator.GetObjectIdByName(this.comboBoxObjectName.SelectedItem.ToString());
            }

            this.objectId = selectedObjectID;

            //now reset all the tables

            tableLayoutPanelKeuzes.Controls.Clear();

            //and reload all data with the selected object id

            this.InitComboBoxObjects();


        }
    }
}
