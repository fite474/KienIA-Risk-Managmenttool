using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RiskManagmentTool.DataLayer;
using RiskManagmentTool.LogicLayer.Objects;
using RiskManagmentTool.LogicLayer.Objects.Core;

namespace RiskManagmentTool.LogicLayer
{
    class Datacomunication
    {
        private DatabaseCommunication databaseCommunication;
        public Datacomunication()
        {
            databaseCommunication = new DatabaseCommunication();
        }




        public void MakeProject(string projectNaam)
        {
            Item projectItem = new Item
            {
                ItemType = ItemType.Project,
                ItemData = new ProjectObject
                {
                    ProjectNaam = projectNaam

                }
            };
            SendItemToDB(projectItem);

        }

        public void MakeObject(string projectNaam, string objectNaam, string objectType, string objectOmschrijving)
        {
            Item objectItem = new Item
            {
                ItemType = ItemType.Object,
                ItemData = new ObjectObject
                {
                    ProjectNaam = projectNaam,
                    ObjectNaam = objectNaam,
                    ObjectType = objectType,
                    ObjectOmschrijving = objectOmschrijving
                }
            };
            SendItemToDB(objectItem);

        }













        public DataTable GetProjectenTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetProjecten();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetObjectenFromProject(string projectNaam)
        {
            SqlDataAdapter adapter = databaseCommunication.GetObjectenFromProject(projectNaam);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }


        public List<string> GetObjectTypes()
        {
            return databaseCommunication.GetObjectTypes();

        }

        public void AddToMenu(string menuTitel, string optionToAdd)
        {
            databaseCommunication.AddToMenu(menuTitel, optionToAdd);
        }





        private void SendItemToDB(Item item)
        {
            switch (item.ItemType)
            {
                case ItemType.Risico:

                    break;
                case ItemType.Maatregel:

                    break;
                case ItemType.Issue:

                    break;
                case ItemType.Template:

                    break;
                case ItemType.Object:
                    databaseCommunication.MakeObject(item);
                    break;
                case ItemType.Project:
                    databaseCommunication.MakeProject(item);
                    break;
                default:
                    break;
            }

        }







        public DataTable getObjectIssues(string objectNaam)
        {
            SqlDataAdapter adapter = databaseCommunication.GetIssues(objectNaam);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public List<string> GetGekoppeldeObjecten()
        {
            return databaseCommunication.GetGekoppeldeObjecten();

        }

        public DataTable getObjectenTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetObjecten();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable getTemplateTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetTemplates();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetGevarenTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetGevaren();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable getMaatregelTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetMaatregelen();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
