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
        //fdsf
        public void CreateIssue()
        {
            Item issue = new Item
            {
                ItemType = ItemType.Issue,
                ItemData = new IssueObject
                {
                    IssueId = "",
                    IssueBeschrijving = "",
                    IssueGevolg = "",
                    IssueDicipline = "",
                    IssueGebruiksfase = "",
                    IssueGebruiker = "",
                    IssueGevarenzone = "",
                    IssueSeverity = "",
                    IssueFrequency = "",
                    IssueProbability = "",
                    IssueAvoidance = "",
                    Verificatie = VerificatieStatus.Volledig
                }
            };

            switch (issue.ItemType)
            {
                case ItemType.Risico:

                    break;
                case ItemType.Maatregel:

                    break;
                case ItemType.Template:

                    break;
                case ItemType.Object:

                    break;

            }

        }







    public void template()
        {
            Item issue = new Item
            {
                ItemType = ItemType.Issue,
                ItemData = new IssueObject
                {


                }

            };

        }

        public String GetRiskId()
        {
           




            string x = databaseConnection.GetConnectionString();
            return x;

        }
    }


}
