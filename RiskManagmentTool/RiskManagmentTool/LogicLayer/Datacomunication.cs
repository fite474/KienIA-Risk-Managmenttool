using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RiskManagmentTool.DataLayer;
using RiskManagmentTool.LogicLayer.Objects;
using RiskManagmentTool.LogicLayer.Objects.Core;
using System.Windows.Forms;
using System.Drawing;

namespace RiskManagmentTool.LogicLayer
{
    class Datacomunication
    {
        private DatabaseCommunication databaseCommunication;
        public Datacomunication()
        {
            databaseCommunication = new DatabaseCommunication();
        }


        #region version1


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
            databaseCommunication.MakeProject(projectItem);

        }

        public int MakeObject(string projectId, string projectNaam, string objectNaam, string objectType, string objectOmschrijving, int risicograafSetting)
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
            int objectID = databaseCommunication.MakeObject(objectItem);
            databaseCommunication.SetObjectSettings(objectID, risicograafSetting);
            databaseCommunication.InitObjectNotes(objectID);
            return objectID;
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
                    databaseCommunication.AddGevaar_Disciplines(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.AddGevaar_Disciplines(gevaarID, null); }


            if (GevaarGebruiksfase.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGebruiksfase)
                {
                    databaseCommunication.AddGevaar_Gebruiksfase(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.AddGevaar_Gebruiksfase(gevaarID, null); }


            if (GevaarBedienvorm.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarBedienvorm)
                {
                    databaseCommunication.AddGevaar_Bedienvorm(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.AddGevaar_Bedienvorm(gevaarID, null); }


            if (GevaarGebruiker.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGebruiker)
                {
                    databaseCommunication.AddGevaar_Gebruiker(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.AddGevaar_Gebruiker(gevaarID, null); }


            if (GevaarGevaarlijkeZone.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevaarlijkeZone)
                {
                    databaseCommunication.AddGevaar_GevaarlijkeZone(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.AddGevaar_GevaarlijkeZone(gevaarID, null); }


            if (GevaarTaak.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarTaak)
                {
                    databaseCommunication.AddGevaar_Taak(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.AddGevaar_Taak(gevaarID, null); }


            if (GevaarGevaarType.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevaarType)
                {
                    databaseCommunication.AddGevaar_GevaarType(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.AddGevaar_GevaarType(gevaarID, null); }


            if (GevaarGevolg.Count > 0)
            {
                foreach (KeyValuePair<int, int> kvp in GevaarGevolg)
                {
                    databaseCommunication.AddGevaar_Gevolg(gevaarID, kvp.Value);
                }
            }
            else
            { databaseCommunication.AddGevaar_Gevolg(gevaarID, null); }
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


        #endregion Init


        #region Update

        public void UpdateObjectNotes(string objectID, string text)
        {
            databaseCommunication.UpdateObjectNotes(objectID, text);

        }

        public void UpdateGevaarSituatie(int gevaarID, string text)
        {
            databaseCommunication.UpdateGevaarSituatie(gevaarID, text);
        }

        public void UpdateGevaarGebeurtenis(int gevaarID, string text)
        {
            databaseCommunication.UpdateGevaarGebeurtenis(gevaarID, text);
        }

        public void UpdateGevaarDataAdd(int gevaarId, MenuTableName menuTableName, int indexToAdd)
        {
            switch (menuTableName)
            {
                case MenuTableName.Gevolgen:
                    databaseCommunication.AddGevaar_Gevolg(gevaarId, indexToAdd); ;
                    break;
                case MenuTableName.Gevarenzones:
                    databaseCommunication.AddGevaar_GevaarlijkeZone(gevaarId, indexToAdd);
                    break;
                case MenuTableName.GevaarTypes:
                    databaseCommunication.AddGevaar_GevaarType(gevaarId, indexToAdd);
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseCommunication.AddGevaar_Gebruiksfase(gevaarId, indexToAdd);
                    break;
                case MenuTableName.Gebruikers:
                    databaseCommunication.AddGevaar_Gebruiker(gevaarId, indexToAdd);
                    break;
                case MenuTableName.Disciplines:
                    databaseCommunication.AddGevaar_Disciplines(gevaarId, indexToAdd);
                    break;
                case MenuTableName.Bedienvormen:
                    databaseCommunication.AddGevaar_Bedienvorm(gevaarId, indexToAdd);
                    break;
                case MenuTableName.Taken:
                    databaseCommunication.AddGevaar_Taak(gevaarId, indexToAdd);
                    break;

            }

        }

        public void UpdateGevaarDataDelete(int gevaarId, MenuTableName menuTableName, int indexToRemove)
        {
            switch (menuTableName)
            {
                case MenuTableName.Gevolgen:
                    databaseCommunication.RemoveGevaar_Gevolg(gevaarId, indexToRemove);
                    break;
                case MenuTableName.Gevarenzones:
                    databaseCommunication.RemoveGevaar_GevaarlijkeZone(gevaarId, indexToRemove);
                    break;
                case MenuTableName.GevaarTypes:
                    databaseCommunication.RemoveGevaar_GevaarType(gevaarId, indexToRemove);
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseCommunication.RemoveGevaar_Gebruiksfases(gevaarId, indexToRemove);
                    break;
                case MenuTableName.Gebruikers:
                    databaseCommunication.RemoveGevaar_Gebruiker(gevaarId, indexToRemove);
                    break;
                case MenuTableName.Disciplines:
                    databaseCommunication.RemoveGevaar_Disciplines(gevaarId, indexToRemove);
                    break;
                case MenuTableName.Bedienvormen:
                    databaseCommunication.RemoveGevaar_Bedienvorm(gevaarId, indexToRemove);
                    break;
                case MenuTableName.Taken:
                    databaseCommunication.RemoveGevaar_Taak(gevaarId, indexToRemove);
                    break;

            }

        }

        public void UpdateGevaarDataInsertNull(int gevaarId, MenuTableName menuTableName)
        {
            switch (menuTableName)
            {
                case MenuTableName.Gevolgen:
                    databaseCommunication.VerwijderGevaar_Gevolg(gevaarId);
                    databaseCommunication.AddGevaar_Gevolg(gevaarId, null); ;
                    break;
                case MenuTableName.Gevarenzones:
                    databaseCommunication.VerwijderGevaar_GevaarlijkeZone(gevaarId);
                    databaseCommunication.AddGevaar_GevaarlijkeZone(gevaarId, null);
                    break;
                case MenuTableName.GevaarTypes:
                    databaseCommunication.VerwijderGevaar_GevaarType(gevaarId);
                    databaseCommunication.AddGevaar_GevaarType(gevaarId, null); ;
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseCommunication.VerwijderGevaar_Gebruiksfases(gevaarId);
                    databaseCommunication.AddGevaar_Gebruiksfase(gevaarId, null);
                    break;
                case MenuTableName.Gebruikers:
                    databaseCommunication.VerwijderGevaar_Gebruiker(gevaarId);
                    databaseCommunication.AddGevaar_Gebruiker(gevaarId, null);
                    break;
                case MenuTableName.Disciplines:
                    databaseCommunication.VerwijderGevaar_Disciplines(gevaarId);
                    databaseCommunication.AddGevaar_Disciplines(gevaarId, null);
                    break;
                case MenuTableName.Bedienvormen:
                    databaseCommunication.VerwijderGevaar_Bedienvorm(gevaarId);
                    databaseCommunication.AddGevaar_Bedienvorm(gevaarId, null);
                    break;
                case MenuTableName.Taken:
                    databaseCommunication.VerwijderGevaar_Taak(gevaarId);
                    databaseCommunication.AddGevaar_Taak(gevaarId, null);
                    break;

            }
        }

        public void UpdateGevaarDataRemoveNull(int gevaarId, MenuTableName menuTableName)
        {
            switch (menuTableName)
            {
                case MenuTableName.Gevolgen:
                    databaseCommunication.VerwijderGevaar_Gevolg(gevaarId);
                    break;
                case MenuTableName.Gevarenzones:
                    databaseCommunication.VerwijderGevaar_GevaarlijkeZone(gevaarId);
                    break;
                case MenuTableName.GevaarTypes:
                    databaseCommunication.VerwijderGevaar_GevaarType(gevaarId);
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseCommunication.VerwijderGevaar_Gebruiksfases(gevaarId);
                    break;
                case MenuTableName.Gebruikers:
                    databaseCommunication.VerwijderGevaar_Gebruiker(gevaarId);
                    break;
                case MenuTableName.Disciplines:
                    databaseCommunication.VerwijderGevaar_Disciplines(gevaarId);
                    break;
                case MenuTableName.Bedienvormen:
                    databaseCommunication.VerwijderGevaar_Bedienvorm(gevaarId);
                    break;
                case MenuTableName.Taken:
                    databaseCommunication.VerwijderGevaar_Taak(gevaarId);
                    break;

            }
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

        public void UpdateRisicoBeoordelingWithoutComments(string issueID, string init_Se, string init_Fr, string init_Pr, string init_Av, string init_Cl, string init_Risico,
                                            //string init_Se_Comment, string init_Fr_Comment, string init_Pr_Comment, string init_Av_Comment, string init_Cl_Comment, string init_Risico_Comment,
                                            string rest_Se, string rest_Fr, string rest_Pr, string rest_Av, string rest_Cl, string rest_Risico,
                                            //string rest_Se_Comment, string rest_Fr_Comment, string rest_Pr_Comment, string rest_Av_Comment, string rest_Cl_Comment, string rest_Risico_Comment
                                            string rest_Ok)
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
                    //Init_Se_Comment = init_Se_Comment,
                    //Init_Fr_Comment = init_Fr_Comment,
                    //Init_Pr_Comment = init_Pr_Comment,
                    //Init_Av_Comment = init_Av_Comment,
                    //Init_Cl_Comment = init_Cl_Comment,
                    //Init_Risico_Comment = init_Risico_Comment,

                    Rest_Se = rest_Se,
                    Rest_Fr = rest_Fr,
                    Rest_Pr = rest_Pr,
                    Rest_Av = rest_Av,
                    Rest_Cl = rest_Cl,
                    Rest_Risico = rest_Risico,
                    //Rest_Se_Comment = rest_Se_Comment,
                    //Rest_Fr_Comment = rest_Fr_Comment,
                    //Rest_Pr_Comment = rest_Pr_Comment,
                    //Rest_Av_Comment = rest_Av_Comment,
                    //Rest_Cl_Comment = rest_Cl_Comment,
                    //Rest_Risico_Comment = rest_Risico_Comment,
                    Rest_Ok = rest_Ok
                }
            };
            databaseCommunication.UpdateRisicoBeoordelingWithoutComments(risicoInschattingItem);


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
            databaseCommunication.UpdateRisicoBeoordeling(risicoInschattingItem);


        }

        public void UpdateIssueState(string issueId, int newState)
        {
            databaseCommunication.UpdateIssueState(issueId, newState);
        }

        public void UpdateIssueOk(string issueId, int newState)
        {
            databaseCommunication.UpdateIssueOk(issueId, newState);
        }

        public void UpdateImageToObject(string objectID, string imageFilePath)
        {
            databaseCommunication.UpdateImageToObject(objectID, imageFilePath);
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
        

        public void AddIssueToObject(string objectId, string issueId, bool addMaatregelen, bool addBeoordeling)//, bool issueNeedsToVerify)
        {
            //string issueState = "-1";
            //if (issueNeedsToVerify)
            //{
            //    issueState = "0";// 0 is nog niet goedgekeurd
            //}
            //else
            //{
            //    issueState = "1"; // 1 betekent goedgekeurd
            //}

            string issueState = "0";// 0 is nog niet goedgekeurd

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

        public string GetObjectNotes(string objectID)
        {
            return databaseCommunication.GetObjectNotes(objectID);
        }

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


        public BindingSource GetExportView(string objectID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetExportView(objectID);
            DataTable data = new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
        }

        public BindingSource GetExportViewRWSTemplate(string objectID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetExportViewRWSTemplate(objectID);
            DataTable data = new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
        }

        public BindingSource GetObjectIssues(string objectID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetIssuesFromObject(objectID);
            DataTable data = new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
        }

        public BindingSource GetObjectMaatregels(string objectID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetMaatregelsFromObject(objectID);
            DataTable data = new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
        }

        public BindingSource GetObjectIssuesByObjectName(string objectNaam)
        {
            string objectId = databaseCommunication.GetObjectIdByName(objectNaam);
            SqlDataAdapter adapter = databaseCommunication.GetIssuesFromObject(objectId);
            DataTable data = new DataTable();//GetObjectIssues(objectId);//new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
            //return data;
        }


        public DataTable GetSelectedObjectIssues(string objectNaam, List<string> selectedIssuesId)
        {
            string objectId = databaseCommunication.GetObjectIdByName(objectNaam);
            SqlDataAdapter adapter = databaseCommunication.GetSelectedIssuesFromObject(objectId, selectedIssuesId);
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

        public BindingSource GetGlobalGevarenTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetGlobalGevaren();
            DataTable data = new DataTable();
            adapter.Fill(data);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
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

        //public DataTable GetTemplateGevaren(string templateID)
        //{
        //    SqlDataAdapter adapter = databaseCommunication.GetTemplateGevaren(templateID);
        //    DataTable data = new DataTable();
        //    adapter.Fill(data);
        //    return data;
        //}

        public BindingSource GetTemplateIssues(string templateID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetTemplateIssues(templateID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = data;
            return bindingSource;
        }

        #endregion get tables

        #region get info

        public List<string> GetObjectSettings(string ObjectID)
        {
            return databaseCommunication.GetObjectSettings(ObjectID);
        }

        public Image GetObjectImage(string objectID)
        {
            Image image = databaseCommunication.GetObjectImage(objectID);
            return image;
        }

        public Image GetIssueImage(string issueID)
        {
            Image image = databaseCommunication.GetIssueImage(issueID);
            return image;
        }

        #endregion get info

        #endregion GET REQUEST FROM DATABASE

        #region delete

        public void DeleteGekoppeldeMaatregelenVanIssue(string issueId, string maatregelID)
        {
            databaseCommunication.VerwijderGekoppeldeMaatregelVanIssue(issueId, maatregelID);
        }
        public void DeleteIssueFromObject(string objectId, string issueId)
        {
            databaseCommunication.VerwijderIssuesVanObject(objectId, issueId);
            databaseCommunication.VerwijderMaatregelenVanIssue(issueId);
            databaseCommunication.VerwijderRisicoBeoordelingVanIssue(issueId);
            databaseCommunication.VerwijderIssue(issueId);
        }


        public void DeleteGevaar(string gevaarID)
        {
            int gevaarIDInt = int.Parse(gevaarID);
            databaseCommunication.VerwijderGevaarMulti(gevaarIDInt);
            databaseCommunication.VerwijderGevaar_Disciplines(gevaarIDInt);
            databaseCommunication.VerwijderGevaar_Gebruiksfases(gevaarIDInt);
            databaseCommunication.VerwijderGevaar_Bedienvorm(gevaarIDInt);
            databaseCommunication.VerwijderGevaar_Gebruiker(gevaarIDInt);
            databaseCommunication.VerwijderGevaar_GevaarlijkeZone(gevaarIDInt);
            databaseCommunication.VerwijderGevaar_Taak(gevaarIDInt);
            databaseCommunication.VerwijderGevaar_GevaarType(gevaarIDInt);
            databaseCommunication.VerwijderGevaar_Gevolg(gevaarIDInt);
        }

        public void DeleteMaatregel(string maatregelID)
        {
            int maatregelIDInt = int.Parse(maatregelID);
            databaseCommunication.VerwijderMaatregelMulti(maatregelIDInt);
            databaseCommunication.VerwijderMaatregel_Category(maatregelIDInt);
            databaseCommunication.VerwijderMaatregel_Norm(maatregelIDInt);
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


        public List<string> GetGekoppeldeGevarenOriginFromObjectAsList(string objectId)
        {
            return databaseCommunication.GetGekoppeldeGevarenOriginFromObjectAsList(objectId);
        }


        //old
        public List<string> GetGekoppeldeGevarenFromObjectAsList(string objectId)
        {
            return databaseCommunication.GetGekoppeldeGevarenFromObjectAsList(objectId);
        }

        

        public List<string> GetGevarenOriginFromIssuesAsList(List<string> selectedIssuesId)
        {
            return databaseCommunication.GetGevarenOriginFromIssuesAsList(selectedIssuesId);
        }


        //old
        public List<string> GetGevarenFromIssuesAsList(List<string> selectedIssuesId)
        {
            return databaseCommunication.GetGevarenFromIssuesAsList(selectedIssuesId);
        }

        public List<string> GetMaatregelenFromIssuesAsList(string issueID)
        {
            return databaseCommunication.GetMaatregelenFromIssues(issueID);
        }




        #region redirect options

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
        }
        public string GetObjectNameById(string objectId)
        {
            return databaseCommunication.GetObjectNameById(objectId);
        }


        public string GetIssueIdByObjectAndGevaarOriginId(string objectId, string gevaarId)
        {
            return databaseCommunication.GetIssueIdByObjectAndGevaarOriginId(objectId, gevaarId);
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

        public string GetIssueOK(string issueId)
        {
            return databaseCommunication.GetIssueOK(issueId);
        }

        public string GetLastTemplateID()
        {
            return databaseCommunication.GetLastTemplateID();
        }

        #endregion redirect options




        #region Get usage

        public DataTable GetGevarenUsage(string gevaarID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetGevarenUsage(gevaarID);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;

        }
        public DataTable GetMaatregelenUsage(string maatregelID)
        {
            SqlDataAdapter adapter = databaseCommunication.GetMaatregelenUsage(maatregelID);
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




        #region get gevaar menus

        public Dictionary<int, string> GetGevolgen(string objectId)
        {
            return databaseCommunication.GetGevolgen(objectId);
        }


        public Dictionary<int, string> GetGevarenzones(string objectId)
        {
            return databaseCommunication.GetGevarenzones(objectId);
        }

        public Dictionary<int, string> GetGevaarTypes(string objectId)
        {
            return databaseCommunication.GetGevaarTypes(objectId);
        }

        public Dictionary<int, string> GetGebruiksfases(string objectId)
        {
            return databaseCommunication.GetGebruiksfases(objectId);
        }

        public Dictionary<int, string> GetGebruikers(string objectId)
        {
            return databaseCommunication.GetGebruikers(objectId);
        }

        public Dictionary<int, string> GetDisciplines(string objectId)
        {
            return databaseCommunication.GetDisciplines(objectId);
        }

        public Dictionary<int, string> GetBedienvormen(string objectId)
        {
            return databaseCommunication.GetBedienvormen(objectId);
        }

        public Dictionary<int, string> GetTaken(string objectId)
        {
            return databaseCommunication.GetTaken(objectId);
        }


        #endregion get gevaar menus



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
        public Dictionary<string, string> GetObjectIssuesRestRiskOK(string objectID)
        {
            return databaseCommunication.GetObjectIssuesRestRiskOK(objectID);
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
                    break;
                case MenuTableName.Gevarenzones:

                    databaseTableName = "Gevaar_GevaarlijkeZone";
                    databaseColumnName = "GevaarlijkeZoneID";
                    break;
                case MenuTableName.GevaarTypes:
                    databaseTableName = "Gevaar_GevaarType";
                    databaseColumnName = "GevaarTypeID";
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseTableName = "Gevaar_Gebruiksfase";
                    databaseColumnName = "GebruiksfaseID";
                    break;
                case MenuTableName.Gebruikers:
                    databaseTableName = "Gevaar_Gebruiker";
                    databaseColumnName = "GebruikerID";
                    break;
                case MenuTableName.Disciplines:
                    databaseTableName = "Gevaar_Discipline";
                    databaseColumnName = "DisciplineID";
                    break;
                case MenuTableName.Bedienvormen:
                    databaseTableName = "Gevaar_Bedienvorm";
                    databaseColumnName = "BedienvormID";
                    break;
                case MenuTableName.Taken:
                    databaseTableName = "Gevaar_Taak";
                    databaseColumnName = "TaakID";
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


        public void AddToMenu(MenuTableName menuTableName, string optionToAdd, string objectId)
        {
            SendMenuOptionToDB(menuTableName, optionToAdd, objectId);
        }


        //re-writen for object specifics. update early 2023
        private void SendMenuOptionToDB(MenuTableName menuTableName, string inputText, string objectId)
        {
            switch (menuTableName)
            {
                case MenuTableName.ObjectTypes:
                    databaseCommunication.AddToObjectTypesMenu(inputText);
                    break;
                case MenuTableName.Gevolgen:
                    databaseCommunication.AddToGevolgenMenu(inputText, objectId);
                    break;
                case MenuTableName.Gevarenzones:
                    databaseCommunication.AddToGevarenzonesMenu(inputText, objectId);
                    break;
                case MenuTableName.GevaarTypes:
                    databaseCommunication.AddToGevaarTypesMenu(inputText, objectId);
                    break;
                case MenuTableName.Gebruiksfases:
                    databaseCommunication.AddToGebruiksfasesMenu(inputText, objectId);
                    break;
                case MenuTableName.Gebruikers:
                    databaseCommunication.AddToGebruikersMenu(inputText, objectId);
                    break;
                case MenuTableName.Disciplines:
                    databaseCommunication.AddToDisciplinesMenu(inputText, objectId);
                    break;
                case MenuTableName.Bedienvormen:
                    databaseCommunication.AddToBedienvormenMenu(inputText, objectId);
                    break;
                case MenuTableName.Taken:
                    databaseCommunication.AddToTakenMenu(inputText, objectId);
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


        #endregion version1


    }
}
