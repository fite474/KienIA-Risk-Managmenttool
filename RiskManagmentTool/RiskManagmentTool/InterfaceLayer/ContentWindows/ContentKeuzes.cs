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

        private int column = 0;
        private int row = 0;
        //private List<string> MenuNames;
        private List<MenuTableName> menuTableNames;
        //private KeuzeMenus keuzeMenus;
       //private Datacomunication comunicator;
        public ContentKeuzes()
        {
            InitializeComponent();

            //keuzeMenus = KeuzeMenus.GetInstance();

            //comunicator = new Datacomunication();
            InitComboBoxObjects();
            //LoadComboBoxKeuzes();
        }

        private void InitComboBoxNames()
        {
            //MenuNames = new List<string>
            //{
            //    "Object type",
            //    "Gevolgen",
            //    "Gevarenzones",
            //    "GevaarTypes",
            //    "Gebruiksfases",
            //    "Gebruikers",
            //    "Disciplines",
            //    "Bedienvormen",

            //};
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



            };


        }

        private void InitComboBoxObjects()
        {
            //init list of each combobox

            InitComboBoxNames();
            //List<string> objectTypes = comunicator.GetObjectTypes();
            //object type
            foreach (MenuTableName menuName in menuTableNames)
            {
                KeuzesItem keuzesItem = new KeuzesItem(menuName)//, objectTypes)
                {
                    Dock = DockStyle.Fill,
                    MenuTableName = menuName                
                };

                tableLayoutPanelKeuzes.Controls.Add(keuzesItem);//, column, row);
            }
           
        }

        
    }
}
