using RiskManagmentTool.LogicLayer;
using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace RiskManagmentTool.InterfaceLayer.EditWindows
{
    public partial class EditText : Form
    {
        private MenuTableName MenuTableName;
        public EditText(MenuTableName menuTableName)
        {
            InitializeComponent();
            this.MenuTableName = menuTableName;
            SetSettings();
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SetSettings()
        {
            switch (MenuTableName)
            {
                case MenuTableName.ObjectTypes:
                    break;
                case MenuTableName.Gevolgen:
                    break;
                case MenuTableName.Gevarenzones:
                    break;
                case MenuTableName.GevaarTypes:
                    this.showPanel3();
                    break;
                case MenuTableName.Gebruiksfases:
                    break;
                case MenuTableName.Gebruikers:
                    break;
                case MenuTableName.Disciplines:
                    break;
                case MenuTableName.Bedienvormen:
                    break;
                case MenuTableName.Taken:
                    break;
                case MenuTableName.Normen:
                    break;
                case MenuTableName.Categories:
                    break;
                case MenuTableName.TemplateTypes:
                    break;
                case MenuTableName.TemplateToepassing:
                    break;
                default:
                    break;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPanel3()
        {
            panel3.Visible = true;
            Size = new Size(316, 313);
            //size 316; 313
        }
    }
}
