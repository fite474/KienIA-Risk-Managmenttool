using System;
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
        //private List<CheckedListBox> KeuzeMenuList;


        private Dictionary<int, string> TypeObjectComboBox;

        private Dictionary<int, string> GevolgenKeuzes;
        private Dictionary<int, string> GevarenzonesKeuzes;


        private Dictionary<int, string> GevaarTypesKeuzes;

        private Dictionary<int, string> GebruiksfaseKeuzes;
        private Dictionary<int, string> GebruikersComboBox;
        private Dictionary<int, string> DisciplinesComboBox;
        private Dictionary<int, string> BedienvormenComboBox;
        private Dictionary<int, string> TakenComboBox;

        private Dictionary<int, string> MaatregelNormComboBox;
        private Dictionary<int, string> MaatregelCategoryComboBox;

        private Dictionary<int, string> TemplateTypesComboBox;
        private Dictionary<int, string> TemplateToepassingenComboBox;

        private List<string> ObjectNamenComboBox;
        private List<string> TemplateNamenComboBox;

        private Datacomunication comunicator;

        private string objectId; //used for getting global/object specific menus
        //TODO remove unused moments when app gets keuzemenus
        public KeuzeMenus()//used when no need for object specific
        {
            
            comunicator = new Datacomunication();
            this.objectId = "-1";
            MakeMenu();
        }

        public KeuzeMenus(string objectId)//used when getting object specific + global options
        {

            comunicator = new Datacomunication();
            this.objectId = objectId;
            MakeMenu();
        }

        //public List<CheckedListBox> GetKeuzeMenus()
        //{
        //    //needs to be editted
        //    return KeuzeMenuList;

        //}

        public Dictionary<int, string> GetMaatregelNormMenu()
        {
            return comunicator.GetMaatregelNorm();
            //return MaatregelNormComboBox;
        }

        public Dictionary<int, string> GetMaatregelCategoryMenu()
        {
            return comunicator.GetMaatregelCategory();
//            return MaatregelCategoryComboBox;
        }


        public Dictionary<int, string> GetTypeObjectMenu()
        {
//         return TypeObjectComboBox;
           return comunicator.GetObjectTypes();
        }

        public Dictionary<int, string> GetGevolgenMenu()
        {
            return comunicator.GetGevolgen(objectId);
//            return GevolgenKeuzes;
        }

        public Dictionary<int, string> GetGevarenzoneMenu()
        {
            return comunicator.GetGevarenzones(objectId);
//            return GevarenzonesKeuzes;
        }



        public Dictionary<int, string> GetGevaarTypeMenu()
        {
            return comunicator.GetGevaarTypes(objectId);
//            return GevaarTypesKeuzes;
        }


        public Dictionary<int, string> GetGebruikersfasesMenu()
        {
            return comunicator.GetGebruiksfases(objectId);
//            return GebruiksfaseKeuzes;
        }

        public Dictionary<int, string> GetGebruikersMenu()
        {
            return comunicator.GetGebruikers(objectId);
//            return GebruikersComboBox;
        }

        public Dictionary<int, string> GetDisciplinesMenu()
        {
            return comunicator.GetDisciplines(objectId);
//            return DisciplinesComboBox;
        }

        public Dictionary<int, string> GetBedienvormenMenu()
        {
            return comunicator.GetBedienvormen(objectId);
//            return BedienvormenComboBox;
        }

        public Dictionary<int, string> GetTakenMenu()
        {
            return comunicator.GetTaken(objectId);
//            return TakenComboBox;
        }

        public Dictionary<int, string> GetTemplateTypesMenu()
        {
            return TemplateTypesComboBox;
        }

        public Dictionary<int, string> GetTemplateToepassingenMenu()
        {
            return TemplateToepassingenComboBox;
        }


        public List<string> GetTemplateNamen()
        {
            return comunicator.GetTemplateNamen();
//            return TemplateNamenComboBox;
        }
        public List<string> GetObjectNamen()
        {
            return comunicator.GetObjectNamen();
//            return ObjectNamenComboBox;
        }



        public void ReloadAllLists()
        {//wanneer de gebruiker een nieuw item toevoegd aan de keuzes moeten de lists opnieuw opgehaald worden
            MakeMenu();
        }


        //todo make this methode optimized so it doesnt get all unused lists.
        //currently this methode gets all list while the rest of the application crreates a new object/instance of this class for each menu option resulting in n * n lists instead of n lists
        private void MakeMenu()
        {

            //TypeObjectComboBox = comunicator.GetObjectTypes();

            ////-------------

            //GevolgenKeuzes = comunicator.GetGevolgen(objectId);
            //GevarenzonesKeuzes = comunicator.GetGevarenzones(objectId);
            //GevaarTypesKeuzes = comunicator.GetGevaarTypes(objectId);
            //GebruiksfaseKeuzes = comunicator.GetGebruiksfases(objectId);
            //GebruikersComboBox = comunicator.GetGebruikers(objectId);
            //DisciplinesComboBox = comunicator.GetDisciplines(objectId);
            //BedienvormenComboBox = comunicator.GetBedienvormen(objectId);
            //TakenComboBox = comunicator.GetTaken(objectId);


            ////-------------

            //MaatregelNormComboBox = comunicator.GetMaatregelNorm();
            //MaatregelCategoryComboBox = comunicator.GetMaatregelCategory();

            //TemplateTypesComboBox = comunicator.GetTemplateTypes();
            //TemplateToepassingenComboBox = comunicator.GetTemplateToepassingen();




            //ObjectNamenComboBox = comunicator.GetObjectNamen();
            //TemplateNamenComboBox = comunicator.GetTemplateNamen();






            //KeuzeMenuList = new List<CheckedListBox>();



            //int placeX = 0;
            //for (int i = 0; i < 5; i++)
            //{
            //    CheckedListBox box = new CheckedListBox();
            //    for (int j = 0; j < 5; j++)
            //    {
            //        string keuzeOptie = "keuze " + j;
            //        bool isKeuzeChecked = false;
            //        box.Items.Add(keuzeOptie, isKeuzeChecked);
            //    }
                
            //    box.Location = new System.Drawing.Point(placeX, 0);
            //    placeX += 200;
            //    KeuzeMenuList.Add(box);
            //}
        }
    }
}
