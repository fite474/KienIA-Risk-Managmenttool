using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using RiskManagmentTool.LogicLayer.Objects.Core;
using RiskManagmentTool.LogicLayer;
using System.Drawing;

namespace RiskManagmentTool.DataLayer
{
    class DatabaseCommunication
    {
        SqlConnection sqlConnection;
        public DatabaseCommunication()
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            sqlConnection = databaseConnection.sqlConnection;
        }

        #region version1

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
            sqlConnection.Close();
            return objectID;
        }

        public void InitObjectNotes(int objectID)
        {
            string initText = "";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjectNotes(ObjectID, Notes) VALUES " +
                                                                       "(@ObjectID, @Notes)", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectID);
            cmd.Parameters.AddWithValue("@Notes", initText);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public void SetObjectSettings(int objectID, int setting)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjectSettings(ObjectID, Risicograaf) VALUES " +
                                                                       "(@ObjectID, @Risicograaf)", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectID);
            cmd.Parameters.AddWithValue("@Risicograaf", setting);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public int InitMakeGevaar(string gevaarlijkeSituatie, string gevaarlijkeGebeurtenis)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableGevaarMulti(GevaarlijkeSituatie, GevaarlijkeGebeurtenis, GevaarOriginID) VALUES " +
                                                                       "(@GevaarlijkeSituatie, @GevaarlijkeGebeurtenis, @GevaarOriginID)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarlijkeSituatie", gevaarlijkeSituatie);
            cmd.Parameters.AddWithValue("@GevaarlijkeGebeurtenis", gevaarlijkeGebeurtenis);
            cmd.Parameters.AddWithValue("@GevaarOriginID", -1);

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

        //public void MakeTemplate(Item item)
        //{
        //    string templateNaam = item.ItemData.TemplateNaam;
        //    string templateType = item.ItemData.TemplateType;
        //    string templateToepassing = item.ItemData.TemplateToepassing;
        //    sqlConnection.Open();
        //    SqlCommand cmd = new SqlCommand("INSERT INTO TableTemplates(TemplateNaam, TemplateType, TemplateToepassing) VALUES " +
        //                                                               "(@TemplateNaam, @TemplateType, @TemplateToepassing)", sqlConnection);
        //    cmd.Parameters.AddWithValue("@TemplateNaam", templateNaam);
        //    cmd.Parameters.AddWithValue("@TemplateType", templateType);
        //    cmd.Parameters.AddWithValue("@TemplateToepassing", templateToepassing);


        //    cmd.ExecuteNonQuery();
        //    sqlConnection.Close();
        //}






        #region duplicateGevaar
        //when adding a risk to an obj. copy the line and make a duplicated one. but referencing to the origin id
        private int DuplicateGevaarFromOrigin(string mainGevaarId)
        {
            //step1: get the origin id. if the line is an origin, copy its main id

            string originId = "";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarOriginID FROM TableGevaarMulti " +
                                            "WHERE TableGevaarMulti.GevaarID = '" + mainGevaarId + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    originId = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();





            //als het gevaar niet afgeleid is van een ander gevaar dan is dit het origin gevaar. 
            if (originId.Equals("-1"))
            {
                originId = mainGevaarId;
            }



            //hier de duplicate into talegevaar multi query

            sqlConnection.Open();
            cmd = new SqlCommand(" INSERT INTO TableGevaarMulti(GevaarlijkeSituatie, GevaarlijkeGebeurtenis, GevaarOriginID)"+
                                 " SELECT GevaarlijkeSituatie, GevaarlijkeGebeurtenis, '" + originId + "'" + 
                                 " FROM TableGevaarMulti"+
                                 " WHERE GevaarID = '" + mainGevaarId + "'" +
                                 " SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            Int32 finalId = (Int32)cmd.ExecuteScalar();
            //using (SqlDataReader dr = cmd.ExecuteReader())
            //{
            //    while (dr.Read())
            //    {
            //        originId = (dr[0]).ToString();
            //    }
            //}
            sqlConnection.Close();




            //step 2: copy the line and all its info (maatregel, ribo, koppeltabel menus)





            //hier alle koppeltabellen kopieren



            //SqlCommand cmd = new SqlCommand("SELECT GevaarOriginID FROM TableGevaarMulti " +
            //                              "WHERE TableGevaarMulti.GevaarID = '" + mainGevaarId + "'", sqlConnection);


            List<int> GevaarDisciplines = this.GetGevaar_DisciplinesList(mainGevaarId);
            List<int> GevaarGebruiksfase = this.GetGevaar_GebruiksfaseList(mainGevaarId);
            List<int> GevaarBedienvorm = this.GetGevaar_BedienvormList(mainGevaarId);
            List<int> GevaarGebruiker = this.GetGevaar_GebruikerList(mainGevaarId);
            List<int> GevaarGevaarlijkeZone = this.GetGevaar_GevaarlijkeZoneList(mainGevaarId);
            List<int> GevaarTaak = this.GetGevaar_TaakList(mainGevaarId);
            List<int> GevaarGevaarType = this.GetGevaar_GevaarTypeList(mainGevaarId);
            List<int> GevaarGevolg = this.GetGevaar_GevolgList(mainGevaarId);

            //hieronder staat de foreach voor elke koppeltabel te inserten.
            #region koppeltabel duplicatie

            if (GevaarDisciplines.Count > 0)
            {
                foreach (int id in GevaarDisciplines)
                {
                    this.AddGevaar_Disciplines(finalId, id);
                }
            }
            else
            { this.AddGevaar_Disciplines(finalId, null); }



            if (GevaarGebruiksfase.Count > 0)
            {
                foreach (int id in GevaarGebruiksfase)
                {
                    this.AddGevaar_Gebruiksfase(finalId, id);
                }
            }
            else
            { this.AddGevaar_Gebruiksfase(finalId, null); }


            if (GevaarBedienvorm.Count > 0)
            {
                foreach (int id in GevaarBedienvorm)
                {
                    this.AddGevaar_Bedienvorm(finalId, id);
                }
            }
            else
            { this.AddGevaar_Bedienvorm(finalId, null); }


            if (GevaarGebruiker.Count > 0)
            {
                foreach (int id in GevaarGebruiker)
                {
                    this.AddGevaar_Gebruiker(finalId, id);
                }
            }
            else
            { this.AddGevaar_Gebruiker(finalId, null); }


            if (GevaarGevaarlijkeZone.Count > 0)
            {
                foreach (int id in GevaarGevaarlijkeZone)
                {
                    this.AddGevaar_GevaarlijkeZone(finalId, id);
                }
            }
            else
            { this.AddGevaar_GevaarlijkeZone(finalId, null); }


            if (GevaarTaak.Count > 0)
            {
                foreach (int id in GevaarTaak)
                {
                    this.AddGevaar_Taak(finalId, id);
                }
            }
            else
            { this.AddGevaar_Taak(finalId, null); }


            if (GevaarGevaarType.Count > 0)
            {
                foreach (int id in GevaarGevaarType)
                {
                    this.AddGevaar_GevaarType(finalId, id);
                }
            }
            else
            { this.AddGevaar_GevaarType(finalId, null); }


            if (GevaarGevolg.Count > 0)
            {
                foreach (int id in GevaarGevolg)
                {
                    this.AddGevaar_Gevolg(finalId, id);
                }
            }
            else
            { this.AddGevaar_Gevolg(finalId, null); }


            #endregion koppeltabel duplicatie

            return finalId;
        }






        //wordt gebruikt voor alle ID's van elk menu van een gevaar te getten
        #region get gevaar menus as list

        private List<int> GetGevaar_DisciplinesList(string gevaarID)
        {
            List<int> gevaarDisciplines = new List<int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT DisciplineID FROM Gevaar_Discipline " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarDisciplines.Add(int.Parse((dr[0]).ToString()));
                    }
                }
            }
            sqlConnection.Close();
            return gevaarDisciplines;
        }

        private List<int> GetGevaar_BedienvormList(string gevaarID)
        {
            List<int> gevaarBedienvorm = new List<int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT BedienvormID FROM Gevaar_Bedienvorm " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarBedienvorm.Add(int.Parse((dr[0]).ToString()));
                    }
                }
            }
            sqlConnection.Close();
            return gevaarBedienvorm;
        }

        private List<int> GetGevaar_GebruikerList(string gevaarID)
        {
            List<int> gevaarGebruiker = new List<int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruikerID FROM Gevaar_Gebruiker " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarGebruiker.Add(int.Parse((dr[0]).ToString()));
                    }
                }
            }
            sqlConnection.Close();
            return gevaarGebruiker;
        }

        private List<int> GetGevaar_GebruiksfaseList(string gevaarID)
        {
            List<int> gevaarGebruiksfase = new List<int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruiksfaseID FROM Gevaar_Gebruiksfase " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarGebruiksfase.Add(int.Parse((dr[0]).ToString()));
                    }
                }
            }
            sqlConnection.Close();
            return gevaarGebruiksfase;
        }

        private List<int> GetGevaar_GevaarlijkeZoneList(string gevaarID)
        {
            List<int> gevaarGevaarlijkeZone = new List<int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarlijkeZoneID FROM Gevaar_GevaarlijkeZone " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarGevaarlijkeZone.Add(int.Parse((dr[0]).ToString()));
                    }
                }
            }
            sqlConnection.Close();
            return gevaarGevaarlijkeZone;
        }

        private List<int> GetGevaar_GevaarTypeList(string gevaarID)
        {
            List<int> gevaarType = new List<int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarTypeID FROM Gevaar_GevaarType " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarType.Add(int.Parse((dr[0]).ToString()));
                    }
                }
            }
            sqlConnection.Close();
            return gevaarType;
        }


        private List<int> GetGevaar_GevolgList(string gevaarID)
        {
            List<int> gevaarGevolg = new List<int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevolgID FROM Gevaar_Gevolg " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarGevolg.Add(int.Parse((dr[0]).ToString()));
                    }
                }
            }
            sqlConnection.Close();
            return gevaarGevolg;
        }

        private List<int> GetGevaar_TaakList(string gevaarID)
        {
            List<int> gevaarTaak = new List<int>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TaakID FROM Gevaar_Taak " +
                                            "WHERE GevaarID = '" + gevaarID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    if (!dr.IsDBNull(0))
                    {
                        gevaarTaak.Add(int.Parse((dr[0]).ToString()));
                    }
                }
            }
            sqlConnection.Close();
            return gevaarTaak;
        }



        #endregion get gevaar menus as list




        #endregion duplicateGevaar



        private int InitIssue(string gevaarId, string issueState)
        {

            //deze functie maakt een nieuw gevaar aan met dezelfde data, met als origin de orginele gevaar.
            int newGevaarIdAfterDuplication = this.DuplicateGevaarFromOrigin(gevaarId);






            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableIssues(IssueGevaarID, IssueStatus, IssueOK) VALUES " +
                                                                       "(@IssueGevaarID, @IssueStatus, @IssueOK)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@IssueGevaarID", newGevaarIdAfterDuplication);
            cmd.Parameters.AddWithValue("@IssueStatus", -1);//issueState);
            cmd.Parameters.AddWithValue("@IssueOK", 0);
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
                                                                          "Rest_Se, Rest_Fr, Rest_Pr, Rest_Av, Rest_Cl, Rest_Risico, Rest_Se_Comment, Rest_Fr_Comment, Rest_Pr_Comment, Rest_Av_Comment, Rest_Cl_Comment, Rest_Risico_Comment, Rest_Risico_Ok, RiskColorCode) " +
                                                                          " VALUES " +
                                                                          "(@IssueID, @Init_Se, @Init_Fr, @Init_Pr, @Init_Av, @Init_Cl, @Init_Risico, @Init_Se_Comment, @Init_Fr_Comment, @Init_Pr_Comment, @Init_Av_Comment, @Init_Cl_Comment, @Init_Risico_Comment, " +
                                                                          "@Rest_Se, @Rest_Fr, @Rest_Pr, @Rest_Av, @Rest_Cl, @Rest_Risico, @Rest_Se_Comment, @Rest_Fr_Comment, @Rest_Pr_Comment, @Rest_Av_Comment, @Rest_Cl_Comment, @Rest_Risico_Comment, @Rest_Risico_Ok, @RiskColorCode)" +
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
            cmd.Parameters.AddWithValue("@RiskColorCode", emptyIntFields);

            Int32 risicoBeoordelingID = (Int32)cmd.ExecuteScalar();
            sqlConnection.Close();
            return risicoBeoordelingID;
        }

        public int InitRisicoBeoordelingDuplicate(int issueId, string originalIssueID)
        {

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RisicoBeoordeling(IssueID, Init_Se, Init_Fr, Init_Pr, Init_Av, Init_Cl, Init_Risico, Init_Se_Comment, Init_Fr_Comment, Init_Pr_Comment, Init_Av_Comment, Init_Cl_Comment, Init_Risico_Comment," +
                                                                          " Rest_Se, Rest_Fr, Rest_Pr, Rest_Av, Rest_Cl, Rest_Risico, Rest_Se_Comment, Rest_Fr_Comment, Rest_Pr_Comment, Rest_Av_Comment, Rest_Cl_Comment, Rest_Risico_Comment, Rest_Risico_Ok, RiskColorCode)" +
                                                                          " SELECT '" + issueId + "', Init_Se, Init_Fr, Init_Pr, Init_Av, Init_Cl, Init_Risico, Init_Se_Comment, Init_Fr_Comment, Init_Pr_Comment, Init_Av_Comment, Init_Cl_Comment, Init_Risico_Comment," +
                                                                          " Rest_Se, Rest_Fr, Rest_Pr, Rest_Av, Rest_Cl, Rest_Risico, Rest_Se_Comment, Rest_Fr_Comment, Rest_Pr_Comment, Rest_Av_Comment, Rest_Cl_Comment, Rest_Risico_Comment, Rest_Risico_Ok, RiskColorCode " +
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


        #region add to gevaar
        public void AddGevaar_Disciplines(int gevaarID, int? disciplineID)
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

        public void AddGevaar_Gebruiksfase(int gevaarID, int? gebruiksfaseID)
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

        public void AddGevaar_Bedienvorm(int gevaarID, int? bedienvormID)
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

        public void AddGevaar_Gebruiker(int gevaarID, int? gebruikerID)
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

        public void AddGevaar_GevaarlijkeZone(int gevaarID, int? gevaarlijkeZoneID)
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

        public void AddGevaar_Taak(int gevaarID, int? taakID)
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

        public void AddGevaar_GevaarType(int gevaarID, int? gevaarTypeID)
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

        public void AddGevaar_Gevolg(int gevaarID, int? gevolgID)
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
        #endregion add to gevaar

        #region remove from gevaar
        public void RemoveGevaar_Disciplines(int gevaarID, int disciplineID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Discipline WHERE GevaarID = @GevaarID AND DisciplineID = @DisciplineID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@DisciplineID", disciplineID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void RemoveGevaar_Gebruiksfases(int gevaarID, int gebruiksFaseID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Gebruiksfase WHERE GevaarID = @GevaarID AND GebruiksFaseID = @GebruiksFaseID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GebruiksFaseID", gebruiksFaseID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void RemoveGevaar_Bedienvorm(int gevaarID, int bedienvormID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Bedienvorm WHERE GevaarID = @GevaarID AND BedienvormID = @BedienvormID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@BedienvormID", bedienvormID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void RemoveGevaar_Gebruiker(int gevaarID, int gebruikerID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Gebruiker WHERE GevaarID = @GevaarID AND GebruikerID = @GebruikerID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GebruikerID", gebruikerID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void RemoveGevaar_GevaarlijkeZone(int gevaarID, int gevaarlijkeZoneID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_GevaarlijkeZone WHERE GevaarID = @GevaarID AND GevaarlijkeZoneID = @GevaarlijkeZoneID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GevaarlijkeZoneID", gevaarlijkeZoneID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void RemoveGevaar_Taak(int gevaarID, int taakID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Taak WHERE GevaarID = @GevaarID AND TaakID = @TaakID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@TaakID", taakID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void RemoveGevaar_GevaarType(int gevaarID, int gevaarTypeID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_GevaarType WHERE GevaarID = @GevaarID AND GevaarTypeID = @GevaarTypeID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GevaarTypeID", gevaarTypeID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void RemoveGevaar_Gevolg(int gevaarID, int gevolgID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Gevaar_Gevolg WHERE GevaarID = @GevaarID AND GevolgID = @GevolgID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.Parameters.AddWithValue("@GevolgID", gevolgID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        #endregion remove from gevaar


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
            cmd.ExecuteNonQuery();
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
            ImageHandler imageHandler = new ImageHandler();
            byte[] image = imageHandler.imageToByteArray(Image.FromFile(imageFilePath));
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjectImages(ObjectID, ImageFilePath) VALUES " +
                                                                       "(@ObjectID, @ImageFilePath)", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectID", objectID);
            cmd.Parameters.AddWithValue("@ImageFilePath", image);

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
            ImageHandler imageHandler = new ImageHandler();
            byte[] image = imageHandler.imageToByteArray(Image.FromFile(imageFilePath));
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableIssueImages(IssueID, ImageFilePath) VALUES " +
                                                                       "(@IssueID, @ImageFilePath)", sqlConnection);
            cmd.Parameters.AddWithValue("@IssueID", issueID);
            cmd.Parameters.AddWithValue("@ImageFilePath", image);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        #endregion add to issue

        #region add to template
        public void AddGevaarToTemplate(string templateId, string gevaarID)
        {
            string issueState = "0";
            int issueId = InitIssue(gevaarID, issueState);
            //string gevaarID = FindGevaarID(issueId);
            //List<string> gekoppeldeMaatregelenVanIssue = FindGekoppeldeMaatregelenVanIssue(issueId);

            //int duplicateIssueId = InitIssue(gevaarID);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableTemplateIssues(TemplateID, IssueID) VALUES " +
                                                                       "(@TemplateID, @IssueID) ", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateID", templateId);
            cmd.Parameters.AddWithValue("@IssueID", issueId);

            cmd.ExecuteNonQuery();
            //Int32 issueID = (Int32)cmd.ExecuteScalar();

            sqlConnection.Close();


            int risicoBeoordelingId = InitRisicoBeoordeling(issueId);
            AddRisicoBeoordelingToIssue(risicoBeoordelingId, issueId);

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

        public void VerwijderGekoppeldeMaatregelVanIssue(string issueID, string maatregelID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM TableIssueMaatregelen WHERE IssueID = @IssueID AND MaatregelID = @MaatregelID", sqlConnection);

            cmd.Parameters.AddWithValue("@IssueID", issueID);
            cmd.Parameters.AddWithValue("@MaatregelID", maatregelID);
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
        public void VerwijderGevaarMulti(int gevaarID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM TableGevaarMulti WHERE GevaarID = @GevaarID", sqlConnection);

            cmd.Parameters.AddWithValue("@GevaarID", gevaarID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


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
        public void VerwijderMaatregelMulti(int maatregelID)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM TableMaatregelenMulti WHERE MaatregelID = @MaatregelID", sqlConnection);

            cmd.Parameters.AddWithValue("@MaatregelID", maatregelID);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

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

        public void UpdateRisicoBeoordelingColorValue(int issueID, int colorValue)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE RisicoBeoordeling " +
                                             "SET RiskColorValue = @RiskColorValue" +
                                            " WHERE IssueID = '" + issueID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@RiskColorValue", colorValue);
            cmd.ExecuteNonQuery();

            sqlConnection.Close();

        }

        public void UpdateRisicoBeoordelingWithoutComments(Item item)
        {
            string issueID = item.ItemData.IssueID;
            string init_Se = item.ItemData.Init_Se;
            string init_Fr = item.ItemData.Init_Fr;
            string init_Pr = item.ItemData.Init_Pr;
            string init_Av = item.ItemData.Init_Av;
            string init_Cl = item.ItemData.Init_Cl;
            string init_Risico = item.ItemData.Init_Risico;


            string rest_Se = item.ItemData.Rest_Se;
            string rest_Fr = item.ItemData.Rest_Fr;
            string rest_Pr = item.ItemData.Rest_Pr;
            string rest_Av = item.ItemData.Rest_Av;
            string rest_Cl = item.ItemData.Rest_Cl;
            string rest_Risico = item.ItemData.Rest_Risico;

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

                                 " Rest_Se = @Rest_Se," +
                                 " Rest_Fr = @Rest_Fr," +
                                 " Rest_Pr = @Rest_Pr," +
                                 " Rest_Av = @Rest_Av," +
                                 " Rest_Cl = @Rest_Cl," +
                                 " Rest_Risico = @Rest_Risico," +

                                 " Rest_Risico_Ok = @Rest_Risico_Ok" +
                                 " WHERE IssueID = '" + issueID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@Init_Se", init_Se);
            cmd.Parameters.AddWithValue("@Init_Fr", init_Fr);
            cmd.Parameters.AddWithValue("@Init_Pr", init_Pr);
            cmd.Parameters.AddWithValue("@Init_Av", init_Av);
            cmd.Parameters.AddWithValue("@Init_Cl", init_Cl);
            cmd.Parameters.AddWithValue("@Init_Risico", init_Risico);
            //cmd.Parameters.AddWithValue("@Init_Se_Comment", init_Se_Comment);
            //cmd.Parameters.AddWithValue("@Init_Fr_Comment", init_Fr_Comment);
            //cmd.Parameters.AddWithValue("@Init_Pr_Comment", init_Pr_Comment);
            //cmd.Parameters.AddWithValue("@Init_Av_Comment", init_Av_Comment);
            //cmd.Parameters.AddWithValue("@Init_Cl_Comment", init_Cl_Comment);
            //cmd.Parameters.AddWithValue("@Init_Risico_Comment", init_Risico_Comment);
            cmd.Parameters.AddWithValue("@Rest_Se", rest_Se);
            cmd.Parameters.AddWithValue("@Rest_Fr", rest_Fr);
            cmd.Parameters.AddWithValue("@Rest_Pr", rest_Pr);
            cmd.Parameters.AddWithValue("@Rest_Av", rest_Av);
            cmd.Parameters.AddWithValue("@Rest_Cl", rest_Cl);
            cmd.Parameters.AddWithValue("@Rest_Risico", rest_Risico);
            //cmd.Parameters.AddWithValue("@Rest_Se_Comment", rest_Se_Comment);
            //cmd.Parameters.AddWithValue("@Rest_Fr_Comment", rest_Fr_Comment);
            //cmd.Parameters.AddWithValue("@Rest_Pr_Comment", rest_Pr_Comment);
            //cmd.Parameters.AddWithValue("@Rest_Av_Comment", rest_Av_Comment);
            //cmd.Parameters.AddWithValue("@Rest_Cl_Comment", rest_Cl_Comment);
            //cmd.Parameters.AddWithValue("@Rest_Risico_Comment", rest_Risico_Comment);
            cmd.Parameters.AddWithValue("@Rest_Risico_Ok", rest_Ok);

            cmd.ExecuteNonQuery();
            //Int32 risicoBeoordelingID = (Int32)cmd.ExecuteScalar();
            sqlConnection.Close();
            //return risicoBeoordelingID;
        }

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


        public void UpdateIssueState(string issueID, int newState)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableIssues " +
                                             "SET IssueStatus = @IssueStatus" +
                                            " WHERE IssueID = '" + issueID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@IssueStatus", newState);
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateIssueOk(string issueID, int newState)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableIssues " +
                                             "SET IssueOK = @IssueOK" +
                                            " WHERE IssueID = '" + issueID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@IssueOK", newState);
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateObjectImage(string objectID, string imageFilePath)
        {
            ImageHandler imageHandler = new ImageHandler();
            byte[] image = imageHandler.imageToByteArray(Image.FromFile(imageFilePath));
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableObjectImages " +
                                             "SET ImageFilePath = @ImageFilePath" +
                                            " WHERE ObjectID = '" + objectID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@ImageFilePath", image);
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void UpdateObjectNotes(string objectID, string newText)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableObjectNotes " +
                                             "SET Notes = @Notes" +
                                            " WHERE ObjectID = '" + objectID + "'", sqlConnection);

            cmd.Parameters.AddWithValue("@Notes", newText);
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

        public void UpdateImageToObject(string objectID, string imageFilePath)
        {

            ImageHandler imageHandler = new ImageHandler();

            byte[] image = imageHandler.imageToByteArray(Image.FromFile( imageFilePath));

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableObjectImages " +
                                            "SET ImageFilePath = @ImageFilePath " +
                                            "WHERE ObjectID = @ObjectID", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectID", objectID);
            cmd.Parameters.AddWithValue("@ImageFilePath", image);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }

        #endregion UPDATE



        #region GET REQUESTS FROM DATABASE

        public string GetObjectNotes(string objectID)
        {
            string text = "";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT Notes FROM TableObjectNotes " +
                                            "WHERE TableObjectNotes.ObjectID = '" + objectID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    text = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();



            return text;

        }

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
            String query = "SELECT ObjectNaam, ProjectNaam FROM TableObjecten";
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
                            "WHERE View_ObjectIssues.RisicoID IN (SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "') ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        public SqlDataAdapter GetExportView(string objectID)
        {
            sqlConnection.Open();
            string query = "SELECT * FROM View_ExportObject_IssuesMetMaatregelen " +
                            "WHERE View_ExportObject_IssuesMetMaatregelen.RisicoID IN (SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "') ";

            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        public SqlDataAdapter GetExportViewRWSTemplate(string objectID)
        {
            sqlConnection.Open();
            string query = "SELECT * FROM View_Export_Object_RWS_Template " +
                            "WHERE View_Export_Object_RWS_Template.RisicoID IN (SELECT TableObjectIssues.IssueID FROM TableObjectIssues WHERE TableObjectIssues.ObjectID = '" + objectID + "') ";

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
                            "View_ObjectIssues ON TableObjectIssues.IssueID = View_ObjectIssues.RisicoID " +
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

        public SqlDataAdapter GetMaatregelen()
        {
            sqlConnection.Open();
            String query = "SELECT * FROM View_MaatregelenCompleet";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }


        public SqlDataAdapter GetGlobalGevaren()
        {
            sqlConnection.Open();
            String query = "  SELECT * FROM View_GevarenCompleet WHERE View_GevarenCompleet.GevaarID in (SELECT GevaarID FROM  TableGevaarMulti WHERE GevaarOriginID = -1)";
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
                            "WHERE View_ObjectIssues.RisicoID IN (SELECT TableTemplateIssues.IssueID FROM TableTemplateIssues WHERE TableTemplateIssues.TemplateID = '" + templateID + "') ";


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
        
        public Image GetObjectImage(string objectID)
        {
            Image  i = null;
            ImageHandler imageHandler = new ImageHandler();


            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ImageFilePath FROM TableObjectImages " +
                                            "WHERE TableObjectImages.ObjectID = '" + objectID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var m = (byte[])dr[0];
                     i = imageHandler.byteArrayToImage(m);
                }
            }
            sqlConnection.Close();

            return i;
        }

        public Image GetIssueImage(string issueID)
        {
            Image i = null;
            ImageHandler imageHandler = new ImageHandler();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ImageFilePath FROM TableIssueImages " +
                                            "WHERE TableIssueImages.IssueID = '" + issueID + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    var m = (byte[])dr[0];
                    i = imageHandler.byteArrayToImage(m);
                }
            }
            sqlConnection.Close();

            return i;
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
        public string GetObjectNameById(string objectId)
        {
            string objectNaam = "error";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectNaam FROM TableObjecten " +
                                            "WHERE TableObjecten.ObjectID = '" + objectId + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectNaam = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();
            return objectNaam;
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


        public string GetIssueIdByObjectAndGevaarOriginId(string objectId, string gevaarId)
        {
            string issueId = "null";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("											 SELECT IssueID  FROM TableObjectIssues" +
                                            " WHERE TableObjectIssues.ObjectID = '" + objectId + "' " +
                                            " AND TableObjectIssues.IssueID IN( " + 
                                            " SELECT IssueID FROM TableIssues WHERE IssueGevaarID IN("+ 
                                            " SELECT GevaarID FROM TableGevaarMulti"+
                                            " WHERE GevaarOriginID = '" + gevaarId + "' ) ) ", sqlConnection);

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
        



        //old
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
        public List<string> GetObjectSettings(string objectID)
        {
            List<string> objectSettings = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TableObjectSettings.Risicograaf " +
                                            "FROM TableObjectSettings " +
                                            "WHERE TableObjectSettings.ObjectID = '" + objectID + "' ", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectSettings.Add((dr[0]).ToString());
                    //objectSettings.Add((dr[1]).ToString());
                    //objectSettings.Add((dr[2]).ToString());
                    //objectSettings.Add((dr[3]).ToString());
                }
            }
            sqlConnection.Close();


            return objectSettings;
        }

        public List<string> GetIssuesInfo(string issueID)
        {//Error. moet aan gewerkt worden. verkeerde db table gebruikt
            
            List<string> issueInfo = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT View_ObjectIssues.RisicoID, View_ObjectIssues.GevaarlijkeSituatie, View_ObjectIssues.GevaarlijkeGebeurtenis, View_ObjectIssues.Gevaar " +
                                            "FROM View_ObjectIssues " +
                                            "WHERE View_ObjectIssues.RisicoID = '" + issueID + "' ", sqlConnection);

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

        public Dictionary<string, string> GetObjectIssuesRestRiskOK(string objectID)
        {
            Dictionary<string, string> issueRiskValue = new Dictionary<string, string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_issueRestRisicoOK WHERE View_issueRestRisicoOK.RisicoID" +
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

        public string GetIssueOK(string issueId)
        {
            string issueOK = "-1";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TableIssues.IssueOK " +
                                            "FROM TableIssues WHERE TableIssues.IssueID = '" + issueId + "'", sqlConnection);
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    issueOK = (dr[0]).ToString();
                }
            }
            sqlConnection.Close();
            return issueOK;
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


        //used in the new version of the tool. V2.2
        public List<string> GetGekoppeldeGevarenOriginFromObjectAsList(string objectID)
        {
            List<string> gekoppeldeGevaren = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(" SELECT GevaarOriginID FROM TableGevaarMulti "+
                                            " WHERE GevaarID IN ( "+
                                            " SELECT  IssueGevaarID FROM TableIssues "+
                                            " WHERE TableIssues.IssueID IN ( "+
                                            " SELECT IssueID FROM TableObjectIssues "+
                                            " WHERE ObjectID = '" + objectID + "' ) ) ", sqlConnection);

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


        //old version of methode
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



        

        public List<string> GetGevarenOriginFromIssuesAsList(List<string> selectedIssuesId)
        {
            List<string> gevarenIDs = new List<string>();

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(" SELECT GevaarOriginID FROM TableGevaarMulti " +
                                            " WHERE GevaarID IN( " +
                                            " SELECT IssueGevaarID FROM TableIssues WHERE TableIssues.IssueID IN( " +
                                            string.Join(",", selectedIssuesId) +
                                            " ) )" , sqlConnection);

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





        //old
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

            String query = "SELECT View_ObjectIssues.RisicoID, View_ObjectIssues.GevaarID " +
                                            "FROM View_ObjectIssues " +
                                            "WHERE View_ObjectIssues.GevaarID = '" + gevaarID + "' ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }
        public SqlDataAdapter GetMaatregelenUsage(string maatregelID)
        {
            //List<string> usage = new List<string>();

            sqlConnection.Open();
            String query = "SELECT TableIssueMaatregelen.IssueID, TableIssueMaatregelen.MaatregelID " +
                                            "FROM TableIssueMaatregelen " +
                                            "WHERE TableIssueMaatregelen.MaatregelID = '" + maatregelID + "' ";
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

        //updated in early 2023 for object specific edits
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

        public void AddToGevolgenMenu(string optionToAdd, string objectId)
        {
            string databaseTableName = "Gevolgen";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Gevolg, ObjectID) VALUES " +
                                                                       "(@Gevolg, @ObjectID)", sqlConnection);
            cmd.Parameters.AddWithValue("@Gevolg", optionToAdd);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGevarenzonesMenu(string optionToAdd, string objectId)
        {
            string databaseTableName = "Gevarenzones";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Gevarenzone, ObjectID) VALUES " +
                                                                       "(@Gevarenzone, @ObjectID)", sqlConnection);
            cmd.Parameters.AddWithValue("@Gevarenzone", optionToAdd);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGevaarTypesMenu(string optionToAdd, string objectId)
        {
            string databaseTableName = "GevaarTypes";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(GevaarType, ObjectID) VALUES " +
                                                                       "(@GevaarType, @ObjectID)", sqlConnection);
            cmd.Parameters.AddWithValue("@GevaarType", optionToAdd);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGebruiksfasesMenu(string optionToAdd, string objectId)
        {
            string databaseTableName = "Gebruiksfases";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Gebruiksfase, ObjectID) VALUES " +
                                                                       "(@Gebruiksfase, @ObjectID)", sqlConnection);
            cmd.Parameters.AddWithValue("@Gebruiksfase", optionToAdd);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToGebruikersMenu(string optionToAdd, string objectId)
        {
            string databaseTableName = "Gebruikers";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Gebruiker, ObjectID) VALUES " +
                                                                       "(@Gebruiker, @ObjectID)", sqlConnection);
            cmd.Parameters.AddWithValue("@Gebruiker", optionToAdd);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToDisciplinesMenu(string optionToAdd, string objectId)
        {
            string databaseTableName = "Disciplines";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Discipline, ObjectID) VALUES " +
                                                                       "(@Discipline, @ObjectID)", sqlConnection);
            cmd.Parameters.AddWithValue("@Discipline", optionToAdd);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToBedienvormenMenu(string optionToAdd, string objectId)
        {
            string databaseTableName = "Bedienvormen";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Bedienvorm, ObjectID) VALUES " +
                                                                       "(@Bedienvorm, @ObjectID)", sqlConnection);
            cmd.Parameters.AddWithValue("@Bedienvorm", optionToAdd);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void AddToTakenMenu(string optionToAdd, string objectId)
        {
            string databaseTableName = "Taken";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(Taak, ObjectID) VALUES " +
                                                                       "(@Taak, @ObjectID)", sqlConnection);
            cmd.Parameters.AddWithValue("@Taak", optionToAdd);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);

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


        public Dictionary<int, string> GetGevolgen(string objectId)
        {
            Dictionary<int, string> index_gevolg = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevolgID, Gevolg FROM Gevolgen WHERE ObjectID = -1 OR ObjectID = @ObjectID", sqlConnection);


            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    index_gevolg.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString());
                }
            }
            sqlConnection.Close();
            return index_gevolg;
        }


        public Dictionary<int, string> GetGevarenzones(string objectId)
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevarenzoneID, Gevarenzone FROM Gevarenzones WHERE ObjectID = -1 OR ObjectID = @ObjectID", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectId);

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

        public Dictionary<int, string> GetGevaarTypes(string objectId)
        {
            Dictionary<int, string> index_gevolg = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GevaarTypeID, GevaarType FROM GevaarTypes WHERE ObjectID = -1 OR ObjectID = @ObjectID ORDER BY GevaarType ", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectId);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                { index_gevolg.Add(int.Parse((dr[0]).ToString()), (dr[1]).ToString()); }
            }
            sqlConnection.Close();
            return index_gevolg;
        }

        public Dictionary<int, string> GetGebruiksfases(string objectId)
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruiksfaseID, Gebruiksfase FROM Gebruiksfases WHERE ObjectID = -1 OR ObjectID = @ObjectID ORDER BY Gebruiksfase ", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectId);

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

        public Dictionary<int, string> GetGebruikers(string objectId)
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruikerID, Gebruiker FROM Gebruikers WHERE ObjectID = -1 OR ObjectID = @ObjectID", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectId);

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

        public Dictionary<int, string> GetDisciplines(string objectId)
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT DisciplineID, Discipline FROM Disciplines WHERE ObjectID = -1 OR ObjectID = @ObjectID", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectId);

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

        public Dictionary<int, string> GetBedienvormen(string objectId)
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT BedienvormID, Bedienvorm FROM Bedienvormen WHERE ObjectID = -1 OR ObjectID = @ObjectID", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectId);

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

        public Dictionary<int, string> GetTaken(string objectId)
        {
            Dictionary<int, string> objectTypes = new Dictionary<int, string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TaakID, Taak FROM Taken WHERE ObjectID = -1 OR ObjectID = @ObjectID", sqlConnection);

            cmd.Parameters.AddWithValue("@ObjectID", objectId);

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
            string templateProjectName = "Templates";
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectNaam FROM TableObjecten " +
                                            "WHERE ProjectNaam  = @TemplateProjectName ", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateProjectName", templateProjectName);
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
            string templateProjectName = "Templates";
            List<string> objectTypes = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectNaam FROM TableObjecten WHERE ProjectNaam NOT LIKE @TemplateProjectName", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateProjectName", templateProjectName);
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

        #endregion version1



        #region version2

        //#region get






        #endregion version2







    }
}
