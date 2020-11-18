﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiskManagmentTool.DataLayer;

namespace RiskManagmentTool.LogicLayer
{
    class KeuzeMenus
    {
        private List<CheckedListBox> KeuzeMenuList;


        private List<string> TypeObjectComboBox;

        private List<string> GevolgenKeuzes;
        private List<string> GevarenzonesKeuzes;
        private List<string> GevaarTypesKeuzes;
        private List<string> GebruiksfaseKeuzes;
        private List<string> GebruikersComboBox;
        private List<string> DisciplinesComboBox;
        private List<string> BedienvormenComboBox;
        private List<string> TakenComboBox;

        private List<string> MaatregelNormComboBox;
        private List<string> MaatregelCategoryComboBox;

        private List<string> TemplateTypesComboBox;
        private List<string> TemplateToepassingenComboBox;

        private List<string> ObjectNamenComboBox;
        private List<string> TemplateNamenComboBox;

        private Datacomunication comunicator;

        
        public KeuzeMenus()
        {
            
            comunicator = new Datacomunication();
            MakeMenu();
        }



        public List<CheckedListBox> GetKeuzeMenus()
        {
            //needs to be editted
            return KeuzeMenuList;

        }

        public List<string> GetMaatregelNormMenu()
        {
            return MaatregelNormComboBox;
        }

        public List<string> GetMaatregelCategoryMenu()
        {
            return MaatregelCategoryComboBox;
        }


        public List<string> GetTypeObjectMenu()
        {
            return TypeObjectComboBox;
        }

        public List<string> GetGevolgenMenu()
        {
            return GevolgenKeuzes;
        }

        public List<string> GetGevarenzoneMenu()
        {
            return GevarenzonesKeuzes;
        }

        public List<string> GetGevaarTypeMenu()
        {
            return GevaarTypesKeuzes;
        }

        public List<string> GetGebruikersfasesMenu()
        {
            return GebruiksfaseKeuzes;
        }

        public List<string> GetGebruikersMenu()
        {
            return GebruikersComboBox;
        }

        public List<string> GetDisciplinesMenu()
        {
            return DisciplinesComboBox;
        }

        public List<string> GetBedienvormenMenu()
        {
            return BedienvormenComboBox;
        }

        public List<string> GetTakenMenu()
        {
            return TakenComboBox;
        }

        public List<string> GetTemplateTypesMenu()
        {
            return TemplateTypesComboBox;
        }

        public List<string> GetTemplateToepassingenMenu()
        {
            return TemplateToepassingenComboBox;
        }


        public List<string> GetTemplateNamen()
        {
            return TemplateNamenComboBox;
        }
        public List<string> GetObjectNamen()
        {
            return ObjectNamenComboBox;
        }



        public void ReloadAllLists()
        {//wanneer de gebruiker een nieuw item toevoegd aan de keuzes moeten de lists opnieuw opgehaald worden
            MakeMenu();
        }

        private void MakeMenu()
        {

            TypeObjectComboBox = comunicator.GetObjectTypes();
            GevolgenKeuzes = comunicator.GetGevolgen();
            GevarenzonesKeuzes = comunicator.GetGevarenzones();
            GevaarTypesKeuzes = comunicator.GetGevaarTypes();
            GebruiksfaseKeuzes = comunicator.GetGebruiksfases();
            GebruikersComboBox = comunicator.GetGebruikers();
            DisciplinesComboBox = comunicator.GetDisciplines();
            BedienvormenComboBox = comunicator.GetBedienvormen();
            TakenComboBox = comunicator.GetTaken();
            MaatregelNormComboBox = comunicator.GetMaatregelNorm();
            MaatregelCategoryComboBox = comunicator.GetMaatregelCategory();

            TemplateTypesComboBox = comunicator.GetTemplateTypes();
            TemplateToepassingenComboBox = comunicator.GetTemplateToepassingen();

            ObjectNamenComboBox = comunicator.GetObjectNamen();
            TemplateNamenComboBox = comunicator.GetTemplateNamen();






            KeuzeMenuList = new List<CheckedListBox>();



            int placeX = 0;
            for (int i = 0; i < 5; i++)
            {
                CheckedListBox box = new CheckedListBox();
                for (int j = 0; j < 5; j++)
                {
                    string keuzeOptie = "keuze " + j;
                    bool isKeuzeChecked = false;
                    box.Items.Add(keuzeOptie, isKeuzeChecked);
                }
                
                box.Location = new System.Drawing.Point(placeX, 0);
                placeX += 200;
                KeuzeMenuList.Add(box);
            }
        }
    }
}
