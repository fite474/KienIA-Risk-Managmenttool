using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagmentTool.LogicLayer.Objects
{
    class MaatregelObject
    {

        public string MaatregelId { get; set; }
        public string MaatregelBeschrijving { get; set; }
        public string MaatregelGevolg { get; set; }
        public string MaatregelDiscipline { get; set; }
        public string MaatregelGebruiksfase { get; set; }
        public string MaatregelGebruiker { get; set; }
        public string MaatregelGevarenzone { get; set; }
    }
}
