using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskManagmentTool.DataLayer;
using RiskManagmentTool.LogicLayer.Objects;
using RiskManagmentTool.LogicLayer.Objects.Core;

namespace RiskManagmentTool.LogicLayer
{
    class Class1
    {
        DatabaseConnection databaseConnection;
        //remove this
        public Class1()
        {
            databaseConnection = new DatabaseConnection();
        }

        public String GetRiskId()
        {
            Item issue = new Item
            {
                ItemType = ItemType.Issue,
                ItemData = new IssueObject
                {
                    

                }

            };




            string x = databaseConnection.GetConnectionString();
            return x;

        }
    }


}
