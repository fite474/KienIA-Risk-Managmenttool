using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.InterfaceLayer.EditWindows;
using RiskManagmentTool.LogicLayer;

namespace RiskManagmentTool.InterfaceLayer.ContentWindows
{
    public partial class KeuzesItem : UserControl
    {
        //private string MenuName;
        public MenuTableName MenuTableName;
        private List<string> MenuOptions;
        private KeuzeMenus keuzeMenus;
        private string menuTitle;
        public KeuzesItem(MenuTableName menuName)//, List<string> options)
        {
            InitializeComponent();
            keuzeMenus = KeuzeMenus.GetInstance();
            MenuTableName = menuName;
            //MenuOptions = options;
            LoadData();
        }

        private void LoadData()
        {
            listBoxMenuOptions.Items.Clear();
            switch (this.MenuTableName)
            {
                case MenuTableName.ObjectTypes:
                    MenuOptions = keuzeMenus.GetTypeObjectMenu();
                    menuTitle = "Object types";
                    break;
                case MenuTableName.Gevolgen:
                    MenuOptions = keuzeMenus.GetGevolgenMenu();
                    menuTitle = "Gevolgen";
                    break;
                case MenuTableName.Gevarenzones:
                    MenuOptions = keuzeMenus.GetGevarenzoneMenu();
                    menuTitle = "Gevaren zone";
                    break;
                case MenuTableName.GevaarTypes:
                    MenuOptions = keuzeMenus.GetGevaarTypeMenu();
                    menuTitle = "Gevaar type";
                    break;
                case MenuTableName.Gebruiksfases:
                    MenuOptions = keuzeMenus.GetGebruikersfasesMenu();
                    menuTitle = "Gebruiksfase";
                    break;
                case MenuTableName.Gebruikers:
                    MenuOptions = keuzeMenus.GetGebruikersMenu();
                    menuTitle = "Gebruikers";
                    break;
                case MenuTableName.Disciplines:
                    MenuOptions = keuzeMenus.GetDisciplinesMenu();
                    menuTitle = "Discipline";
                    break;
                case MenuTableName.Bedienvormen:
                    MenuOptions = keuzeMenus.GetBedienvormenMenu();
                    menuTitle = "Bedienvorm";
                    break;
                case MenuTableName.Taken:
                    MenuOptions = keuzeMenus.GetTakenMenu();
                    menuTitle = "Taak";
                    break;
                case MenuTableName.Normen:
                    MenuOptions = keuzeMenus.GetMaatregelNormMenu();
                    menuTitle = "Maatregel norm";
                    break;
                case MenuTableName.Categories:
                    MenuOptions = keuzeMenus.GetMaatregelCategoryMenu();
                    menuTitle = "Maatregel categorie";
                    break;
                case MenuTableName.TemplateTypes:
                    MenuOptions = keuzeMenus.GetTemplateTypesMenu();
                    menuTitle = "Template types";
                    break;
                case MenuTableName.TemplateToepassing:
                    MenuOptions = keuzeMenus.GetTemplateToepassingenMenu();
                    menuTitle = "Template toepassing";
                    break;
                default:
                    break;
            }
            textBoxMenuName.Text = menuTitle;
            
            foreach (string menuOption in MenuOptions)
            {
                listBoxMenuOptions.Items.Add(menuOption);
                //comboBoxObjectType.Items.Add(typeString);
            }
        }

        private void buttonEditKeuzes_Click(object sender, EventArgs e)
        {
            Form editKeuzes = new EditKeuzes(MenuTableName, MenuOptions, menuTitle);
            editKeuzes.ShowDialog();
            keuzeMenus.ReloadAllLists();
            LoadData();
  

        }
    }
}
