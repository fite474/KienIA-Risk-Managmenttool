using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using RiskManagmentTool.LogicLayer.Objects.Core;

namespace RiskManagmentTool.DataLayer
{
    class DatabaseCommunication
    {
        SqlConnection sqlConnection;
        public DatabaseCommunication()
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            sqlConnection = databaseConnection.sqlConnection;
            // new SqlConnection(databaseConnection.GetConnectionString());


        }

        #region Init

        public void MakeProject(Item item)
        {
            string projectNaam = item.ItemData.ProjectNaam;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableProjecten(ProjectNaam) VALUES " +
                                                                       "(@ProjectNaam)", sqlConnection);
            cmd.Parameters.AddWithValue("@ProjectNaam", projectNaam);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public int MakeObject(Item item)
        {
            string projectId = item.ItemData.ProjectId;
            string projectNaam = item.ItemData.ProjectNaam;
            string objectNaam = item.ItemData.ObjectNaam;
            string objectType = item.ItemData.ObjectType;
            string objectOmschrijving = item.ItemData.ObjectOmschrijving;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjecten(ProjectID, ProjectNaam, ObjectNaam, ObjectType, ObjectOmschrijving) VALUES " +
                                                                       "(@ProjectID, @ProjectNaam, @ObjectNaam, @ObjectType, @ObjectOmschrijving)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@ProjectID", projectId);
            cmd.Parameters.AddWithValue("@ProjectNaam", projectNaam);
            cmd.Parameters.AddWithValue("@ObjectNaam", objectNaam);
            cmd.Parameters.AddWithValue("@ObjectType", objectType);
            cmd.Parameters.AddWithValue("@ObjectOmschrijving", objectOmschrijving);

            Int32 objectID = (Int32)cmd.ExecuteScalar();
            //cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return objectID;
        }


        public int InitMakeGevaar(string gevaarlijkeSituatie, string gevaarlijkeGebeurtenis)
        {

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableGevaarMulti(GevaarlijkeSituatie, GevaarlijkeGebeurtenis) VALUES " +
                                                                       "(@GevaarlijkeSituatie, @GevaarlijkeGebeurtenis)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarlijkeSituatie", gevaarlijkeSituatie);
            cmd.Parameters.AddWithValue("@GevaarlijkeGebeurtenis", gevaarlijkeGebeurtenis);

            Int32 gevaarID = (Int32)cmd.ExecuteScalar();

            sqlConnection.Close();
            return gevaarID;
        }


        public int InitMaatregel(string maatregelNaam)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableMaatregelenMulti(MaatregelNaam) VALUES " +
                                                                       "(@MaatregelNaam)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@MaatregelNaam", maatregelNaam);

            Int32 maatregelID = (Int32)cmd.ExecuteScalar();

            sqlConnection.Close();
            return maatregelID;
        }

        public void MakeTemplate(Item item)
        {

            string templateNaam = item.ItemData.TemplateNaam;
            string templateType = item.ItemData.TemplateType;
            string templateToepassing = item.ItemData.TemplateToepassing;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableTemplates(TemplateNaam, TemplateType, TemplateToepassing) VALUES " +
                                                                       "(@TemplateNaam, @TemplateType, @TemplateToepassing)", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateNaam", templateNaam);
            cmd.Parameters.AddWithValue("@TemplateType", templateType);
            cmd.Parameters.AddWithValue("@TemplateToepassing", templateToepassing);


            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private int InitIssue(string gevaarId, string issueState)
        {
            //string issueStatus = "0";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableIssues(IssueGevaarID, IssueStatus) VALUES " +
                                                                       "(@IssueGevaarID, @IssueStatus)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@IssueGevaarID", gevaarId);
            cmd.Parameters.AddWithValue("@IssueStatus", issueState);

            Int32 issueID = (Int32)cmd.ExecuteScalar();
            sqlConnection.Close();
            return issueID;
        }

        public int InitRisicoBeoordeling(int issueId)
        {
            int emptyIntFields = 0;
            string emptyStringFields = "";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RisicoBeoordeling(IssueID, Init_Se, Init_Fr, Init_Pr, Init_Av, Init_Cl, Init_Risico, Init_Se_Comment, Init_Fr_Comment, Init_Pr_Comment, Init_Av_Comment, Init_Cl_Comment, Init_Risico_Comment, " +
                                                                          "Rest_Se, Rest_Fr, Rest_Pr, Rest_Av, Rest_Cl, Rest_Risico, Rest_Se_Comment, Rest_Fr_Comment, Rest_Pr_Comment, Rest_Av_Comment, Rest_Cl_Comment, Rest_Risico_Comment, Rest_Risico_Ok) " +
                                                                          " VALUES " +
                                                                          "(@IssueID, @Init_Se, @Init_Fr, @Init_Pr, @Init_Av, @Init_Cl, @Init_Risico, @Init_Se_Comment, @Init_Fr_Comment, @Init_Pr_Comment, @Init_Av_Comment, @Init_Cl_Comment, @Init_Risico_Comment, " +
                                                                          "@Rest_Se, @Rest_Fr, @Rest_Pr, @Rest_Av, @Rest_Cl, @Rest_Risico, @Rest_Se_Comment, @Rest_Fr_Comment, @Rest_Pr_Comment, @Rest_Av_Comment, @Rest_Cl_Comment, @Rest_Risico_Comment, @Rest_Risico_Ok)" +
                                                                          "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);


            cmd.Parameters.AddWithValue("@IssueID", issueId);
            cmd.Parameters.AddWithValue("@Init_Se", emptyIntFields);
            cmd.Parameters.AddWithValue("@Init_Fr", emptyIntFields);
            cmd.Parameters.AddWithValue("@Init_Pr", emptyIntFields);
            cmd.Parameters.AddWithValue("@Init_Av", emptyIntFields);
            cmd.Parameters.AddWithValue("@Init_Cl", emptyIntFields);
            cmd.Parameters.AddWithValue("@Init_Risico", emptyIntFields);
            cmd.Parameters.AddWithValue("@Init_Se_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Init_Fr_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Init_Pr_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Init_Av_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Init_Cl_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Init_Risico_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Rest_Se", emptyIntFields);
            cmd.Parameters.AddWithValue("@Rest_Fr", emptyIntFields);
            cmd.Parameters.AddWithValue("@Rest_Pr", emptyIntFields);
            cmd.Parameters.AddWithValue("@Rest_Av", emptyIntFields);
            cmd.Parameters.AddWithValue("@Rest_Cl", emptyIntFields);
            cmd.Parameters.AddWithValue("@Rest_Risico", emptyIntFields);
            cmd.Parameters.AddWithValue("@Rest_Se_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Rest_Fr_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Rest_Pr_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Rest_Av_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Rest_Cl_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Rest_Risico_Comment", emptyStringFields);
            cmd.Parameters.AddWithValue("@Rest_Risico_Ok", emptyIntFields);

            Int32 risicoBeoordelingID = (Int32)cmd.ExecuteScalar();
            sqlConnection.Close();
            return risicoBeoordelingID;
        }

        public int InitRisicoBeoordelingDuplicate(int issueId, string originalIssueID)
        {

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RisicoBeoordeling(IssueID, Init_Se, Init_Fr, Init_Pr, Init_Av, Init_Cl, Init_Risico, Init_Se_Comment, Init_Fr_Comment, Init_Pr_Comment, Init_Av_Comment, Init_Cl_Comment, Init_Risico_Comment," +
                                                                          " Rest_Se, Rest_Fr, Rest_Pr, Rest_Av, Rest_Cl, Rest_Risico, Rest_Se_Comment, Rest_Fr_Comment, Rest_Pr_Comment, Rest_Av_Comment, Rest_Cl_Comment, Rest_Risico_Comment, Rest_Risico_Ok)" +
                                                                          " SELECT '" + issueId + "', Init_Se, Init_Fr, Init_Pr, Init_Av, Init_Cl, Init_Risico, Init_Se_Comment, Init_Fr_Comment, Init_Pr_Comment, Init_Av_Comment, Init_Cl_Comment, Init_Risico_Comment," +
                                                                          " Rest_Se, Rest_Fr, Rest_Pr, Rest_Av, Rest_Cl, Rest_Risico, Rest_Se_Comment, Rest_Fr_Comment, Rest_Pr_Comment, Rest_Av_Comment, Rest_Cl_Comment, Rest_Risico_Comment, Rest_Risico_Ok " +
                                                                          " FROM RisicoBeoordeling " +
                                                                          " WHERE IssueID = '" + originalIssueID + "'" +
                                                                          "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);


            //cmd.Parameters.AddWithValue("@IssueID", issueId);


            Int32 risicoBeoordelingID = (Int32)cmd.ExecuteScalar();
            sqlConnection.Close();
            return risicoBeoordelingID;
        }

        #endregion Init


        #region gevaar details

        public void MakeGevaar_Disciplines(int gevaarID, int? disciplineID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Discipline(GevaarID, DisciplineID) VALUES " +
                                                                       "(@GevaarID, @DisciplineID)", sqlConnection); 
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            if (disciplineID == null)
            {
                cmd.Parameters.AddWithValue("@DisciplineID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@DisciplineID", disciplineID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Gebruiksfase(int gevaarID, int? gebruiksfaseID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Gebruiksfase(GevaarID, GebruiksfaseID) VALUES " +
                                                                       "(@GevaarID, @GebruiksfaseID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            if (gebruiksfaseID == null)
            {
                cmd.Parameters.AddWithValue("@GebruiksfaseID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@GebruiksfaseID", gebruiksfaseID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Bedienvorm(int gevaarID, int? bedienvormID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Bedienvorm(GevaarID, BedienvormID) VALUES " +
                                                                       "(@GevaarID, @BedienvormID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            if (bedienvormID == null)
            {
                cmd.Parameters.AddWithValue("@BedienvormID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@BedienvormID", bedienvormID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Gebruiker(int gevaarID, int? gebruikerID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Gebruiker(GevaarID, GebruikerID) VALUES " +
                                                                       "(@GevaarID, @GebruikerID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            if (gebruikerID == null)
            {
                cmd.Parameters.AddWithValue("@GebruikerID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@GebruikerID", gebruikerID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_GevaarlijkeZone(int gevaarID, int? gevaarlijkeZoneID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_GevaarlijkeZone(GevaarID, GevaarlijkeZoneID) VALUES " +
                                                                       "(@GevaarID, @GevaarlijkeZoneID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            if (gevaarlijkeZoneID == null)
            {
                cmd.Parameters.AddWithValue("@GevaarlijkeZoneID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@GevaarlijkeZoneID", gevaarlijkeZoneID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Taak(int gevaarID, int? taakID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Taak(GevaarID, TaakID) VALUES " +
                                                                       "(@GevaarID, @TaakID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            if (taakID == null)
            {
                cmd.Parameters.AddWithValue("@TaakID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@TaakID", taakID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_GevaarType(int gevaarID, int? gevaarTypeID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_GevaarType(GevaarID, GevaarTypeID) VALUES " +
                                                                       "(@GevaarID, @GevaarTypeID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            if (gevaarTypeID == null)
            {
                cmd.Parameters.AddWithValue("@GevaarTypeID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@GevaarTypeID", gevaarTypeID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Gevolg(int gevaarID, int? gevolgID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Gevolg(GevaarID, GevolgID) VALUES " +
                                                                       "(@GevaarID, @GevolgID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            if (gevolgID == null)
            {
                cmd.Parameters.AddWithValue("@GevolgID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@GevolgID", gevolgID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        #endregion gevaar details

        #region maatregel details
        public void MakeMaatregel_Norm(int maatregelID, int? normID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Maatregel_Norm(MaatregelID, NormID) VALUES " +
                                                                       "(@MaatregelID, @NormID)", sqlConnection);
            cmd.Parameters.AddWithValue("@MaatregelID", maatregelID);
            if (normID == null)
            {
                cmd.Parameters.AddWithValue("@NormID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@NormID", normID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeMaatregel_Categorie(int maatregelID, int? categoryID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Maatregel_Category(MaatregelID, CategoryID) VALUES " +
                                                                       "(@MaatregelID, @CategoryID)", sqlConnection);
            cmd.Parameters.AddWithValue("@MaatregelID", maatregelID);
            if (categoryID == null)
            {
                cmd.Parameters.AddWithValue("@CategoryID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);
            }
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        #endregion maatregel details

        #region add to object

        public int AddAndCreateIssueToObject(string objectId, string gevaarId)
        {
            string issueState = "0";
            int issueId = InitIssue(gevaarId, issueState);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjectIssues(ObjectID, IssueID) VALUES " +
                                                                       "(@ObjectID, @IssueID)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);
            cmd.Parameters.AddWithValue("@IssueID", issueId);

            //mag weg******************************************************
            Int32 issueIDNotUsedInCode = (Int32)cmd.ExecuteScalar();

            sqlConnection.Close();

            int risicoBeoordelingId = InitRisicoBeoordeling(issueId);
            AddRisicoBeoordelingToIssue(risicoBeoordelingId, issueId);
            return issueId;
        }

        public int AddCoppiedIssueToObject(string objectId, string issueID, string issueVerifyState)
        {

            string gevaarID = FindGevaarID(issueID);
            //List<string> gekoppeldeMaatregelenVanIssue = GetMaatregelenFromIssues(issueID);//FindGekoppeldeMaatregelenVanIssue(issueID);

            int duplicateIssueId = InitIssue(gevaarID, issueVerifyState);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjectIssues(ObjectID, IssueID) VALUES " +
                                                                       "(@ObjectID, @IssueID)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);
            cmd.Parameters.AddWithValue("@IssueID", duplicateIssueId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return duplicateIssueId;
        }

        public void AddImageToObject(string objectID, string imageFilePath)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjectImages(ObjectID, ImageFilePath) VALUES " +
                                                                       "(@ObjectID, @ImageFilePath)", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectID", objectID);
            cmd.Parameters.AddWithValue("@ImageFilePath", imageFilePath);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        #endregion add to object

        #region add to issue

        public void AddRisicoBeoordelingToIssue(int risicoBeoordelingId, int issueId)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableIssues " +
                                 "SET IssueRisicoBeoordelingID = '" + risicoBeoordelingId + "'" +
                                  "WHERE IssueID = '" + issueId + "'", sqlConnection);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddMaatregelToIssue(int issueId, int maatregelId)
        {

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableIssueMaatregelen(IssueID, MaatregelID) VALUES " +
                                                                       "(@IssueID, @MaatregelID)", sqlConnection); //+
                                                                      // "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@IssueID", issueId);
            cmd.Parameters.AddWithValue("@MaatregelID", maatregelId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public void AddImageToIssue(string issueID, string imageFilePath)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableIssueImages(IssueID, ImageFilePath) VALUES " +
                                                                       "(@IssueID, @ImageFilePath)", sqlConnection);
            cmd.Parameters.AddWithValue("@IssueID", issueID);
            cmd.Parameters.AddWithValue("@ImageFilePath", imageFilePath);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        #endregion add to issue

        #region add to template
        public void AddGevaarToTemplate(string templateId, string gevaarID)
        {

            //string gevaarID = FindGevaarID(issueId);
            //List<string> gekoppeldeMaatregelenVanIssue = FindGekoppeldeMaatregelenVanIssue(issueId);

            //int duplicateIssueId = InitIssue(gevaarID);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableTemplateGevaren(TemplateID, GevaarID) VALUES " +
                                                                       "(@TemplateID, @GevaarID) ", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateID", templateId);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);

            cmd.ExecuteNonQuery();
            //Int32 issueID = (Int32)cmd.ExecuteScalar();

            sqlConnection.Close();

        }

        public void AddAndCreateIssueToTemplate(string templateId, string issueId)
        {
            string issueState = "1";
            string gevaarID = FindGevaarID(issueId);
            List<string> gekoppeldeMaatregelenVanIssue = GetMaatregelenFromIssues(issueId);//FindGekoppeldeMaatregelenVanIssue(issueId);

            int duplicateIssueId = InitIssue(gevaarID, issueState);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableTemplateIssues(TemplateID, IssueID) VALUES " +
                                                                       "(@TemplateID, @IssueID) " +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateID", templateId);
            cmd.Parameters.AddWithValue("@IssueID", duplicateIssueId);

            cmd.ExecuteNonQuery();
            //Int32 issueID = (Int32)cmd.ExecuteScalar();

            sqlConnection.Close();

            //int risicoBeoordelingId = InitRisicoBeoordelingDuplicate(duplicateIssueId, issueId);
            //AddRisicoBeoordelingToIssue(risicoBeoordelingId, duplicateIssueId);

            //for (int i = 0; i < gekoppeldeMaatregelenVanIssue.Count; i++)
            //{
            //    AddMaatregelToIssue(duplicateIssueId, int.Parse(gekoppeldeMaatregelenVanIssue[i]));
            //}

        }
        #endregion add to template

        #region delete

        public void VerwijderIssuesVanObject(string objectID, string issueID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM TableObjectIssues WHERE IssueID = @IssueID " +
                                            "AND ObjectID = @ObjectID", sqlConnection);

            cmd.Parameters.AddWithValue("@IssueID", issueID);
            cmd.Parameters.AddWithValue("@ObjectID", objectID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void VerwijderRisicoBeoordelingVanIssue(string issueID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM RisicoBeoordeling WHERE IssueID = @IssueID", sqlConnection);

            cmd.Parameters.AddWithValue("@IssueID", issueID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void VerwijderMaatregelenVanIssue(string issueID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM TableIssueMaatregelen WHERE IssueID = @IssueID", sqlConnection);

            cmd.Parameters.AddWithValue("@IssueID", issueID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void VerwijderIssue(string issueID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM TableIssues WHERE IssueID = @IssueID", sqlConnection);

            cmd.Parameters.AddWithValue("@IssueID", issueID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public void VerwijderIssueVanTemplate()
        {

        }

        public void VerwijderGevaarVanTemplate(string templateID, string gevaarID)
        {


        }

        #region delete gevaar data
        public void VerwijderGevaar_Disciplines(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Discipline WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void VerwijderGevaar_Gebruiksfases(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Gebruiksfase WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void VerwijderGevaar_Bedienvorm(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Bedienvorm WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void VerwijderGevaar_Gebruiker(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Gebruiker WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void VerwijderGevaar_GevaarlijkeZone(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_GevaarlijkeZone WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void VerwijderGevaar_Taak(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Taak WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void VerwijderGevaar_GevaarType(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_GevaarType WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void VerwijderGevaar_Gevolg(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Gevolg WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        #endregion delete gevaar data

        #region delete maatregel data
        public void VerwijderMaatregel_Norm(int maatregelID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Maatregel_Norm WHERE MaatregelID = @MaatregelID", sqlConnection);

            cmd.Parameters.AddWithValue("@MaatregelID", maatregelID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void VerwijderMaatregel_Category(int maatregelID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Maatregel_Category WHERE MaatregelID = @MaatregelID", sqlConnection);

            cmd.Parameters.AddWithValue("@MaatregelID", maatregelID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        #endregion delete maatregel data

        #endregion delete


        #region UPDATE
        public void UpdateRisicoBeoordeling(Item item)
        {
            string issueID = item.ItemData.IssueID;
            string init_Se = item.ItemData.Init_Se;
            string init_Fr = item.ItemData.Init_Fr;
            string init_Pr = item.ItemData.Init_Pr;
            string init_Av = item.ItemData.Init_Av;
            string init_Cl = item.ItemData.Init_Cl;
            string init_Risico = item.ItemData.Init_Risico;
            string init_Se_Comment = item.ItemData.Init_Se_Comment;
            string init_Fr_Comment = item.ItemData.Init_Fr_Comment;
            string init_Pr_Comment = item.ItemData.Init_Pr_Comment;
            string init_Av_Comment = item.ItemData.Init_Av_Comment;
            string init_Cl_Comment = item.ItemData.Init_Cl_Comment;
            string init_Risico_Comment = item.ItemData.Init_Risico_Comment;

            string rest_Se = item.ItemData.Rest_Se;
            string rest_Fr = item.ItemData.Rest_Fr;
            string rest_Pr = item.ItemData.Rest_Pr;
            string rest_Av = item.ItemData.Rest_Av;
            string rest_Cl = item.ItemData.Rest_Cl;
            string rest_Risico = item.ItemData.Rest_Risico;
            string rest_Se_Comment = item.ItemData.Rest_Se_Comment;
            string rest_Fr_Comment = item.ItemData.Rest_Fr_Comment;
            string rest_Pr_Comment = item.ItemData.Rest_Pr_Comment;
            string rest_Av_Comment = item.ItemData.Rest_Av_Comment;
            string rest_Cl_Comment = item.ItemData.Rest_Cl_Comment;
            string rest_Risico_Comment = item.ItemData.Rest_Risico_Comment;
            string rest_Ok = item.ItemData.Rest_Ok;


            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE RisicoBeoordeling " +
                                 "SET " +
                                 " Init_Se = @Init_Se," +
                                 " Init_Fr = @Init_Fr," +
                                 " Init_Pr = @Init_Pr," +
                                 " Init_Av = @Init_Av," +
                                 " Init_Cl = @Init_Cl," +
                                 " Init_Risico = @Init_Risico," +
                                 " Init_Se_Comment = @Init_Se_Comment," +
                                 " Init_Fr_Comment = @Init_Fr_Comment," +
                                 " Init_Pr_Comment = @Init_Pr_Comment," +
                                 " Init_Av_Comment = @Init_Av_Comment," +
                                 " Init_Cl_Comment = @Init_Cl_Comment," +
                                 " Init_Risico_Comment = @Init_Risico_Comment," +
                                 " Rest_Se = @Rest_Se," +
                                 " Rest_Fr = @Rest_Fr," +
                                 " Rest_Pr = @Rest_Pr," +
                                 " Rest_Av = @Rest_Av," +
                                 " Rest_Cl = @Rest_Cl," +
                                 " Rest_Risico = @Rest_Risico," +
                                 " Rest_Se_Comment = @Rest_Se_Comment," +
                                 " Rest_Fr_Comment = @Rest_Fr_Comment," +
                                 " Rest_Pr_Comment = @Rest_Pr_Comment," +
                                 " Rest_Av_Comment = @Rest_Av_Comment," +
                                 " Rest_Cl_Comment = @Rest_Cl_Comment," +
                                 " Rest_Risico_Comment = @Rest_Risico_Comment," +
                                 " Rest_Risico_Ok = @Rest_Risico_Ok" +
                                 " WHERE IssueID = '" + issueID + "'", sqlConnection); 

            cmd.Parameters.AddWithValue("@Init_Se", init_Se);
            cmd.Parameters.AddWithValue("@Init_Fr", init_Fr);
            cmd.Parameters.AddWithValue("@Init_Pr", init_Pr);
            cmd.Parameters.AddWithValue("@Init_Av", init_Av);
            cmd.Parameters.AddWithValue("@Init_Cl", init_Cl);
            cmd.Parameters.AddWithValue("@Init_Risico", init_Risico);
            cmd.Parameters.AddWithValue("@Init_Se_Comment", init_Se_Comment);
            cmd.Parameters.AddWithValue("@Init_Fr_Comment", init_Fr_Comment);
            cmd.Parameters.AddWithValue("@Init_Pr_Comment", init_Pr_Comment);
            cmd.Parameters.AddWithValue("@Init_Av_Comment", init_Av_Comment);
            cmd.Parameters.AddWithValue("@Init_Cl_Comment", init_Cl_Comment);
            cmd.Parameters.AddWithValue("@Init_Risico_Comment", init_Risico_Comment);
            cmd.Parameters.AddWithValue("@Rest_Se", rest_Se);
            cmd.Parameters.AddWithValue("@Rest_Fr", rest_Fr);
            cmd.Parameters.AddWithValue("@Rest_Pr", rest_Pr);
            cmd.Parameters.AddWithValue("@Rest_Av", rest_Av);
            cmd.Parameters.AddWithValue("@Rest_Cl", rest_Cl);
            cmd.Parameters.AddWithValue("@Rest_Risico", rest_Risico);
            cmd.Parameters.AddWithValue("@Rest_Se_Comment", rest_Se_Comment);
            cmd.Parameters.AddWithValue("@Rest_Fr_Comment", rest_Fr_Comment);
            cmd.Parameters.AddWithValue("@Rest_Pr_Comment", rest_Pr_Comment);
            cmd.Parameters.AddWithValue("@Rest_Av_Comment", rest_Av_Comment);
            cmd.Parameters.AddWithValue("@Rest_Cl_Comment", rest_Cl_Comment);
            cmd.Parameters.AddWithValue("@Rest_Risico_Comment", rest_Risico_Comment);
            cmd.Parameters.AddWithValue("@Rest_Risico_Ok", rest_Ok);

            cmd.ExecuteNonQuery();
            //Int32 risicoBeoordelingID = (Int32)cmd.ExecuteScalar();
            sqlConnection.Close();
            //return risicoBeoordelingID;
        }


        public void UpdateIssueState(string issueID, string newState)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableIssues " +
                                             "SET IssueStatus = @IssueStatus" +
                                            " WHERE IssueID = '" + issueID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@IssueStatus", newState);
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateObjectImage(string objectID, string imageFilePath)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableObjectImages " +
                                             "SET ImageFilePath = @ImageFilePath" +
                                            " WHERE ObjectID = '" + objectID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@ImageFilePath", imageFilePath);
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateGevaarGebeurtenis(int gevaarID, string text)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableGevaarMulti " +
                                             "SET GevaarlijkeGebeurtenis = @GevaarlijkeGebeurtenis" +
                                            " WHERE GevaarID = '" + gevaarID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarlijkeGebeurtenis", text);
            cmd.ExecuteNonQuery();

            sqlConnection.Close();

        }

        public void UpdateGevaarSituatie(int gevaarID, string text)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableGevaarMulti " +
                                             "SET GevaarlijkeSituatie = @GevaarlijkeSituatie" +
                                            " WHERE GevaarID = '" + gevaarID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarlijkeSituatie", text);
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }



        #endregion UPDATE



        #region GET REQUESTS FROM DATABASE

        #region get tables
        public SqlDataAdapter GetProjecten()
        {
            sqlConnection.Open();
            String query = "SELECT ProjectID, ProjectNaam FROM TableProjecten";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }


        public SqlDataAdapter GetObjecten()
        {
            sqlConnection.Open();
            String query = "SELECT ProjectNaam,ObjectNaam FROM TableObjecten";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetObjectenFromProject(string projectId)
        {
            sqlConnection.Open();
            String query = "SELECT ObjectID, ProjectNaam, ObjectNaam, ObjectType, ObjectOmschrijving FROM TableObjecten WHERE ProjectID = '" + projectId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }




        public SqlDataAdapter GetIssuesFromObject(string objectID)
        {
            sqlConnection.Open();
            string query = "SELECT * FROM View_ObjectIssues " +
                            "WHERE View_ObjectIssues.IssueID IN (SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "') ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        


        public SqlDataAdapter GetAllIssues()
        {
            sqlConnection.Open();
            string query = "SELECT TableIssues.IssueID, TableGevaren.GevaarlijkeSituatie, TableGevaren.GevaarlijkeGebeurtenis, TableGevaren.Discipline, TableGevaren.Gebruiksfase, TableGevaren.Bedienvorm," +
                            "TableGevaren.Gebruiker, TableGevaren.GevaarlijkeZone, TableGevaren.Taak_Actie, TableGevaren.Gevaar, TableGevaren.Gevolg " +
                            " FROM TableIssues INNER JOIN TableGevaren" +
                            " ON TableGevaren.GevaarID = TableIssues.IssueGevaarID WHERE TableIssues.IssueID" +
                            " IN(" +
                            " SELECT TableObjectIssues.IssueID FROM TableObjectIssues)";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        public SqlDataAdapter GetAllIssuesWithGevaarID(string gevaarID)
        {
            sqlConnection.Open();
            string query = "SELECT TableObjecten.ObjectNaam, View_ObjectIssues.* " +
                            "FROM TableObjecten INNER JOIN " +
                            "TableObjectIssues ON TableObjecten.ObjectID = TableObjectIssues.ObjectID INNER JOIN " +
                            "View_ObjectIssues ON TableObjectIssues.IssueID = View_ObjectIssues.IssueID " +
                            "WHERE View_ObjectIssues.GevaarID = '" + gevaarID + "' ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        public SqlDataAdapter GetIssueMaatregelen(string issueID)
        {
            sqlConnection.Open();
            string query = "SELECT * FROM View_MaatregelenCompleet " +
                            "WHERE View_MaatregelenCompleet.MaatregelID IN (SELECT TableIssueMaatregelen.MaatregelID FROM TableIssueMaatregelen WHERE TableIssueMaatregelen.IssueID = '" + issueID + "') ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetTemplates()
        {
            sqlConnection.Open();
            String query = "SELECT * FROM TableTemplates";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetMaatregelen()
        {
            sqlConnection.Open();
            String query = "SELECT * FROM View_MaatregelenCompleet";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetGevaren()
        {
            sqlConnection.Open();
            String query = "SELECT * FROM View_GevarenCompleet";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }





        public SqlDataAdapter GetRisicoBeoordelingFromIssue(string issueID)
        {
            
            sqlConnection.Open();
            String query = "SELECT * FROM RisicoBeoordeling WHERE IssueID = '"+ issueID +"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }


        public SqlDataAdapter GetTemplateIssues(string templateID)
        {
            sqlConnection.Open();
            string query = "SELECT * FROM View_ObjectIssues " +
                            "WHERE View_ObjectIssues.IssueID IN (SELECT TableTemplateIssues.IssueID FROM TableTemplateIssues WHERE TableTemplateIssues.TemplateID = '" + templateID + "') ";


            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetTemplateGevaren(string templateID)
        {

            sqlConnection.Open();
            String query = "SELECT TableGevaren.* FROM TableTemplateGevaren " +
                " JOIN TableGevaren " +
                "ON TableGevaren.GevaarID = TableTemplateGevaren.GevaarID WHERE TableTemplateGevaren.TemplateID = '" + templateID + "'";
                
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }


        public SqlDataAdapter GetGevarenTableByDiscipline(string disciplineType)
        {
            
            sqlConnection.Open();
            String query = "SELECT * FROM TableGevaren WHERE Discipline = '" + disciplineType + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        #endregion get tables
        
        public string GetObjectImage(string objectID)
        {
            string imageFilePath = "";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ImageFilePath FROM TableObjectImages " +
                                            "WHERE TableObjectImages.ObjectID = '" + objectID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    imageFilePath = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();

            return imageFilePath;
        }

        public string GetIssueImage(string issueID)
        {
            string imageFilePath = "";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ImageFilePath FROM TableIssueImages " +
                                            "WHERE TableIssueImages.IssueID = '" + issueID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    imageFilePath = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();

            return imageFilePath;
        }

        //Inner region get id
        #region get ID
        public string FindGevaarID(string issueID)
        {
            string gevaarID = "error";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT IssueGevaarID FROM TableIssues " +
                                            "WHERE TableIssues.IssueID = '" + issueID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    gevaarID = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();
            return gevaarID;
        }

        public string GetObjectIdByName(string objectName)
        {
            string objectID = "error";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectID FROM TableObjecten " +
                                            "WHERE TableObjecten.ObjectNaam = '" + objectName + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectID = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();
            return objectID;
        }

        public string GetTemplateIdByName(string templateName)
        {
            string templateID = "error";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TemplateID FROM TableTemplates " +
                                            "WHERE TableTemplates.TemplateNaam = '" + templateName + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    templateID = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();
            return templateID;
        }

        public string GetObjectIdByIssue(string issueId)
        {
            string objectID = "0";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectID FROM TableObjectIssues " +
                                            "WHERE TableObjectIssues.IssueID = '" + issueId + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectID = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();
            return objectID;
        }

        public string GetIssueIdByObjectAndGevaarId(string objectId, string gevaarId)
        {
            string issueId = "null";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT IssueID FROM TableObjectIssues " +
                                            "WHERE TableObjectIssues.ObjectID = '" + objectId + "' " +
                                            "AND TableObjectIssues.IssueID IN ( " +
                                            "SELECT IssueID FROM TableIssues WHERE IssueGevaarID = '" + gevaarId + "' ) ", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    issueId = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();


            return issueId;
        }


        public string GetMenuOptionID(string databaseTableName, string databaseIDColumnName, string databaseColumnName, string optionText)
        {
            string optionID = "null";
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT " + databaseIDColumnName + "  FROM " + databaseTableName + " WHERE " + databaseColumnName + " = @OptionText ", sqlConnection);

            cmd.Parameters.AddWithValue("@OptionText", optionText);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    optionID = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();


            return optionID;
        }




        #endregion get ID

        #region get info
        public List<string> GetIssuesInfo(string issueID)
        {//Error. moet aan gewerkt worden. verkeerde db table gebruikt
            
            List<string> issueInfo = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT View_ObjectIssues.IssueID, View_ObjectIssues.GevaarlijkeSituatie, View_ObjectIssues.GevaarlijkeGebeurtenis, View_ObjectIssues.Gevaar " +
                                            "FROM View_ObjectIssues " +
                                            "WHERE View_ObjectIssues.IssueID = '" + issueID + "' ", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    issueInfo.Add((dr[0]).ToString());
                    issueInfo.Add((dr[1]).ToString());
                    issueInfo.Add((dr[2]).ToString());
                    issueInfo.Add((dr[3]).ToString());
                }
            }
            sqlConnection.Close();

            return issueInfo;
        }

        public List<string> GetObjectInfo(string objectID)
        {
            List<string> objectInfo = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TableObjecten.ProjectID, TableObjecten.ProjectNaam, TableObjecten.ObjectNaam, TableObjecten.ObjectType, TableObjecten.ObjectOmschrijving " +
                                            "FROM TableObjecten WHERE TableObjecten.ObjectID = '" + objectID + "' ", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectInfo.Add((dr[0]).ToString());
                    objectInfo.Add((dr[1]).ToString());
                    objectInfo.Add((dr[2]).ToString());
                    objectInfo.Add((dr[3]).ToString());
                    objectInfo.Add((dr[4]).ToString());
                }
            }
            sqlConnection.Close();

            return objectInfo;
        }


       
        
        public string GetLastTemplateID()
        {
            // SELECT* FROM TableName WHERE id=(SELECT max(id) FROM TableName);
            string templateID = "-1";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TableTemplates.TemplateID FROM TableTemplates WHERE id=(SELECT max(id) FROM TableTemplates)", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    templateID = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();
            return templateID;
        }
        #endregion get info


        #region get states
        //begin get states
        public Dictionary<string, string> GetObjectIssuesRiskValue(string objectID)
        {
            Dictionary<string, string> issueRiskValue = new Dictionary<string, string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_issueRestRisico WHERE View_issueRestRisico.IssueID" +
                                            " IN(" +
                                            " SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "')", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    issueRiskValue.Add((dr[0]).ToString(), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();

            return issueRiskValue;
        }

        public Dictionary<string, string> GetObjectIssuesState(string objectID)
        {
            Dictionary<string, string> issueStates = new Dictionary<string, string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TableIssues.IssueID, TableIssues.IssueStatus " +
                                            "FROM TableIssues WHERE TableIssues.IssueID" +
                                            " IN(" +
                                            " SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "')", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    issueStates.Add((dr[0]).ToString(), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();

            return issueStates;
        }

        //public Dictionary<string, string> GetObjectIssuesMaatregelenState(string objectID)
        //{
        //    Dictionary<string, string> issueMaatregelenStates = new Dictionary<string, string>();

        //    sqlConnection.Open();

        //    SqlCommand cmd = new SqlCommand("SELECT COUNT(MaatregelID) FROM TableIssueMaatregelen " +
        //                                    "WHERE TableIssueMaatregelen.IssueID = '" + issueId + "' ", sqlConnection);


        //    //SqlCommand cmd = new SqlCommand("SELECT TableIssues.IssueID, TableIssues.IssueStatus " +
        //    //                                "FROM TableIssues WHERE TableIssues.IssueID" +
        //    //                                " IN(" +
        //    //                                " SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "')", sqlConnection);
        //    using (SqlDataReader dr = cmd.ExecuteReader())
        //    {
        //        while (dr.Read())
        //        {
        //            issueMaatregelenStates.Add((dr[0]).ToString(), (dr[1]).ToString());
        //        }
        //    }
        //    sqlConnection.Close();

        //    return issueMaatregelenStates;
        //}

        

        public string GetIssueState(string issueId)
        {
            string issueState = "-1";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TableIssues.IssueStatus " +
                                            "FROM TableIssues WHERE TableIssues.IssueID = '" + issueId + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    issueState = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();
            return issueState;
        }

        #endregion get states


        #region get gevaar data

       public SqlDataAdapter GetGevaar_Situatie_gebeurtenis(string gevaarID)
       {

            sqlConnection.Open();
            String query = "SELECT * FROM TableGevaarMulti WHERE GevaarID = '" + gevaarID + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
       }


        public Dictionary<int, int> GetGevaar_Disciplines(string gevaarID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> gevaarDisciplines = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT DisciplineID FROM Gevaar_Discipline " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarDisciplines.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return gevaarDisciplines;
        }

        public Dictionary<int, int> GetGevaar_Bedienvorm(string gevaarID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> gevaarBedienvorm_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT BedienvormID FROM Gevaar_Bedienvorm " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarBedienvorm_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return gevaarBedienvorm_Index;
        }

        public Dictionary<int, int> GetGevaar_Gebruiker(string gevaarID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> gevaarGebruiker_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruikerID FROM Gevaar_Gebruiker " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarGebruiker_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return gevaarGebruiker_Index;
        }

        public Dictionary<int, int> GetGevaar_Gebruiksfase(string gevaarID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> gevaarGebruiksfase_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruiksfaseID FROM Gevaar_Gebruiksfase " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarGebruiksfase_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return gevaarGebruiksfase_Index;
        }

        public Dictionary<int, int> GetGevaar_GevaarlijkeZone(string gevaarID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> gevaarGevaarlijkeZone_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarlijkeZoneID FROM Gevaar_GevaarlijkeZone " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarGevaarlijkeZone_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return gevaarGevaarlijkeZone_Index;
        }

        public Dictionary<int, int> GetGevaar_GevaarType(string gevaarID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> gevaarType_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarTypeID FROM Gevaar_GevaarType " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarType_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return gevaarType_Index;
        }


        public Dictionary<int, int> GetGevaar_Gevolg(string gevaarID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> gevaarGevolg_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevolgID FROM Gevaar_Gevolg " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarGevolg_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return gevaarGevolg_Index;
        }

        public Dictionary<int, int> GetGevaar_Taak(string gevaarID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> gevaarTaak_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TaakID FROM Gevaar_Taak " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarTaak_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return gevaarTaak_Index;
        }



        #endregion get gevaar data

        #region get maatregel data

        public Dictionary<int, int> GetMaatregel_Normen(string maatregelID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> maatregelNorm_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT NormID FROM Maatregel_Norm " +
                                            "WHERE MaatregelID = '" + maatregelID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        maatregelNorm_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return maatregelNorm_Index;
        }

        public Dictionary<int, int> GetMaatregel_Categorie(string maatregelID)
        {
            int checkBoxIndex = 0;
            Dictionary<int, int> maatregelCategorie_Index = new Dictionary<int, int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT CategoryID FROM Maatregel_Category " +
                                            "WHERE MaatregelID = '" + maatregelID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        maatregelCategorie_Index.Add(checkBoxIndex, int.Parse((dr[0]).ToString()));
                    }
                    checkBoxIndex++;
                }
            }
            sqlConnection.Close();
            return maatregelCategorie_Index;
        }

        #endregion get maatregel data






        #region get selected
        public SqlDataAdapter GetSelectedIssuesFromObject(string objectID, List<string> selectedIssuesId)
        {
            sqlConnection.Open();

            string query = "SELECT TableIssues.IssueID, TableGevaren.GevaarlijkeSituatie, TableGevaren.GevaarlijkeGebeurtenis, TableGevaren.Discipline, TableGevaren.Gebruiksfase, TableGevaren.Bedienvorm," +
                            "TableGevaren.Gebruiker, TableGevaren.GevaarlijkeZone, TableGevaren.Taak_Actie, TableGevaren.Gevaar, TableGevaren.Gevolg " +
                            " FROM TableIssues INNER JOIN TableGevaren" +
                            " ON TableGevaren.GevaarID = TableIssues.IssueGevaarID WHERE TableIssues.IssueID" +
                            " IN(" +
                            " SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "') " +
                            "AND TableIssues.IssueID IN(" +
                            string.Join( ",", selectedIssuesId) +
                             ")";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        public SqlDataAdapter GetSelectedIssuesFromTemplate(string templateID, List<string> selectedIssuesId)
        {
            sqlConnection.Open();
            string query = "SELECT TableIssues.IssueID, TableGevaren.GevaarlijkeSituatie, TableGevaren.GevaarlijkeGebeurtenis, TableGevaren.Discipline, TableGevaren.Gebruiksfase, TableGevaren.Bedienvorm," +
                            "TableGevaren.Gebruiker, TableGevaren.GevaarlijkeZone, TableGevaren.Taak_Actie, TableGevaren.Gevaar, TableGevaren.Gevolg " +
                            " FROM TableIssues INNER JOIN TableGevaren" +
                            " ON TableGevaren.GevaarID = TableIssues.IssueGevaarID WHERE TableIssues.IssueID" +
                            " IN(" +
                            " SELECT TableTemplateIssues.IssueID FROM TableTemplateIssues WHERE TableTemplateIssues.TemplateID = '" + templateID + "') " +
                            " AND TableIssues.IssueID IN( " +
                            string.Join(",", selectedIssuesId) +
                             " )";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        public SqlDataAdapter GetSelectedGevarenFromTemplate(string templateID, List<string> selectedGevarenId)
        {
            sqlConnection.Open();

            string query = "SELECT TableGevaren.* FROM TableTemplateGevaren " +
                            " JOIN TableGevaren " +
                            " ON TableGevaren.GevaarID = TableTemplateGevaren.GevaarID WHERE TableGevaren.GevaarID IN(" +
                            " SELECT TableTemplateGevaren.GevaarID FROM TableTemplateGevaren WHERE TableTemplateGevaren.TemplateID = '" + templateID + "') " +
                            " AND TableGevaren.GevaarID IN( " +
                            string.Join(",", selectedGevarenId) +
                             " )";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        public SqlDataAdapter GetSelectedGevaren(List<string> selectedGevarenId)
        {
            sqlConnection.Open();

            string query = "SELECT * FROM View_GevarenCompleet " +
                           "WHERE View_GevarenCompleet.GevaarID IN( " +
                           string.Join(",", selectedGevarenId) +
                           " )";

            Console.WriteLine(query);
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }
        #endregion get selected


        #region get gekoppelde as list
        public List<string> GetGekoppeldeIssuesFromObjectAsList(string objectID)
        {
            List<string> gekoppeldeIssues = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT IssueID FROM TableObjectIssues " +
                                            "WHERE ObjectID = '"+ objectID +"' ", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    gekoppeldeIssues.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();

            return gekoppeldeIssues;
        }

        public List<string> GetGekoppeldeGevarenFromObjectAsList(string objectID)
        {
            List<string> gekoppeldeGevaren = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT IssueGevaarID FROM TableIssues " +
                                            "WHERE TableIssues.IssueID IN ( " +
                                            "SELECT IssueID FROM TableObjectIssues " +
                                            "WHERE ObjectID = '" + objectID + "')", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    gekoppeldeGevaren.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();

            return gekoppeldeGevaren;
        }

        public List<string> GetGekoppeldeIssuesFromTemplateAsList(string templateID)
        {
            List<string> gekoppeldeIssues = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT IssueID FROM TableTemplateIssues " +
                                            "WHERE TemplateID = '" + templateID + "' ", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    gekoppeldeIssues.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();

            return gekoppeldeIssues;
        }

        public List<string> GetGekoppeldeGevarenFromTemplateAsList(string templateID)
        {
            List<string> gekoppeldeIssues = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarID FROM TableTemplateGevaren " +
                                            "WHERE TemplateID = '" + templateID + "' ", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    gekoppeldeIssues.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();

            return gekoppeldeIssues;
        }





        public List<string> GetGevarenFromIssuesAsList(List<string> selectedIssuesId)
        {
            List<string> gevarenIDs = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT IssueGevaarID FROM TableIssues " +
                                            "WHERE TableIssues.IssueID IN (  " +
                                            string.Join(",", selectedIssuesId) +
                                            " )", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    gevarenIDs.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();

            return gevarenIDs;
        }

        
        public List<string> GetMaatregelenFromIssues(string issueId)
        {
            List<string> maatregelIds = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MaatregelID FROM TableIssueMaatregelen " +
                                            "WHERE TableIssueMaatregelen.IssueID = '" + issueId +"' ", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    maatregelIds.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();

            return maatregelIds;
        }
        #endregion get gekoppelde as list


        #region Get usage
        public SqlDataAdapter GetGevarenUsage(string gevaarID)
        {
            //List<string> usage = new List<string>();

            sqlConnection.Open();
            //SqlCommand cmd = new SqlCommand("SELECT View_ObjectIssues.IssueID, View_ObjectIssues.GevaarID " +
            //                                "FROM View_ObjectIssues " +
            //                                "WHERE View_ObjectIssues.GevaarID = '" + gevaarID + "' ", sqlConnection);

            String query = "SELECT View_ObjectIssues.IssueID, View_ObjectIssues.GevaarID " +
                                            "FROM View_ObjectIssues " +
                                            "WHERE View_ObjectIssues.GevaarID = '" + gevaarID + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }




        #region get menu usage
        public SqlDataAdapter GetObjectTypeUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT TableObjecten.ObjectNaam, TableObjecten.ObjectType " +
                                            "FROM TableObjecten " +
                                            "WHERE TableObjecten.ObjectType = '" + dbItemText + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetGevolgenUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT Gevaar_Gevolg.GevaarID, Gevaar_Gevolg.GevolgID " +
                                            "FROM Gevaar_Gevolg " +
                                            "WHERE Gevaar_Gevolg.GevolgID IN ( " +
                                            "SELECT GevolgID FROM Gevolgen WHERE Gevolg = '" + dbItemText + "' ) ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetGevarenZoneUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT Gevaar_GevaarlijkeZone.GevaarID, Gevaar_GevaarlijkeZone.GevaarlijkeZoneID " +
                                            "FROM Gevaar_GevaarlijkeZone " +
                                            "WHERE Gevaar_GevaarlijkeZone.GevaarlijkeZoneID IN ( " +
                                            "SELECT GevarenzoneID FROM Gevarenzones WHERE Gevarenzone = '" + dbItemText + "' ) ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetGevaarTypeUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT Gevaar_GevaarType.GevaarID, Gevaar_GevaarType.GevaarTypeID " +
                                            "FROM Gevaar_GevaarType " +
                                            "WHERE Gevaar_GevaarType.GevaarTypeID IN ( " +
                                            "SELECT GevaarTypeID FROM GevaarTypes WHERE GevaarType = '" + dbItemText + "' ) ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetGebruiksfaseUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT Gevaar_Gebruiksfase.GevaarID, Gevaar_Gebruiksfase.GebruiksfaseID " +
                                            "FROM Gevaar_Gebruiksfase " +
                                            "WHERE Gevaar_Gebruiksfase.GebruiksfaseID IN ( " +
                                            "SELECT GebruiksfaseID FROM Gebruiksfases WHERE Gebruiksfase = '" + dbItemText + "' ) ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetGebruikerUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT Gevaar_Gebruiker.GevaarID, Gevaar_Gebruiker.GebruikerID " +
                                            "FROM Gevaar_Gebruiker " +
                                            "WHERE Gevaar_Gebruiker.GebruikerID IN ( " +
                                            "SELECT GebruikerID FROM Gebruikers WHERE Gebruiker = '" + dbItemText + "' ) ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetDisciplineUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT Gevaar_Discipline.GevaarID, Gevaar_Discipline.DisciplineID " +
                                            "FROM Gevaar_Discipline " +
                                            "WHERE Gevaar_Discipline.DisciplineID IN ( " +
                                            "SELECT DisciplineID FROM Disciplines WHERE Discipline = '" + dbItemText + "' ) ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetBedienvormUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT Gevaar_Bedienvorm.GevaarID, Gevaar_Bedienvorm.BedienvormID " +
                                            "FROM Gevaar_Bedienvorm " +
                                            "WHERE Gevaar_Bedienvorm.BedienvormID IN ( " +
                                            "SELECT BedienvormID FROM Bedienvormen WHERE Bedienvorm = '" + dbItemText + "' ) ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetGevaarTaakUsage(string dbItemText)
        {
            sqlConnection.Open();
            String query = "SELECT Gevaar_Taak.GevaarID, Gevaar_Taak.TaakID " +
                                            "FROM Gevaar_Taak " +
                                            "WHERE Gevaar_Taak.TaakID IN ( " +
                                            "SELECT TaakID FROM Taken WHERE Taak = '" + dbItemText + "' ) ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        #endregion get menu usage

        #endregion Get usage


        #endregion GET REQUESTS FROM DATABASE


        #region add menus



        public void AddToObjectTypesMenu(string optionToAdd)
        {
            string databaseTableName = "ObjectTypes";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(ObjectType) VALUES " +
                                                                       "(@ObjectType)", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectType", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGevolgenMenu(string optionToAdd)
        {
            string databaseTableName = "Gevolgen";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Gevolg) VALUES " +
                                                                       "(@Gevolg)", sqlConnection);
            cmd.Parameters.AddWithValue("@Gevolg", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGevarenzonesMenu(string optionToAdd)
        {
            string databaseTableName = "Gevarenzones";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Gevarenzone) VALUES " +
                                                                       "(@Gevarenzone)", sqlConnection);
            cmd.Parameters.AddWithValue("@Gevarenzone", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGevaarTypesMenu(string optionToAdd)
        {
            string databaseTableName = "GevaarTypes";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(GevaarType) VALUES " +
                                                                       "(@GevaarType)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarType", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGebruiksfasesMenu(string optionToAdd)
        {
            string databaseTableName = "Gebruiksfases";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Gebruiksfase) VALUES " +
                                                                       "(@Gebruiksfase)", sqlConnection);
            cmd.Parameters.AddWithValue("@Gebruiksfase", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGebruikersMenu(string optionToAdd)
        {
            string databaseTableName = "Gebruikers";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Gebruiker) VALUES " +
                                                                       "(@Gebruiker)", sqlConnection);
            cmd.Parameters.AddWithValue("@Gebruiker", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToDisciplinesMenu(string optionToAdd)
        {
            string databaseTableName = "Disciplines";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Discipline) VALUES " +
                                                                       "(@Discipline)", sqlConnection);
            cmd.Parameters.AddWithValue("@Discipline", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToBedienvormenMenu(string optionToAdd)
        {
            string databaseTableName = "Bedienvormen";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Bedienvorm) VALUES " +
                                                                       "(@Bedienvorm)", sqlConnection);
            cmd.Parameters.AddWithValue("@Bedienvorm", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToTakenMenu(string optionToAdd)
        {
            string databaseTableName = "Taken";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Taak) VALUES " +
                                                                       "(@Taak)", sqlConnection);
            cmd.Parameters.AddWithValue("@Taak", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToNormenMenu(string optionToAdd)
        {
            string databaseTableName = "Normen";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Norm) VALUES " +
                                                                       "(@Norm)", sqlConnection);
            cmd.Parameters.AddWithValue("@Norm", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToCategoriesMenu(string optionToAdd)
        {
            string databaseTableName = "Categories";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Category) VALUES " +
                                                                       "(@Category)", sqlConnection);
            cmd.Parameters.AddWithValue("@Category", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToTemplateTypes(string optionToAdd)
        {
            string databaseTableName = "TemplateTypes";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(TemplateType) VALUES " +
                                                                       "(@TemplateType)", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateType", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToTemplateToepassingen(string optionToAdd)
        {
            string databaseTableName = "TemplateToepassingen";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(TemplateToepassing) VALUES " +
                                                                       "(@TemplateToepassing)", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateToepassing", optionToAdd);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        #endregion add menus

        #region delete menus
 

        public void DeleteFromMenu(string databaseTableName, string databaseColumnName, string optionToDelete)
        {
            //string databaseTableName = "Gevolgen";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM " + databaseTableName + " WHERE " + databaseColumnName + " = @ColumnTitle ", sqlConnection);

            cmd.Parameters.AddWithValue("@ColumnTitle", optionToDelete);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        #endregion delete menus

        #region edit menus
        public void EditFromMenu(string databaseTableName, string databaseColumnName, string databaseIDColumnName, int optionID, string newText)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE " + databaseTableName + " " +
                                             "SET " + databaseColumnName + " = @NewText" +
                                            " WHERE "+ databaseIDColumnName + " = '" + optionID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@NewText", newText);


            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        #endregion edit menus


        #region delete Usage
        public void DeleteUsage(string databaseTableName, string databaseColumnName, string optionIDToDelete)
        {
            //string databaseTableName = "Gevolgen";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM " + databaseTableName + " WHERE " + databaseColumnName + " = @IDToDelete ", sqlConnection);

            cmd.Parameters.AddWithValue("@IDToDelete", optionIDToDelete);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        #endregion delete Usage


        #region getmenus

        public Dictionary<int, string> GetObjectTypes()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectTypeID, ObjectType FROM ObjectTypes", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;
        }


        public Dictionary<int, string> GetGevolgen()
        {
            Dictionary<int, string> index_gevolg = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevolgID, Gevolg FROM Gevolgen", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {index_gevolg.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());}
            }
            sqlConnection.Close();
            return index_gevolg;
        }


        public Dictionary<int, string> GetGevarenzones()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevarenzoneID, Gevarenzone FROM Gevarenzones", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        //public Dictionary<int, string> GetGevaartypes()
        //{
        //    List<string> objectTypes = new List<string>();
        //    sqlConnection.Open();
        //    SqlCommand cmd = new SqlCommand("SELECT GevaarType FROM GevaarTypes", sqlConnection);

        //    using (SqlDataReader dr = cmd.ExecuteReader())
        //    {
        //        while (dr.Read())
        //        {
        //            objectTypes.Add((dr[0]).ToString());
        //        }
        //    }
        //    sqlConnection.Close();
        //    return objectTypes;
        //}

        public Dictionary<int, string> GetGevaarTypes()
        {
            Dictionary<int, string> index_gevolg = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarTypeID, GevaarType FROM GevaarTypes ORDER BY GevaarType", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                { index_gevolg.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString()); }
            }
            sqlConnection.Close();
            return index_gevolg;
        }

        public Dictionary<int, string> GetGebruiksfases()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruiksfaseID, Gebruiksfase FROM Gebruiksfases ORDER BY Gebruiksfase", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        public Dictionary<int, string> GetGebruikers()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruikerID, Gebruiker FROM Gebruikers", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        public Dictionary<int, string> GetDisciplines()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT DisciplineID, Discipline FROM Disciplines", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        public Dictionary<int, string> GetBedienvormen()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT BedienvormID, Bedienvorm FROM Bedienvormen", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        public Dictionary<int, string> GetTaken()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TaakID, Taak FROM Taken", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }




        public Dictionary<int, string> GetNormen()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT NormID, Norm FROM Normen ORDER BY Norm", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        public Dictionary<int, string> GetCategory()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT CategoryID, Category FROM Categories", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        public Dictionary<int, string> GetTemplateTypes()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TemplateTypeID, TemplateType FROM TemplateTypes", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        public Dictionary<int, string> GetTemplateToepassingen()
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TemplateToepassingID, TemplateToepassing FROM TemplateToepassingen", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }

        public List<string> GetTemplateNamen()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TemplateNaam FROM TableTemplates", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;

        }
        public List<string> GetObjectNamen()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectNaam FROM TableObjecten", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectTypes.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();
            return objectTypes;
        }

        #endregion getmenus



    }
}
