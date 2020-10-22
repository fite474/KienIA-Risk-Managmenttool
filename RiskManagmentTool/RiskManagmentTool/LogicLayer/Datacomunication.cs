﻿using System;
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

        public void MakeObject(string projectId, string projectNaam, string objectNaam, string objectType, string objectOmschrijving)
        {
            Item objectItem = new Item
            {
                ItemType = ItemType.Object,
                ItemData = new ObjectObject
                {
                    ProjectId = projectId,
                    ProjectNaam = projectNaam,
                    ObjectNaam = objectNaam,
                    ObjectType = objectType,
                    ObjectOmschrijving = objectOmschrijving
                }
            };
            SendItemToDB(objectItem);

        }

        public void MakeGevaar(string gevaarlijkeSituatie, string gevaarlijkeGebeurtenis,
                       string discipline, string gebruiksfase,
                       string bedienvorm, string gebruiker,
                       string gevaarlijkeZone, string taak,
                       string gevaar, string gevolg)
        {
            Item gevaarItem = new Item
            {
                ItemType = ItemType.Gevaar,
                ItemData = new GevaarObject
                {
                    GevaarlijkeSituatie = gevaarlijkeSituatie,
                    GevaarlijkeGebeurtenis = gevaarlijkeGebeurtenis,
                    Discipline = discipline,
                    Gebruiksfase = gebruiksfase,
                    Bedienvorm = bedienvorm,
                    Gebruiker = gebruiker,
                    GevaarlijkeZone = gevaarlijkeZone,
                    Taak = taak,
                    Gevaar = gevaar,
                    Gevolg = gevolg

                }
            };
            SendItemToDB(gevaarItem);

        }

        public void AddGevaarToObject(string objectId, string gevaarId)
        {
            databaseCommunication.AddGevaarToObject(objectId, gevaarId);

        }



        public DataTable GetProjectenTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetProjecten();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetObjectenFromProject(string projectId)
        {
            SqlDataAdapter adapter = databaseCommunication.GetObjectenFromProject(projectId);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }


        public DataTable GetObjectIssues(string objectID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetIssues(objectID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }



        public DataTable GetObjectenTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetObjecten();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetTemplateTable()
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

        public DataTable GetMaatregelTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetMaatregelen();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }


        public List<string> GetObjectTypes()
        {
            return databaseCommunication.GetObjectTypes();
        }

        public List<string> GetGevolgen()
        {
            return databaseCommunication.GetGevolgen();
        }

        public List<string> GetGevarenzones()
        {
            return databaseCommunication.GetGevarenzones();
        }

        public List<string> GetGevaarTypes()
        {
            return databaseCommunication.GetGevaartypes();
        }

        public List<string> GetGebruiksfases()
        {
            return databaseCommunication.GetGebruiksfases();
        }

        public List<string> GetGebruikers()
        {
            return databaseCommunication.GetGebruikers();
        }

        public List<string> GetDisciplines()
        {
            return databaseCommunication.GetDisciplines();
        }

        public List<string> GetBedienvormen()
        {
            return databaseCommunication.GetBedienvormen();
        }
        public List<string> GetTaken()
        {
            return databaseCommunication.GetTaken(); ;
        }



        public void AddToMenu(MenuTableName menuTableName, string optionToAdd)
        {
             SendMenuOptionToDB(menuTableName, optionToAdd);
        }

        private void SendMenuOptionToDB(MenuTableName menuTableName, string inputText)
        {
            switch (menuTableName)
            {
                case MenuTableName.ObjectTypes:
                    databaseCommunication.AddToObjectTypesMenu(inputText);
                    break;
                case MenuTableName.Gevolgen:
                    databaseCommunication.AddToGevolgenMenu(inputText);
                    break;
                case MenuTableName.Gevarenzones:
                    databaseCommunication.AddToGevarenzonesMenu(inputText);
                    break;
                case MenuTableName.GevaarTypes:
                    databaseCommunication.AddToGevaarTypesMenu(inputText);
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseCommunication.AddToGebruiksfasesMenu(inputText);
                    break;
                case MenuTableName.Gebruikers:
                    databaseCommunication.AddToGebruikersMenu(inputText);
                    break;
                case MenuTableName.Disciplines:
                    databaseCommunication.AddToDisciplinesMenu(inputText);
                    break;
                case MenuTableName.Bedienvormen:
                    databaseCommunication.AddToBedienvormenMenu(inputText);
                    break;
                case MenuTableName.Taken:
                    databaseCommunication.AddToTakenMenu(inputText);
                    break;
                default:
                    break;
            }

        }



        private void SendItemToDB(Item item)
        {
            switch (item.ItemType)
            {
                case ItemType.Gevaar:
                    databaseCommunication.MakeGevaar(item);
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


    }
}
