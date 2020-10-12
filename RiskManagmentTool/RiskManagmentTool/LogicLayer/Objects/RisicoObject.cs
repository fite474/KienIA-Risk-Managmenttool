using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagmentTool.LogicLayer.Objects
{
    class RisicoObject
    {
        public int RisicoID { get; set; }

        public string riskId { get; set; }
        public string riskBeschrijving { get; set; }
        public string riskGevolg { get; set; }
        public string riskDicipline { get; set; }
        public string riskGebruiksfase { get; set; }
        public string riskGebruiker { get; set; }
        public string riskGevarenzone { get; set; }




        public RisicoObject()
        {
            RisicoID = 0;

        }


    
    }
}
