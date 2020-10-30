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

        public void MakeTemplate(string templateNaam, string templateType, string templateToepassing)
        {
            Item templateItem = new Item
            {
                ItemType = ItemType.Template,
                ItemData = new TemplateObject
                {
                    TemplateNaam = templateNaam,
                    TemplateType = templateType,
                    TemplateToepassing = templateToepassing
                }
            };
            SendItemToDB(templateItem);

        }

        public void AddGevaarToObject(string objectId, string gevaarId)
        {
            databaseCommunication.AddAndCreateIssueToObject(objectId, gevaarId);

        }

        //templates
        public void AddGevaarToTemplate(string templateId, string gevaarId)
        {
            databaseCommunication.AddGevaarToTemplate(templateId, gevaarId);

        }
        public void AddIssueToTemplate(string templateId, string issueId)
        {
            databaseCommunication.AddAndCreateIssueToTemplate(templateId, issueId);

        }


        //templates





        public void AddMaatregelToIssue(string issueId, string maatregelId)
        {

            databaseCommunication.AddMaatregelToIssue(Int32.Parse(issueId), Int32.Parse(maatregelId));

        }

        public void MakeMaatregel(string maatregelNaam, string maatregelNorm, string maatregelCategory)
        {
            Item maatregelItem = new Item
            {
                ItemType = ItemType.Maatregel,
                ItemData = new MaatregelObject
                {
                    MaatregelNaam = maatregelNaam,
                    MaatregelNorm = maatregelNorm,
                    MaatregelCategory = maatregelCategory
                }
            };
            SendItemToDB(maatregelItem);

        }

        public void UpdateRisicoBeoordeling(string issueID, string init_Se, string init_Fr, string init_Pr, string init_Av, string init_Cl, string init_Risico,
                                            string init_Se_Comment, string init_Fr_Comment, string init_Pr_Comment, string init_Av_Comment, string init_Cl_Comment, string init_Risico_Comment,
                                            string rest_Se, string rest_Fr, string rest_Pr, string rest_Av, string rest_Cl, string rest_Risico,
                                            string rest_Se_Comment, string rest_Fr_Comment, string rest_Pr_Comment, string rest_Av_Comment, string rest_Cl_Comment, string rest_Risico_Comment, string rest_Ok)
        {
            Item risicoInschattingItem = new Item
            {
                ItemType = ItemType.RisicoInschatting,
                ItemData = new RisicoInschattingObject
                {
                    IssueID = issueID,
                    Init_Se = init_Se,
                    Init_Fr = init_Fr,
                    Init_Pr = init_Pr,
                    Init_Av = init_Av,
                    Init_Cl = init_Cl,
                    Init_Risico = init_Risico,
                    Init_Se_Comment = init_Se_Comment,
                    Init_Fr_Comment = init_Fr_Comment,
                    Init_Pr_Comment = init_Pr_Comment,
                    Init_Av_Comment = init_Av_Comment,
                    Init_Cl_Comment = init_Cl_Comment,
                    Init_Risico_Comment =init_Risico_Comment,

                    Rest_Se = rest_Se,
                    Rest_Fr = rest_Fr,
                    Rest_Pr = rest_Pr, 
                    Rest_Av = rest_Av,
                    Rest_Cl = rest_Cl,
                    Rest_Risico = rest_Risico,
                    Rest_Se_Comment = rest_Se_Comment,
                    Rest_Fr_Comment = rest_Fr_Comment,
                    Rest_Pr_Comment = rest_Pr_Comment,
                    Rest_Av_Comment = rest_Av_Comment,
                    Rest_Cl_Comment = rest_Cl_Comment,
                    Rest_Risico_Comment = rest_Risico_Comment,
                    Rest_Ok = rest_Ok
                }
            };
            SendItemToDB(risicoInschattingItem);

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


        //public DataTable GetObjectIssues(string objectID)
        //{
        //    SqlDataAdapter adapter = databaseCommunication.GetIssues(objectID);
        //    DataTable data = new DataTable();
        //    adapter.Fill(data);
        //    return data;
        //}

        public DataTable GetObjectIssues(string objectID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetIssuesFromObject(objectID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetObjectIssuesByObjectName(string objectNaam)
        {
            string objectId = databaseCommunication.GetObjectIdByName(objectNaam);
            //SqlDataAdapter adapter = databaseCommunication.GetIssuesWorking(objectId);
            DataTable data = GetObjectIssues(objectId);//new DataTable();
            //adapter.Fill(data);
            return data;
        }

        public DataTable GetTemplateIssuesByName(string templateNaam)
        {
            string templateId = databaseCommunication.GetTemplateIdByName(templateNaam);
            SqlDataAdapter adapter = databaseCommunication.GetTemplateIssues(templateId);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetTemplateGevarenByName(string templateNaam)
        {
            string templateId = databaseCommunication.GetTemplateIdByName(templateNaam);
            SqlDataAdapter adapter = databaseCommunication.GetTemplateGevaren(templateId);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }





        public DataTable GetAllIssues()
        {
            SqlDataAdapter adapter = databaseCommunication.GetAllIssues();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetIssueMaatregelen(string objectID, string issueID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetIssueMaatregelen(objectID, issueID);
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

        public DataTable GetRisicoBeoordelingFromIssue(string issueID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetRisicoBeoordelingFromIssue(issueID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetTemplateGevaren(string templateID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetTemplateGevaren(templateID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetTemplateIssues(string templateID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetTemplateIssues(templateID);
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

        public List<string> GetMaatregelNorm()
        {//ggd
            return databaseCommunication.GetMaatregelNormen();
        }

        public List<string> GetMaatregelCategory()
        {
            return databaseCommunication.GetMaatregelCategory(); 
        }

        public List<string> GetTemplateTypes()
        {
            return databaseCommunication.GetTemplateTypes();
        }

        public List<string> GetTemplateToepassingen()
        {
            return databaseCommunication.GetTemplateToepassingen();
        }

        public List<string> GetTemplateNamen()
        {
            return databaseCommunication.GetTemplateNamen();
        }

        public List<string> GetObjectNamen()
        {
            return databaseCommunication.GetObjectNamen();
        }



        //filter opties begin
        public DataTable GetGevarenTableByDiscipline(string disciplineType)
        {
            SqlDataAdapter adapter = databaseCommunication.GetGevarenTableByDiscipline(disciplineType);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }




        //filter opties eind







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
                case MenuTableName.Normen:
                    databaseCommunication.AddToNormenMenu(inputText);
                    break;
                case MenuTableName.Categories:
                    databaseCommunication.AddToCategoriesMenu(inputText);
                    break;
                case MenuTableName.TemplateTypes:
                    databaseCommunication.AddToTemplateTypes(inputText);
                    break;
                case MenuTableName.TemplateToepassing:
                    databaseCommunication.AddToTemplateToepassingen(inputText);
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
                    databaseCommunication.MakeMaatregel(item);
                    break;
                case ItemType.Issue:

                    break;
                case ItemType.Template:
                    databaseCommunication.MakeTemplate(item);
                    break;
                case ItemType.Object:
                    databaseCommunication.MakeObject(item);
                    break;
                case ItemType.Project:
                    databaseCommunication.MakeProject(item);
                    break;
                case ItemType.RisicoInschatting:
                    databaseCommunication.UpdateRisicoBeoordeling(item);
                    break;
                default:
                    break;
            }

        }


    }
}
