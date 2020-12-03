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
using System.Windows.Forms;

namespace RiskManagmentTool.LogicLayer
{
    class Datacomunication
    {
        private DatabaseCommunication databaseCommunication;
        public Datacomunication()
        {
            databaseCommunication = new DatabaseCommunication();
        }

        #region Init
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

        public int MakeObject(string projectId, string projectNaam, string objectNaam, string objectType, string objectOmschrijving)
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
            //SendItemToDB(objectItem);
            return databaseCommunication.MakeObject(objectItem);
        }



        public void InitMakeGevaar(string gevaarlijkeSituatie, string gevaarlijkeGebeurtenis,
                       Dictionary<int, int> GevaarDisciplines, Dictionary<int, int> GevaarGebruiksfase,
                       Dictionary<int, int> GevaarBedienvorm, Dictionary<int, int> GevaarGebruiker,
                       Dictionary<int, int> GevaarGevaarlijkeZone, Dictionary<int, int> GevaarTaak,
                       Dictionary<int, int> GevaarGevaarType, Dictionary<int, int> GevaarGevolg)
        {
            int gevaarID = databaseCommunication.InitMakeGevaar(gevaarlijkeSituatie, gevaarlijkeGebeurtenis);

            if (GevaarDisciplines.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarDisciplines)
                {
                    databaseCommunication.MakeGevaar_Disciplines(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Disciplines(gevaarID, null); }


            if (GevaarGebruiksfase.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGebruiksfase)
                {
                    databaseCommunication.MakeGevaar_Gebruiksfase(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Gebruiksfase(gevaarID, null); }


            if (GevaarBedienvorm.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarBedienvorm)
                {
                    databaseCommunication.MakeGevaar_Bedienvorm(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Bedienvorm(gevaarID, null); }


            if (GevaarGebruiker.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGebruiker)
                {
                    databaseCommunication.MakeGevaar_Gebruiker(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Gebruiker(gevaarID, null); }


            if (GevaarGevaarlijkeZone.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevaarlijkeZone)
                {
                    databaseCommunication.MakeGevaar_GevaarlijkeZone(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_GevaarlijkeZone(gevaarID, null); }


            if (GevaarTaak.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarTaak)
                {
                    databaseCommunication.MakeGevaar_Taak(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Taak(gevaarID, null); }


            if (GevaarGevaarType.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevaarType)
                {
                    databaseCommunication.MakeGevaar_GevaarType(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_GevaarType(gevaarID, null); }


            if (GevaarGevolg.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevolg)
                {
                    databaseCommunication.MakeGevaar_Gevolg(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Gevolg(gevaarID, null); }
        }


        public void InitMaatregel(string maatregelNaam, Dictionary<int, int> maatregelNorm, Dictionary<int, int> maatregelCategory)
        {
            int maatregelID = databaseCommunication.InitMaatregel(maatregelNaam);

            if (maatregelNorm.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in maatregelNorm)
                {
                    databaseCommunication.MakeMaatregel_Norm(maatregelID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeMaatregel_Norm(maatregelID, null); }


            if (maatregelCategory.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in maatregelCategory)
                {
                    databaseCommunication.MakeMaatregel_Categorie(maatregelID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeMaatregel_Categorie(maatregelID, null); }
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
        #endregion Init


        #region Update

        public void UpdateGevaarSituatie(int gevaarID, string text)
        {
            databaseCommunication.UpdateGevaarSituatie(gevaarID, text);
        }

        public void UpdateGevaarGebeurtenis(int gevaarID, string text)
        {
            databaseCommunication.UpdateGevaarGebeurtenis(gevaarID, text);
        }

        public void UpdateGevaarData(int gevaarID,
              Dictionary<int, int> GevaarDisciplines, Dictionary<int, int> GevaarGebruiksfase,
              Dictionary<int, int> GevaarBedienvorm, Dictionary<int, int> GevaarGebruiker,
              Dictionary<int, int> GevaarGevaarlijkeZone, Dictionary<int, int> GevaarTaak,
              Dictionary<int, int> GevaarGevaarType, Dictionary<int, int> GevaarGevolg)
        {
            //clean
            databaseCommunication.VerwijderGevaar_Disciplines(gevaarID);
            databaseCommunication.VerwijderGevaar_Gebruiksfases(gevaarID);
            databaseCommunication.VerwijderGevaar_Bedienvorm(gevaarID);
            databaseCommunication.VerwijderGevaar_Gebruiker(gevaarID);
            databaseCommunication.VerwijderGevaar_GevaarlijkeZone(gevaarID);
            databaseCommunication.VerwijderGevaar_Taak(gevaarID);
            databaseCommunication.VerwijderGevaar_GevaarType(gevaarID);
            databaseCommunication.VerwijderGevaar_Gevolg(gevaarID);

            //insert for all
            if (GevaarDisciplines.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarDisciplines)
                {
                    databaseCommunication.MakeGevaar_Disciplines(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Disciplines(gevaarID, null); }

            if (GevaarGebruiksfase.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGebruiksfase)
                {
                    databaseCommunication.MakeGevaar_Gebruiksfase(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Gebruiksfase(gevaarID, null); }


            if (GevaarBedienvorm.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarBedienvorm)
                {
                    databaseCommunication.MakeGevaar_Bedienvorm(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Bedienvorm(gevaarID, null); }


            if (GevaarGebruiker.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGebruiker)
                {
                    databaseCommunication.MakeGevaar_Gebruiker(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Gebruiker(gevaarID, null); }


            if (GevaarGevaarlijkeZone.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevaarlijkeZone)
                {
                    databaseCommunication.MakeGevaar_GevaarlijkeZone(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_GevaarlijkeZone(gevaarID, null); }


            if (GevaarTaak.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarTaak)
                {
                    databaseCommunication.MakeGevaar_Taak(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Taak(gevaarID, null); }


            if (GevaarGevaarType.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevaarType)
                {
                    databaseCommunication.MakeGevaar_GevaarType(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_GevaarType(gevaarID, null); }


            if (GevaarGevolg.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevolg)
                {
                    databaseCommunication.MakeGevaar_Gevolg(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeGevaar_Gevolg(gevaarID, null); }

        }

        public void UpdateMaatregelData(int maatregelID, Dictionary<int, int> maatregelNorm, Dictionary<int, int> maatregelCategory)
        {
            //clean
            databaseCommunication.VerwijderMaatregel_Norm(maatregelID);
            databaseCommunication.VerwijderMaatregel_Category(maatregelID);

            //insert for all
            if (maatregelNorm.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in maatregelNorm)
                {
                    databaseCommunication.MakeMaatregel_Norm(maatregelID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeMaatregel_Norm(maatregelID, null); }

            if (maatregelCategory.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in maatregelCategory)
                {
                    databaseCommunication.MakeMaatregel_Categorie(maatregelID, kvp.Value);
                }
            }
            else
            { databaseCommunication.MakeMaatregel_Categorie(maatregelID, null); }

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
                    Init_Risico_Comment = init_Risico_Comment,

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

        public void UpdateIssueState(string issueId, string newState)
        {
            databaseCommunication.UpdateIssueState(issueId, newState);
        }

        #endregion Update


        public void AddImageToIssue(string issueID, string imageFilePath)
        {
            databaseCommunication.AddImageToIssue(issueID, imageFilePath);

        }
        #region add to object
        public int AddGevaarToObject(string objectId, string gevaarId)
        {
            return databaseCommunication.AddAndCreateIssueToObject(objectId, gevaarId);
        }

        public void AddIssueToObject(string objectId, string issueId, bool addMaatregelen, bool addBeoordeling, bool issueNeedsToVerify)
        {
            string issueState = "-1";
            if (issueNeedsToVerify)
            {
                issueState = "0";// 0 is nog niet goedgekeurd
            }
            else
            {
                issueState = "1"; // 1 betekent goedgekeurd
            }

            int newIssueId = databaseCommunication.AddCoppiedIssueToObject(objectId, issueId, issueState);

            if (addMaatregelen)
            {
                List<string> maatregelenFromCopiedIssue = databaseCommunication.GetMaatregelenFromIssues(issueId);
                foreach (string maatregelId in maatregelenFromCopiedIssue)
                {
                    databaseCommunication.AddMaatregelToIssue(newIssueId, int.Parse(maatregelId));
                }

            }

            if (addBeoordeling)
            {
                int risicoBeoordelingId = databaseCommunication.InitRisicoBeoordelingDuplicate(newIssueId, issueId);
                databaseCommunication.AddRisicoBeoordelingToIssue(risicoBeoordelingId, newIssueId);
            }
            else
            {
                int risicoBeoordelingId = databaseCommunication.InitRisicoBeoordeling(newIssueId);
                databaseCommunication.AddRisicoBeoordelingToIssue(risicoBeoordelingId, newIssueId);
            }

        }

        public void AddImageToObject(string objectID, string imageFilePath)
        {
            databaseCommunication.AddImageToObject(objectID, imageFilePath);

        }

        #endregion add to object


        #region GET REQUEST FROM DATABASE

        #region get tables
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

        public BindingSource GetObjectIssues(string objectID)//DataTable GetObjectIssues(string objectID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetIssuesFromObject(objectID);
            DataTable data = new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;//data;
        }



        public DataTable GetObjectIssuesByObjectName(string objectNaam)
        {
            string objectId = databaseCommunication.GetObjectIdByName(objectNaam);
            SqlDataAdapter adapter = databaseCommunication.GetIssuesFromObject(objectId);
            DataTable data = new DataTable();//GetObjectIssues(objectId);//new DataTable();
            adapter.Fill(data);
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

        public DataTable GetSelectedObjectIssues(string objectNaam, List<string> selectedIssuesId)
        {
            string objectId = databaseCommunication.GetObjectIdByName(objectNaam);
            SqlDataAdapter adapter = databaseCommunication.GetSelectedIssuesFromObject(objectId, selectedIssuesId);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetSelectedTemplateIssues(string templateNaam, List<string> selectedIssuesId)
        {
            string templateId = databaseCommunication.GetTemplateIdByName(templateNaam);
            SqlDataAdapter adapter = databaseCommunication.GetSelectedIssuesFromTemplate(templateId, selectedIssuesId);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetSelectedTemplateGevaren(string templateNaam, List<string> selectedGevarenId)
        {
            string templateId = databaseCommunication.GetTemplateIdByName(templateNaam);
            SqlDataAdapter adapter = databaseCommunication.GetSelectedGevarenFromTemplate(templateId, selectedGevarenId);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable GetSelectedGevaren(List<string> selectedGevarenId)
        {
            //string templateId = databaseCommunication.GetTemplateIdByName(templateNaam);
            SqlDataAdapter adapter = databaseCommunication.GetSelectedGevaren(selectedGevarenId);//GetSelectedGevarenFromTemplate(templateId, selectedGevarenId);
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

        public DataTable GetAllIssuesWithGevaarID(string gevaarID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetAllIssuesWithGevaarID(gevaarID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public BindingSource GetIssueMaatregelen(string issueID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetIssueMaatregelen(issueID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
        }

        public BindingSource GetObjectenTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetObjecten();
            DataTable data = new DataTable();
            adapter.Fill(data);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
        }

        public BindingSource GetTemplateTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetTemplates();
            DataTable data = new DataTable();
            adapter.Fill(data);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
        }

        public BindingSource GetGevarenTable()//DataTable GetGevarenTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetGevaren();
            DataTable data = new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;


            //return data;
        }

        public BindingSource GetMaatregelTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetMaatregelen();
            DataTable data = new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
            //return data;
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

        #endregion get tables

        #region get info

        public string GetObjectImage(string objectID)
        {
            string filePath = databaseCommunication.GetObjectImage(objectID);
            return filePath;
        }

        public string GetIssueImage(string issueID)
        {
            string filePath = databaseCommunication.GetIssueImage(issueID);
            return filePath;
        }

        #endregion get info

        #endregion GET REQUEST FROM DATABASE

        #region delete
        public void DeleteIssueFromObject(string objectId, string issueId)
        {
            databaseCommunication.VerwijderIssuesVanObject(objectId, issueId);
            databaseCommunication.VerwijderMaatregelenVanIssue(issueId);
            databaseCommunication.VerwijderRisicoBeoordelingVanIssue(issueId);
            databaseCommunication.VerwijderIssue(issueId);
        }


        public void DeleteGevaar(string gevaarID)
        {

        }
        #endregion delete


        public void AddGevaarToTemplate(string templateId, string gevaarId)
        {
            databaseCommunication.AddGevaarToTemplate(templateId, gevaarId);

        }
        public void AddIssueToTemplate(string templateId, string issueId)
        {
            databaseCommunication.AddAndCreateIssueToTemplate(templateId, issueId);

        }





        public void AddMaatregelToIssue(string issueId, string maatregelId)
        {

            databaseCommunication.AddMaatregelToIssue(Int32.Parse(issueId), Int32.Parse(maatregelId));

        }




        public List<string> GetGekoppeldeGevarenFromTemplateAsList(string templateId)
        {
            return databaseCommunication.GetGekoppeldeGevarenFromTemplateAsList(templateId);
        }

        public List<string> GetGekoppeldeIssuesFromTemplateAsList(string templateId)
        {
            return databaseCommunication.GetGekoppeldeIssuesFromTemplateAsList(templateId);
        }

        public List<string> GetGekoppeldeIssuesFromObjectAsList(string objectId)
        {
            return databaseCommunication.GetGekoppeldeIssuesFromObjectAsList(objectId);
        }

        public List<string> GetGekoppeldeGevarenFromObjectAsList(string objectId)
        {
            return databaseCommunication.GetGekoppeldeGevarenFromObjectAsList(objectId);
        }

        public List<string> GetGevarenFromIssuesAsList(List<string> selectedIssuesId)
        {
            return databaseCommunication.GetGevarenFromIssuesAsList(selectedIssuesId);
        }

        public List<string> GetMaatregelenFromIssuesAsList(string issueID)
        {
            return databaseCommunication.GetMaatregelenFromIssues(issueID);
        }





        //get selected
        



        //get selected



        //Begin redirect options
        public string GetGevaarIdByIssueID(string issueID)
        {
            string gevaarId = "";
            gevaarId = databaseCommunication.FindGevaarID(issueID);

            return gevaarId;
        }


        public string GetObjectIdByIssueNmr(string issueID)
        {
            string objectId = "";
            objectId = databaseCommunication.GetObjectIdByIssue(issueID);

            return objectId;
        }

        public string GetObjectIdByName(string objectNaam)
        {
            return databaseCommunication.GetObjectIdByName(objectNaam);
            //return objectId;
        }


        public string GetIssueIdByObjectAndGevaarId(string objectId, string gevaarId)
        {
            return databaseCommunication.GetIssueIdByObjectAndGevaarId(objectId, gevaarId);
        }

        public List<string> GetIssueInfo(string issueId)
        {
            return databaseCommunication.GetIssuesInfo(issueId);
        }

        public List<string> GetObjectInfo(string objectId)
        {
            return databaseCommunication.GetObjectInfo(objectId);
        }

        public string GetIssueState(string issueId)
        {
            return databaseCommunication.GetIssueState(issueId);
        }

        public string GetLastTemplateID()
        {
            return databaseCommunication.GetLastTemplateID();
        }

        //End redirect options




        #region Get usage

        public DataTable GetGevarenUsage(string gevaarID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetGevarenUsage(gevaarID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;

        }


        public DataTable CheckUsageFromMenu(MenuTableName menuTableName, string optionToCheck)
        {
            return CheckUsageMenuOptionFromDB(menuTableName, optionToCheck);
        }

        private DataTable CheckUsageMenuOptionFromDB(MenuTableName menuTableName, string optionToCheck)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            switch (menuTableName)
            {
                case MenuTableName.ObjectTypes:
                    adapter = databaseCommunication.GetObjectTypeUsage(optionToCheck);
                    
                    break;
                case MenuTableName.Gevolgen:
                    adapter = databaseCommunication.GetGevolgenUsage(optionToCheck);
                    break;
                case MenuTableName.Gevarenzones:
                    adapter = databaseCommunication.GetGevarenZoneUsage(optionToCheck);
                    break;
                case MenuTableName.GevaarTypes:
                    adapter = databaseCommunication.GetGevaarTypeUsage(optionToCheck);
                    break;
                case MenuTableName.Gebruiksfases:
                    adapter = databaseCommunication.GetGebruiksfaseUsage(optionToCheck);
                    break;
                case MenuTableName.Gebruikers:
                    adapter = databaseCommunication.GetGebruikerUsage(optionToCheck);
                    break;
                case MenuTableName.Disciplines:
                    adapter = databaseCommunication.GetDisciplineUsage(optionToCheck);
                    break;
                case MenuTableName.Bedienvormen:
                    adapter = databaseCommunication.GetBedienvormUsage(optionToCheck);
                    break;
                case MenuTableName.Taken:
                    adapter = databaseCommunication.GetGevaarTaakUsage(optionToCheck);
                    break;
                case MenuTableName.Normen:

                    break;
                case MenuTableName.Categories:

                    break;
                case MenuTableName.TemplateTypes:

                    break;
                case MenuTableName.TemplateToepassing:

                    break;
                default:
                    break;
            }

            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;

        }






        #endregion Get usage






        #region get menus opties

        public Dictionary<int, string> GetObjectTypes()
        {
            return databaseCommunication.GetObjectTypes();
        }





        //-----------------

        public Dictionary<int, string> GetGevolgen()
        {
            return databaseCommunication.GetGevolgen();
        }


        public Dictionary<int, string> GetGevarenzones()
        {
            return databaseCommunication.GetGevarenzones();
        }

        public Dictionary<int, string> GetGevaarTypes()
        {
            return databaseCommunication.GetGevaarTypes();
        }

        public Dictionary<int, string> GetGebruiksfases()
        {
            return databaseCommunication.GetGebruiksfases();
        }

        public Dictionary<int, string> GetGebruikers()
        {
            return databaseCommunication.GetGebruikers();
        }

        public Dictionary<int, string> GetDisciplines()
        {
            return databaseCommunication.GetDisciplines();
        }

        public Dictionary<int, string> GetBedienvormen()
        {
            return databaseCommunication.GetBedienvormen();
        }

        public Dictionary<int, string> GetTaken()
        {
            return databaseCommunication.GetTaken();
        }






        //-----------------------


        public Dictionary<int, string> GetMaatregelNorm()
        {
            return databaseCommunication.GetNormen();
        }

        public Dictionary<int, string> GetMaatregelCategory()
        {
            return databaseCommunication.GetCategory(); 
        }

        public Dictionary<int, string> GetTemplateTypes()
        {
            return databaseCommunication.GetTemplateTypes();
        }

        public Dictionary<int, string> GetTemplateToepassingen()
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

        #endregion get menu options

        //filter opties begin
        public DataTable GetGevarenTableByDiscipline(string disciplineType)
        {
            SqlDataAdapter adapter = databaseCommunication.GetGevarenTableByDiscipline(disciplineType);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }


        //filter opties eind




        //begin check states 
        public Dictionary<string, string> GetObjectIssuesStates(string objectID)
        {
            return databaseCommunication.GetObjectIssuesState(objectID);
        }
        public Dictionary<string, string> GetObjectIssuesRiskValue(string objectID)
        {
            return databaseCommunication.GetObjectIssuesRiskValue(objectID);
        }


        public Dictionary<string, int> GetObjectIssuesMaatregelenCount(string objectID)
        {
            Dictionary<string, int> issuesMaatregelenCount = new Dictionary<string, int>();
            foreach (string issueID in databaseCommunication.GetGekoppeldeIssuesFromObjectAsList(objectID))
            {
                int amountOfMaatregelen = databaseCommunication.GetMaatregelenFromIssues(issueID).Count;
                issuesMaatregelenCount.Add(issueID, amountOfMaatregelen);
            }


            return issuesMaatregelenCount;
        }

        // end check states


        




        #region gevaren lists
        public DataTable GetGevaar_Situatie_gebeurtenis(string gevaarID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetGevaar_Situatie_gebeurtenis(gevaarID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }




        public Dictionary<int, int> GetGevaar_Disciplines(string gevaarID)
        {
            return databaseCommunication.GetGevaar_Disciplines(gevaarID);
        }

        public Dictionary<int, int> GetGevaar_Bedienvorm(string gevaarID)
        {
            return databaseCommunication.GetGevaar_Bedienvorm(gevaarID);
        }

        public Dictionary<int, int> GetGevaar_Gebruiker(string gevaarID)
        {
            return databaseCommunication.GetGevaar_Gebruiker(gevaarID);
        }

        public Dictionary<int, int> GetGevaar_Gebruiksfase(string gevaarID)
        {
            return databaseCommunication.GetGevaar_Gebruiksfase(gevaarID);
        }

        public Dictionary<int, int> GetGevaar_GevaarlijkeZone(string gevaarID)
        {
            return databaseCommunication.GetGevaar_GevaarlijkeZone(gevaarID);
        }

        public Dictionary<int, int> GetGevaar_GevaarType(string gevaarID)
        {
            return databaseCommunication.GetGevaar_GevaarType(gevaarID);
        }

        public Dictionary<int, int> GetGevaar_Gevolg(string gevaarID)
        {
            return databaseCommunication.GetGevaar_Gevolg(gevaarID);
        }

        public Dictionary<int, int> GetGevaar_Taak(string gevaarID)
        {
            return databaseCommunication.GetGevaar_Taak(gevaarID);
        }
        #endregion gevaren lists

        #region maatregelen lists
        public Dictionary<int, int> GetMaatregel_Normen(string maatregelID)
        {
            return databaseCommunication.GetMaatregel_Normen(maatregelID);
        }

        public Dictionary<int, int> GetMaatregel_Categorie(string maatregelID)
        {
            return databaseCommunication.GetMaatregel_Categorie(maatregelID);
        }


        #endregion maatregelen lists




        








        public void DeleteUsageAndMenuOption(MenuTableName menuTableName, string optionToDelete)
        {
            string optionID = GetOptionID(menuTableName, optionToDelete);

            DeleteMenuOptionUsage(menuTableName, optionID);
            DeleteFromMenu(menuTableName, optionToDelete);

        }

        private string GetOptionID(MenuTableName menuTableName, string optionTextToFind)
        {
            string optionID = "";
            string databaseTableName = "";
            string databaseIDColumnName = "";
            string databaseColumnName = "";
            
            switch (menuTableName)
            {
                case MenuTableName.ObjectTypes:
                    //databaseCommunication.DeleteFromObjectTypesMenu(optionID);
                    break;
                case MenuTableName.Gevolgen:
                    databaseTableName = "Gevolgen";
                    databaseIDColumnName = "GevolgID";
                    databaseColumnName = "Gevolg";
                    break;
                case MenuTableName.Gevarenzones:
                    databaseTableName = "Gevarenzones";
                    databaseIDColumnName = "GevarenzoneID";
                    databaseColumnName = "Gevarenzone";
                    break;
                case MenuTableName.GevaarTypes:
                    databaseTableName = "GevaarTypes";
                    databaseIDColumnName = "GevaarTypeID";
                    databaseColumnName = "GevaarType";
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseTableName = "Gebruiksfases";
                    databaseIDColumnName = "GebruiksfaseID";
                    databaseColumnName = "Gebruiksfase";
                    break;
                case MenuTableName.Gebruikers:
                    databaseTableName = "Gebruikers";
                    databaseIDColumnName = "GebruikerID";
                    databaseColumnName = "Gebruiker";
                    break;
                case MenuTableName.Disciplines:
                    databaseTableName = "Disciplines";
                    databaseIDColumnName = "DisciplineID";
                    databaseColumnName = "Discipline";
                    break;
                case MenuTableName.Bedienvormen:
                    databaseTableName = "Bedienvormen";
                    databaseIDColumnName = "BedienvormID";
                    databaseColumnName = "Bedienvorm";
                    break;
                case MenuTableName.Taken:
                    databaseTableName = "Taken";
                    databaseIDColumnName = "TaakID";
                    databaseColumnName = "Taak";
                    break;
                case MenuTableName.Normen:
                    //databaseCommunication.AddToNormenMenu(inputText);
                    break;
                case MenuTableName.Categories:
                    //databaseCommunication.AddToCategoriesMenu(inputText);
                    break;
                case MenuTableName.TemplateTypes:
                    //databaseCommunication.AddToTemplateTypes(inputText);
                    break;
                case MenuTableName.TemplateToepassing:
                    //databaseCommunication.AddToTemplateToepassingen(inputText);
                    break;
                default:
                    break;
            }
            optionID = databaseCommunication.GetMenuOptionID(databaseTableName, databaseIDColumnName, databaseColumnName, optionTextToFind);

            return optionID;
        }

        private void DeleteMenuOptionUsage(MenuTableName menuTableName, string optionID)
        {
            string databaseTableName = "";
            string databaseColumnName = "";
            switch (menuTableName)
            {
                case MenuTableName.ObjectTypes:
                    //databaseCommunication.DeleteFromObjectTypesMenu(optionID);
                    break;
                case MenuTableName.Gevolgen:
                    databaseTableName = "Gevaar_Gevolg";
                    databaseColumnName = "GevolgID";
                   // databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);
                    break;
                case MenuTableName.Gevarenzones:

                    databaseTableName = "Gevaar_GevaarlijkeZone";
                    databaseColumnName = "GevaarlijkeZoneID";
                   // databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);
                    break;
                case MenuTableName.GevaarTypes:
                    databaseTableName = "Gevaar_GevaarType";
                    databaseColumnName = "GevaarTypeID";
                   // databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseTableName = "Gevaar_Gebruiksfase";
                    databaseColumnName = "GebruiksfaseID";
                   // databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);
                    break;
                case MenuTableName.Gebruikers:
                    databaseTableName = "Gevaar_Gebruiker";
                    databaseColumnName = "GebruikerID";
                   // databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);
                    break;
                case MenuTableName.Disciplines:
                    databaseTableName = "Gevaar_Discipline";
                    databaseColumnName = "DisciplineID";
                   // databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);
                    break;
                case MenuTableName.Bedienvormen:
                    databaseTableName = "Gevaar_Bedienvorm";
                    databaseColumnName = "BedienvormID";
                    //databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);
                    break;
                case MenuTableName.Taken:
                    databaseTableName = "Gevaar_Taak";
                    databaseColumnName = "TaakID";
                    //databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);
                    break;
                case MenuTableName.Normen:
                    //databaseCommunication.AddToNormenMenu(inputText);
                    break;
                case MenuTableName.Categories:
                    //databaseCommunication.AddToCategoriesMenu(inputText);
                    break;
                case MenuTableName.TemplateTypes:
                    //databaseCommunication.AddToTemplateTypes(inputText);
                    break;
                case MenuTableName.TemplateToepassing:
                    //databaseCommunication.AddToTemplateToepassingen(inputText);
                    break;
                default:
                    break;
            }

            databaseCommunication.DeleteUsage(databaseTableName, databaseColumnName, optionID);

        }
















        public void DeleteFromMenu(MenuTableName menuTableName, string optionToDelete)
        {
            DeleteMenuOptionFromDB(menuTableName, optionToDelete);
        }

        private void DeleteMenuOptionFromDB(MenuTableName menuTableName, string inputText)
        {
            string databaseTableName = "";
            string databaseColumnName = "";

            switch (menuTableName)
            {
                case MenuTableName.ObjectTypes:
                    databaseTableName = "ObjectTypes";
                    databaseColumnName = "ObjectType";
                    break;
                case MenuTableName.Gevolgen:
                    databaseTableName = "Gevolgen";
                    databaseColumnName = "Gevolg";
                    break;
                case MenuTableName.Gevarenzones:
                    databaseTableName = "Gevarenzones";
                    databaseColumnName = "Gevarenzone";
                    break;
                case MenuTableName.GevaarTypes:
                    databaseTableName = "GevaarTypes";
                    databaseColumnName = "GevaarType";
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseTableName = "Gebruiksfases";
                    databaseColumnName = "Gebruiksfase";
                    break;
                case MenuTableName.Gebruikers:
                    databaseTableName = "Gebruikers";
                    databaseColumnName = "Gebruiker";
                    break;
                case MenuTableName.Disciplines:
                    databaseTableName = "Disciplines";
                    databaseColumnName = "Discipline";
                    break;
                case MenuTableName.Bedienvormen:
                    databaseTableName = "Bedienvormen";
                    databaseColumnName = "Bedienvorm";
                    break;
                case MenuTableName.Taken:
                    databaseTableName = "Taken";
                    databaseColumnName = "Taak";
                    break;
                case MenuTableName.Normen:
                    //databaseCommunication.AddToNormenMenu(inputText);
                    break;
                case MenuTableName.Categories:
                    //databaseCommunication.AddToCategoriesMenu(inputText);
                    break;
                case MenuTableName.TemplateTypes:
                    //databaseCommunication.AddToTemplateTypes(inputText);
                    break;
                case MenuTableName.TemplateToepassing:
                    //databaseCommunication.AddToTemplateToepassingen(inputText);
                    break;
                default:
                    break;
            }
            databaseCommunication.DeleteFromMenu(databaseTableName, databaseColumnName, inputText);
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



        public void EditToMenu(MenuTableName menuTableName, int itemIndex, string optionToAdd)
        {
            SendEditMenuOptionToDB(menuTableName, itemIndex, optionToAdd);
        }

        private void SendEditMenuOptionToDB(MenuTableName menuTableName, int itemIndex, string inputText)
        {
            string databaseTableName = "";
            string databaseColumnName = "";
            string databaseIDColumnName = "";

            switch (menuTableName)
            {
                case MenuTableName.ObjectTypes:
                    databaseTableName = "ObjectTypes";
                    databaseColumnName = "ObjectType";
                    databaseIDColumnName = "ObjectTypeID";
                    break;
                case MenuTableName.Gevolgen:
                    databaseTableName = "Gevolgen";
                    databaseColumnName = "Gevolg";
                    databaseIDColumnName = "GevolgID";
                    break;
                case MenuTableName.Gevarenzones:
                    databaseTableName = "Gevarenzones";
                    databaseColumnName = "Gevarenzone";
                    databaseIDColumnName = "GevarenzoneID";
                    break;
                case MenuTableName.GevaarTypes:
                    databaseTableName = "GevaarTypes";
                    databaseColumnName = "GevaarType";
                    databaseIDColumnName = "GevaarTypeID";
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseTableName = "Gebruiksfases";
                    databaseColumnName = "Gebruiksfase";
                    databaseIDColumnName = "GebruiksfaseID";
                    break;
                case MenuTableName.Gebruikers:
                    databaseTableName = "Gebruikers";
                    databaseColumnName = "Gebruiker";
                    databaseIDColumnName = "GebruikerID";
                    break;
                case MenuTableName.Disciplines:
                    databaseTableName = "Disciplines";
                    databaseColumnName = "Discipline";
                    databaseIDColumnName = "DisciplineID";
                    break;
                case MenuTableName.Bedienvormen:
                    databaseTableName = "Bedienvormen";
                    databaseColumnName = "Bedienvorm";
                    databaseIDColumnName = "BedienvormID";
                    break;
                case MenuTableName.Taken:
                    databaseTableName = "Taken";
                    databaseColumnName = "Taak";
                    databaseIDColumnName = "TaakID";
                    break;
                case MenuTableName.Normen:
                    databaseTableName = "Normen";
                    databaseColumnName = "Norm";
                    databaseIDColumnName = "NormID";
                    break;
                case MenuTableName.Categories:
                    databaseTableName = "Categories";
                    databaseColumnName = "Category";
                    databaseIDColumnName = "CategoryID";
                    break;
                case MenuTableName.TemplateTypes:
                    databaseTableName = "TemplateTypes";
                    databaseColumnName = "TemplateType";
                    databaseIDColumnName = "TemplateTypeID";
                    break;
                case MenuTableName.TemplateToepassing:
                    databaseTableName = "TemplateToepassingen";
                    databaseColumnName = "TemplateToepassing";
                    databaseIDColumnName = "TemplateToepassingID";
                    break;
                default:
                    break;
            }

            databaseCommunication.EditFromMenu(databaseTableName, databaseColumnName, databaseIDColumnName, itemIndex,  inputText);

        }





        private void SendItemToDB(Item item)
        {
            switch (item.ItemType)
            {
                case ItemType.Gevaar:
                    //databaseCommunication.MakeGevaar(item);
                    break;
                case ItemType.Maatregel:
                    //databaseCommunication.MakeMaatregel(item);
                    break;
                case ItemType.Issue:

                    break;
                case ItemType.Template:
                    databaseCommunication.MakeTemplate(item);
                    break;
                case ItemType.Object:
                    //databaseCommunication.MakeObject(item);
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
