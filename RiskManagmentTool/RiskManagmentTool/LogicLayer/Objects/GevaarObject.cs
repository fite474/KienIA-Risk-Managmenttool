using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagmentTool.LogicLayer.Objects
{
    class GevaarObject
    {
        //public int GevaarID { get; set; }
        public string GevaarlijkeSituatie { get; set; }
        public string GevaarlijkeGebeurtenis { get; set; }
        public string Discipline { get; set; }
        public string Gebruiksfase { get; set; }
        public string Bedienvorm { get; set; }
        public string Gebruiker { get; set; }
        public string GevaarlijkeZone { get; set; }
        public string Taak { get; set; }
        public string Gevaar { get; set; }
        public string Gevolg { get; set; }


        public GevaarObject()
        {
            //RisicoID = 0;

        }


    
    }
}
