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
    public partial class EditKeuzes : Form
    {
        private string MenuName;
        private List<string> MenuOptions;
        private Datacomunication comunicator;
        KeuzeMenus keuzeMenus;
        private MenuTableName MenuTableName;
        public EditKeuzes(MenuTableName menuTableName, List<string> options, string menuName)
        {
            InitializeComponent();
            keuzeMenus = new KeuzeMenus();
            comunicator = new Datacomunication();
            MenuTableName = menuTableName;
            MenuName = menuName;
            MenuOptions = options;
            LoadData();
        }

        private void LoadData()
        {
            //switch (MenuTableName)
            //{
            //    case MenuTableName.ObjectTypes:
            //        MenuOptions = keuzeMenus.GetTypeObjectMenu();
            //        break;
            //    case MenuTableName.Gevolgen:
            //        break;
            //    case MenuTableName.Gevarenzones:
            //        break;
            //    case MenuTableName.GevaarTypes:
            //        break;
            //    case MenuTableName.Gebruiksfases:
            //        break;
            //    case MenuTableName.Gebruikers:
            //        break;
            //    case MenuTableName.Disciplines:
            //        break;
            //    case MenuTableName.Bedienvormen:
            //        break;
            //    default:
            //        break;
            //}
            textBoxMenuName.Text = MenuName;

            foreach (string menuOption in MenuOptions)
            {
                listBoxMenuOptions.Items.Add(menuOption);
                //comboBoxObjectType.Items.Add(typeString);
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            EditText editText = new EditText();
            if (editText.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                string textResult = editText.textBoxInput.Text;
                listBoxMenuOptions.Items.Add(textResult);
                AddInput(textResult);
                //comunicator.AddToMenu(MenuName, textResult);

                
                
            }
            else
            {
                //this.txtResult.Text = "Cancelled";
            }
            editText.Dispose();
            //editText.ShowDialog();
        }

        private void AddInput(string input)
        {

            comunicator.AddToMenu(MenuTableName, input);
            keuzeMenus.ReloadAllLists();
           
        }
    }
}
