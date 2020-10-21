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
        private List<string> MenuNames;
        private Datacomunication comunicator;
        public ContentKeuzes()
        {
            InitializeComponent();
            comunicator = new Datacomunication();
            InitComboBoxObjects();
            //LoadComboBoxKeuzes();
        }

        

        private void InitComboBoxObjects()
        {
            //init list of each combobox
            MenuNames = new List<string>();
            MenuNames.Add("Object type");
            List<string> objectTypes = comunicator.GetObjectTypes();
            //object type
            foreach (string menuName in MenuNames)
            {
                KeuzesItem keuzesItem = new KeuzesItem(menuName, objectTypes)
                {
                    Dock = DockStyle.Fill//,
                                         //Margin.;

                };

                tableLayoutPanelKeuzes.Controls.Add(keuzesItem, column, row);
            }
           
        }

        
    }
}
