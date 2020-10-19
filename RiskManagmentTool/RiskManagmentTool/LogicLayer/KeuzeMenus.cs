using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiskManagmentTool.LogicLayer
{
    class KeuzeMenus
    {
        private List<CheckedListBox> keuzeMenuList;
        public KeuzeMenus()
        {
            keuzeMenuList = new List<CheckedListBox>();
            MakeMenu();
        }

        public List<CheckedListBox> GetKeuzeMenus()
        {
            
            return keuzeMenuList;

        }


        private void MakeMenu()
        {
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
                keuzeMenuList.Add(box);
            }
        }
    }
}
