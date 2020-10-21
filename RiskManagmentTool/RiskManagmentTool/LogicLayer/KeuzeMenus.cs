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
        private List<CheckedListBox> KeuzeMenuList;
        private List<string> TypeObjectComboBox;
        private Datacomunication comunicator;
        public KeuzeMenus()
        {
            
            comunicator = new Datacomunication();
            MakeMenu();
        }

        public List<CheckedListBox> GetKeuzeMenus()
        {
            
            return KeuzeMenuList;

        }

        public List<string> GetTypeObjectMenu()
        {
            return TypeObjectComboBox;
        }


        private void MakeMenu()
        {

            TypeObjectComboBox = comunicator.GetObjectTypes();








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
