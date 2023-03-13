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
        public MenuTableName MenuTableName;
        private Dictionary<int, string> MenuOptions;
        private KeuzeMenus keuzeMenus;
        private string menuTitle;

        private string objectId;// = "-1";
        public KeuzesItem(MenuTableName menuName, string objectId)
        {
            InitializeComponent();
            this.objectId = objectId;
            keuzeMenus = new KeuzeMenus(objectId);
            MenuTableName = menuName;
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

            foreach (KeyValuePair<int, string> kvp in MenuOptions)
            {
                listBoxMenuOptions.Items.Add(kvp.Value);
            }
        }

        private void buttonEditKeuzes_Click(object sender, EventArgs e)
        {
            Form editKeuzes = new EditKeuzes(MenuTableName, MenuOptions, menuTitle, objectId);
            editKeuzes.ShowDialog();
            keuzeMenus.ReloadAllLists();
            LoadData();
        }
    }
}
