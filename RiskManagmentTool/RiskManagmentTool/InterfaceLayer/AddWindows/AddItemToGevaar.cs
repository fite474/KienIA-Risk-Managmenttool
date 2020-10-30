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

namespace RiskManagmentTool.InterfaceLayer.AddWindows
{
    public partial class AddItemToGevaar : Form
    {
        private string MenuName;
        private List<string> MenuOptions;
        private Datacomunication comunicator;
        KeuzeMenus keuzeMenus;
        private MenuTableName MenuTableName;
        public AddItemToGevaar(MenuTableName menuTableName, List<string> options, string menuName)
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
            //textBoxMenuName.Text = MenuName;

            foreach (string menuOption in MenuOptions)
            {
                checkedListBoxOptions.Items.Add(menuOption);
                //comboBoxObjectType.Items.Add(typeString);
            }
        }
    }
}
