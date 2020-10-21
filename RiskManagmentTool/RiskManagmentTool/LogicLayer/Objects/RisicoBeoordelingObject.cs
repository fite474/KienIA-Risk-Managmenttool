using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskManagmentTool.LogicLayer.Objects
{
    class RisicoBeoordelingObject
    {
        public int RisicoBeoordelingID{ get; set; }
        



        public ObjectSettings RBSettings { get; set; }

        //list issue id
        //list maatregel id
        //

        public RisicoBeoordelingObject()
        {
            RisicoBeoordelingID = 0;

        }


    }

}
