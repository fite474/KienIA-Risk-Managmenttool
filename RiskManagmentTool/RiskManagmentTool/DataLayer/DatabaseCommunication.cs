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

            //vieuws doe je door: string strquery = "select * from View_App_Academic where recruitment_id = @recruitment_id

            //SELECT StudentID,  
            //CourseNames = STUFF
            //(
            //    (
            //      SELECT DISTINCT ', ' + CAST(g.CourseName AS VARCHAR(MAX))
            
            //      FROM Courses g, StudentCourses e
            
            //      WHERE g.CourseID = e.CourseID and e.StudentID = t1.StudentID
            
            //      FOR XMl PATH('')
            //    ),1,1,''
            //    )  
            //FROM StudentCourses t1
            //GROUP BY StudentID


        }


        // START REGION INIT ITEMS

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

        public void MakeObject(Item item)
        {
            string projectId = item.ItemData.ProjectId;
            string projectNaam = item.ItemData.ProjectNaam;
            string objectNaam = item.ItemData.ObjectNaam;
            string objectType = item.ItemData.ObjectType;
            string objectOmschrijving = item.ItemData.ObjectOmschrijving;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjecten(ProjectID, ProjectNaam, ObjectNaam, ObjectType, ObjectOmschrijving) VALUES " +
                                                                       "(@ProjectID, @ProjectNaam, @ObjectNaam, @ObjectType, @ObjectOmschrijving)", sqlConnection);
            cmd.Parameters.AddWithValue("@ProjectID", projectId);
            cmd.Parameters.AddWithValue("@ProjectNaam", projectNaam);
            cmd.Parameters.AddWithValue("@ObjectNaam", objectNaam);
            cmd.Parameters.AddWithValue("@ObjectType", objectType);
            cmd.Parameters.AddWithValue("@ObjectOmschrijving", objectOmschrijving);


            cmd.ExecuteNonQuery();
            sqlConnection.Close();
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

        public void MakeGevaar_Disciplines(int gevaarID, int disciplineID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Discipline(GevaarID, DisciplineID) VALUES " +
                                                                       "(@GevaarID, @DisciplineID)", sqlConnection); 
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@DisciplineID", disciplineID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Gebruiksfase(int gevaarID, int gebruiksfaseID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Gebruiksfase(GevaarID, GebruiksfaseID) VALUES " +
                                                                       "(@GevaarID, @GebruiksfaseID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GebruiksfaseID", gebruiksfaseID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Bedienvorm(int gevaarID, int bedienvormID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Bedienvorm(GevaarID, BedienvormID) VALUES " +
                                                                       "(@GevaarID, @BedienvormID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@BedienvormID", bedienvormID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Gebruiker(int gevaarID, int gebruikerID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Gebruiker(GevaarID, GebruikerID) VALUES " +
                                                                       "(@GevaarID, @GebruikerID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GebruikerID", gebruikerID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_GevaarlijkeZone(int gevaarID, int gevaarlijkeZoneID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_GevaarlijkeZone(GevaarID, GevaarlijkeZoneID) VALUES " +
                                                                       "(@GevaarID, @GevaarlijkeZoneID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GevaarlijkeZoneID", gevaarlijkeZoneID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Taak(int gevaarID, int taakID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Taak(GevaarID, TaakID) VALUES " +
                                                                       "(@GevaarID, @TaakID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@TaakID", taakID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_GevaarType(int gevaarID, int gevaarTypeID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_GevaarType(GevaarID, GevaarTypeID) VALUES " +
                                                                       "(@GevaarID, @GevaarTypeID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GevaarTypeID", gevaarTypeID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeGevaar_Gevolg(int gevaarID, int gevolgID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Gevaar_Gevolg(GevaarID, GevolgID) VALUES " +
                                                                       "(@GevaarID, @GevolgID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GevolgID", gevolgID);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }













        public void MakeGevaar(Item item)
        {
            string gevaarlijkeSituatie = item.ItemData.GevaarlijkeSituatie;
            string gevaarlijkeGebeurtenis = item.ItemData.GevaarlijkeGebeurtenis;
            string discipline = item.ItemData.Discipline;
            string gebruiksfase = item.ItemData.Gebruiksfase;
            string bedienvorm = item.ItemData.Bedienvorm;
            string gebruiker = item.ItemData.Gebruiker;
            string gevaarlijkeZone = item.ItemData.GevaarlijkeZone;
            string taak = item.ItemData.Taak;
            string gevaar = item.ItemData.Gevaar;
            string gevolg = item.ItemData.Gevolg;
            


            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableGevaren(GevaarlijkeSituatie, GevaarlijkeGebeurtenis, Discipline, Gebruiksfase, Bedienvorm, Gebruiker, GevaarlijkeZone, Taak_Actie, Gevaar, Gevolg) VALUES " +
                                                                       "(@GevaarlijkeSituatie, @GevaarlijkeGebeurtenis, @Discipline, @Gebruiksfase ,@Bedienvorm, @Gebruiker, @GevaarlijkeZone, @Taak_Actie, @Gevaar, @Gevolg)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarlijkeSituatie", gevaarlijkeSituatie);
            cmd.Parameters.AddWithValue("@GevaarlijkeGebeurtenis", gevaarlijkeGebeurtenis);
            cmd.Parameters.AddWithValue("@Discipline", discipline);
            cmd.Parameters.AddWithValue("@Gebruiksfase", gebruiksfase);
            cmd.Parameters.AddWithValue("@Bedienvorm", bedienvorm);
            cmd.Parameters.AddWithValue("@Gebruiker", gebruiker);
            cmd.Parameters.AddWithValue("@GevaarlijkeZone", gevaarlijkeZone);
            cmd.Parameters.AddWithValue("@Taak_Actie", taak);
            cmd.Parameters.AddWithValue("@Gevaar", gevaar);
            cmd.Parameters.AddWithValue("@Gevolg", gevolg);


            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void MakeMaatregel(Item item)
        {

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableMaatregelen(MaatregelNaam, MaatregelNorm, MaatregelCategory) VALUES " +
                                                                       "(@MaatregelNaam, @MaatregelNorm, @MaatregelCategory)", sqlConnection);
            cmd.Parameters.AddWithValue("@MaatregelNaam", item.ItemData.MaatregelNaam);
            cmd.Parameters.AddWithValue("@MaatregelNorm", item.ItemData.MaatregelNorm);
            cmd.Parameters.AddWithValue("@MaatregelCategory", item.ItemData.MaatregelCategory);



            cmd.ExecuteNonQuery();
            sqlConnection.Close();
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


        // END REGION INIT ITEMS


        // START REGION ADD TO OBJECT
        public int AddAndCreateIssueToObject(string objectId, string gevaarId)
        {
            int issueId = InitIssue(gevaarId);

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

        public void AddCoppiedIssueToObject(string objectId, string issueID)
        {

            string gevaarID = FindGevaarID(issueID);
            List<string> gekoppeldeMaatregelenVanIssue = FindGekoppeldeMaatregelenVanIssue(issueID);

            int duplicateIssueId = InitIssue(gevaarID);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjectIssues(ObjectID, IssueID) VALUES " +
                                                                       "(@ObjectID, @IssueID)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);
            cmd.Parameters.AddWithValue("@IssueID", duplicateIssueId);

            cmd.ExecuteNonQuery();
            //Int32 issueID = (Int32)cmd.ExecuteScalar();

            sqlConnection.Close();

            int risicoBeoordelingId = InitRisicoBeoordelingDuplicate(duplicateIssueId, issueID);
            AddRisicoBeoordelingToIssue(risicoBeoordelingId, duplicateIssueId);

            for (int i = 0; i < gekoppeldeMaatregelenVanIssue.Count; i++)
            {
                AddMaatregelToIssue(duplicateIssueId, int.Parse(gekoppeldeMaatregelenVanIssue[i]));
            }
        }


        private int InitIssue(string gevaarId)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableIssues(IssueGevaarID) VALUES " +
                                                                       "(@IssueGevaarID)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@IssueGevaarID", gevaarId);

            Int32 issueID = (Int32)cmd.ExecuteScalar();
            sqlConnection.Close();
            return issueID;
        }

        private int InitRisicoBeoordeling(int issueId)
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

        private int InitRisicoBeoordelingDuplicate(int issueId, string originalIssueID)
        {

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RisicoBeoordeling(IssueID, Init_Se, Init_Fr, Init_Pr, Init_Av, Init_Cl, Init_Risico, Init_Se_Comment, Init_Fr_Comment, Init_Pr_Comment, Init_Av_Comment, Init_Cl_Comment, Init_Risico_Comment," +
                                                                          " Rest_Se, Rest_Fr, Rest_Pr, Rest_Av, Rest_Cl, Rest_Risico, Rest_Se_Comment, Rest_Fr_Comment, Rest_Pr_Comment, Rest_Av_Comment, Rest_Cl_Comment, Rest_Risico_Comment, Rest_Risico_Ok)" +
                                                                          " SELECT '"+ issueId + "', Init_Se, Init_Fr, Init_Pr, Init_Av, Init_Cl, Init_Risico, Init_Se_Comment, Init_Fr_Comment, Init_Pr_Comment, Init_Av_Comment, Init_Cl_Comment, Init_Risico_Comment," +
                                                                          " Rest_Se, Rest_Fr, Rest_Pr, Rest_Av, Rest_Cl, Rest_Risico, Rest_Se_Comment, Rest_Fr_Comment, Rest_Pr_Comment, Rest_Av_Comment, Rest_Cl_Comment, Rest_Risico_Comment, Rest_Risico_Ok " +
                                                                          " FROM RisicoBeoordeling " +
                                                                          " WHERE IssueID = '"+ originalIssueID +"'" +
                                                                          "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);


            //cmd.Parameters.AddWithValue("@IssueID", issueId);
            

            Int32 risicoBeoordelingID = (Int32)cmd.ExecuteScalar();
            sqlConnection.Close();
            return risicoBeoordelingID;
        }

        private void AddRisicoBeoordelingToIssue(int risicoBeoordelingId, int issueId)
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

            string gevaarID = FindGevaarID(issueId);
            List<string> gekoppeldeMaatregelenVanIssue = FindGekoppeldeMaatregelenVanIssue(issueId);

            int duplicateIssueId = InitIssue(gevaarID);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableTemplateIssues(TemplateID, IssueID) VALUES " +
                                                                       "(@TemplateID, @IssueID) " +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateID", templateId);
            cmd.Parameters.AddWithValue("@IssueID", duplicateIssueId);

            cmd.ExecuteNonQuery();
            //Int32 issueID = (Int32)cmd.ExecuteScalar();

            sqlConnection.Close();

            int risicoBeoordelingId = InitRisicoBeoordelingDuplicate(duplicateIssueId, issueId);
            AddRisicoBeoordelingToIssue(risicoBeoordelingId, duplicateIssueId);

            for (int i = 0; i < gekoppeldeMaatregelenVanIssue.Count; i++)
            {
                AddMaatregelToIssue(duplicateIssueId, int.Parse(gekoppeldeMaatregelenVanIssue[i]));
            }

        }



        private List<string> FindGekoppeldeMaatregelenVanIssue(string issueID)
        {
            //string gevaarID = "error";
            List<string> maatregelIDs = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT MaatregelID FROM TableIssueMaatregelen " +
                                            "WHERE IssueID = '"+ issueID +"'", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    maatregelIDs.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();
            return maatregelIDs;
        }


        // END REGION ADD TO OBJECT


        // START REGION DELETE 

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

        


        // END REGION DELETE



















        // START REGION UPDATE
        //***********************************************************
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


        //END REGION UPDATE



        // START REGION -----------GET REQUESTS FROM DATABASE

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
            //String query = "SELECT * FROM TableRisksUsedInProject WHERE UsedInProjectName = '" + ProjectName + "'";
            string query = "SELECT TableIssues.IssueID, TableGevaren.GevaarlijkeSituatie, TableGevaren.GevaarlijkeGebeurtenis, TableGevaren.Discipline, TableGevaren.Gebruiksfase, TableGevaren.Bedienvorm," +
                            "TableGevaren.Gebruiker, TableGevaren.GevaarlijkeZone, TableGevaren.Taak_Actie, TableGevaren.Gevaar, TableGevaren.Gevolg " +
                            " FROM TableIssues INNER JOIN TableGevaren" +
                            " ON TableGevaren.GevaarID = TableIssues.IssueGevaarID WHERE TableIssues.IssueID" +
                            " IN(" +
                            " SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "')";

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

        public SqlDataAdapter GetIssueMaatregelen(string issueID)
        {
            sqlConnection.Open();
            string query = "SELECT TableMaatregelen.* FROM TableIssueMaatregelen " +
                " JOIN TableMaatregelen " +
                "ON TableMaatregelen.MaatregelID = TableIssueMaatregelen.MaatregelID " +
                "WHERE TableIssueMaatregelen.IssueID = '"+ issueID +"'"; //+

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
            String query = "SELECT MaatregelID, MaatregelNaam, MaatregelCategory, MaatregelNorm FROM TableMaatregelen";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetGevaren()
        {
            sqlConnection.Open();
            //String query = "SELECT * FROM View_Gevaren";//TableGevaren";
            String query = "SELECT * FROM TableGevaren";
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
            String query = "SELECT TableIssues.IssueID, TableGevaren.GevaarlijkeSituatie, TableGevaren.GevaarlijkeGebeurtenis, TableGevaren.Discipline, TableGevaren.Gebruiksfase, TableGevaren.Bedienvorm," +
                            "TableGevaren.Gebruiker, TableGevaren.GevaarlijkeZone, TableGevaren.Taak_Actie, TableGevaren.Gevaar, TableGevaren.Gevolg " +
                            " FROM TableIssues INNER JOIN TableGevaren" +
                            " ON TableGevaren.GevaarID = TableIssues.IssueGevaarID WHERE TableIssues.IssueID" +
                            " IN(" +
                            " SELECT TableTemplateIssues.IssueID FROM TableTemplateIssues WHERE TableTemplateIssues.TemplateID = '" + templateID + "')";


            
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


        //begin inner region filtered get requests




        public SqlDataAdapter GetGevarenTableByDiscipline(string disciplineType)
        {
            
            sqlConnection.Open();
            String query = "SELECT * FROM TableGevaren WHERE Discipline = '" + disciplineType + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        //end inner region filtered get requests


        //Inner region get id

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



        public List<string> GetIssuesInfo(string issueID)
        {
            
            List<string> issueInfo = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TableIssues.IssueID, TableGevaren.GevaarlijkeSituatie, TableGevaren.GevaarlijkeGebeurtenis " +
                                            "FROM TableIssues INNER JOIN TableGevaren" +
                                            " ON TableGevaren.GevaarID = TableIssues.IssueGevaarID WHERE TableIssues.IssueID = '" + issueID + "' ", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    issueInfo.Add((dr[0]).ToString());
                    issueInfo.Add((dr[1]).ToString());
                    issueInfo.Add((dr[2]).ToString());
                }
            }
            sqlConnection.Close();

            return issueInfo;
        }


        //end inner region get id


        //Begin inner region get selected Ids before copying
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

            string query = "SELECT TableGevaren.* FROM TableGevaren " +
                           "WHERE TableGevaren.GevaarID IN( " +
                           string.Join(",", selectedGevarenId) +
                           " )";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }
        //end inner region get selected Ids before copying



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

        //END REGION -----GET REQUESTS FROM DATABASE

        // START Images

        public void AddImageToObject()
        {


        }

        public void GetObjectImage(string objectID)
        {

        }


        // END Images














        //START MENU REGION
        //      SART ADD TO MENU

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
        //      END ADD TO MENU


        //      START GET FROM MENU

        public List<string> GetObjectTypes()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectType FROM ObjectTypes", sqlConnection);

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

        public List<string> GetGevolgen()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Gevolg FROM Gevolgen", sqlConnection);

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

        public List<string> GetGevarenzones()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Gevarenzone FROM Gevarenzones", sqlConnection);

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

        public List<string> GetGevaartypes()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarType FROM GevaarTypes", sqlConnection);

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

        public List<string> GetGebruiksfases()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Gebruiksfase FROM Gebruiksfases", sqlConnection);

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

        public List<string> GetGebruikers()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Gebruiker FROM Gebruikers", sqlConnection);

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

        public List<string> GetDisciplines()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Discipline FROM Disciplines", sqlConnection);

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

        public List<string> GetBedienvormen()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Bedienvorm FROM Bedienvormen", sqlConnection);

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

        public List<string> GetTaken()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Taak FROM Taken", sqlConnection);

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

        public List<string> GetMaatregelNormen()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Norm FROM Normen", sqlConnection);

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

        public List<string> GetMaatregelCategory()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Category FROM Categories", sqlConnection);

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

        public List<string> GetTemplateTypes()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TemplateType FROM TemplateTypes", sqlConnection);

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

        public List<string> GetTemplateToepassingen()
        {
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TemplateToepassing FROM TemplateToepassingen", sqlConnection);

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




        //      END GET FROM MENUS
        //END REGION MENUS

    }
}
