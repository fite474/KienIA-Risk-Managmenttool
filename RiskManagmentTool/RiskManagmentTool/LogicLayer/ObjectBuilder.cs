using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskManagmentTool.LogicLayer.Objects;

namespace RiskManagmentTool.LogicLayer
{
    class ObjectBuilder
    {
        //public ObjectBuilder()
        //{

        //}

        public RisicoObject BuildRisico(string riskId, string riskBeschrijving, string riskGevolg, string riskDicipline, string riskGebruiksfase, string riskGebruiker, string riskGevarenzone)
        {
            RisicoObject objectx = new RisicoObject
            {
                riskId = riskId,
                riskBeschrijving = riskBeschrijving,
                riskGevolg = riskGevolg,
                riskDicipline = riskDicipline,
                riskGebruiksfase = riskGebruiksfase,
                riskGebruiker = riskGebruiker,
                riskGevarenzone = riskGevarenzone,

            };


            return objectx;
        }
    }
}
