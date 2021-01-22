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
        public ContentKeuzes()
        {
            InitializeComponent();

            InitComboBoxObjects();
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
                KeuzesItem keuzesItem = new KeuzesItem(menuName)
                {
                    Dock = DockStyle.Fill,
                    MenuTableName = menuName                
                };
                tableLayoutPanelKeuzes.Controls.Add(keuzesItem);
                
            }
            Cursor.Current = Cursors.Default;
        }

    }
}
