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

        // END REGION INIT ITEMS

        // START REGION ADD TO OBJECT
        public void AddAndCreateIssueToObject(string objectId, string gevaarId)
        {
            //table objectissues
            //gevaar id, beoordeling id
            int issueId = InitIssue(gevaarId);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjectIssues(ObjectID, IssueID) VALUES " +
                                                                       "(@ObjectID, @IssueID)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);
            cmd.Parameters.AddWithValue("@IssueID", issueId);

            //cmd.Parameters.AddWithValue("@MaatregelID", objectId);
            //cmd.Parameters.AddWithValue("@RisicoInschattingID", gevaarId);

            Int32 issueID = (Int32)cmd.ExecuteScalar();



            //  = cmd.ExecuteScalar();
            //cmd.ExecuteNonQuery();
            sqlConnection.Close();

            int risicoBeoordelingId = InitRisicoBeoordeling(issueId);
            AddRisicoBeoordelingToIssue(risicoBeoordelingId, issueId);

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
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO RisicoBeoordeling(IssueID) VALUES " +
                                                                       "(@IssueID)" +
                                                                       "SELECT CAST(SCOPE_IDENTITY() AS INT)", sqlConnection);
            cmd.Parameters.AddWithValue("@IssueID", issueId);

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


            //Int32 issueID = (Int32)cmd.ExecuteScalar();

            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }






        // END REGION ADD TO OBJECT




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
            String query = "SELECT ProjectID, ProjectNaam, ObjectNaam, ObjectType, ObjectOmschrijving FROM TableObjecten WHERE ProjectID = '" + projectId + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public SqlDataAdapter GetIssues(string objectID)
        {
            //objectNaam = "1";
            //Risico's data
            sqlConnection.Open();
            //String query = "SELECT * FROM TableRisksUsedInProject WHERE UsedInProjectName = '" + ProjectName + "'";
            string query = "SELECT TableGevaren.* FROM TableObjectIssues " +
                " JOIN TableGevaren " +
                "ON TableGevaren.GevaarID IN(" +
                "SELECT TableIssues.IssueGevaarID FROM TableIssues WHERE TableIssues.IssueID = TableObjectIssues.IssueID)" +
                "AND TableObjectIssues.ObjectID = '" + objectID + "' ";
            
            
            //string query2 = "SELECT TableGevaren.* FROM TableObjectIssues " +
            //                    " JOIN TableGevaren " +
            //                         "ON TableObjectIssues.IssueID = TableIssues.IssueGevaarID WHERE TableObjectIssues.ObjectID = '" + objectID + "'" +
            //                         "AND TableObjectIssues.IssueID IN (" +
            //                         "SELECT TableIssueKoppeling.RisicoID FROM TableIssueKoppeling WHERE TableIssueKoppeling.UsedMaatregelID IN (" +
            //                         "SELECT TableMaatregelsUsedInProject.MaatregelID FROM TableMaatregelsUsedInProject WHERE UsedInProjectName = '" + ProjectName + "'))";



            //DIT WORDT LATER GEBRUIKT IN VIEWS


            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

            ////Maatregels data
            //sqlConnection.Open();
            ////query = "SELECT * FROM TableMaatregelsUsedInProject WHERE UsedInProjectName = '" + ProjectName + "'";
            //query = "SELECT TableMaatregels.* FROM TableMaatregelsUsedInProject " +
            //    " JOIN TableMaatregels " +
            //    "ON TableMaatregelsUsedInProject.MaatregelID = TableMaatregels.MaatregelID WHERE UsedInProjectName = '" + ProjectName + "' ";
            //adapter = new SqlDataAdapter(query, sqlConnection);
            //data = new DataTable();
            //adapter.Fill(data);
            //dataGridViewMaatregel.DataSource = data;
            //sqlConnection.Close();

        }

        public SqlDataAdapter GetIssuesFull(string objectID)
        {
            //QUERY IS NOG ERNISTIG FOUT*************************


            sqlConnection.Open();
            //String query = "SELECT * FROM TableRisksUsedInProject WHERE UsedInProjectName = '" + ProjectName + "'";
            string query = "SELECT TableGevaren.*, TableMaatregelen.* , RisicoBeoordeling.*" +
                "FROM TableObjectIssues"+//" FROM TableIssues, TableIssueMaatregelen, TableObjectIssues, TableMaatregelen, TableGevaren, RisicoBeoordeling " +
                " LEFT JOIN TableGevaren " +
                "ON TableGevaren.GevaarID = TableIssues.IssueGevaarID " +//WHERE ObjectID = '" + objectID + "' " +
                "LEFT JOIN TableMaatregelen" +
                "  ON TableMaatregelen.MaatregelID = TableIssuesMaatregelen.MaatregelID " +
                "AND TableIssuesMaatregelen.IssueID = TableIssues.IssueID" + //WHERE ObjectID = '" + objectID + "' " +
                "LEFT JOIN RisicoBeoordeling " +
                "  ON RisicoBeoordeling.IssueID = TableIssues.IssueRisicoBeoordelingID ";//WHERE ObjectID = '" + objectID + "'";
            //DIT WORDT LATER GEBRUIKT IN VIEWS


            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;

        }

        public SqlDataAdapter GetIssueMaatregelen(string objectID, string issueID)
        {
            
            int objectIDInt = int.Parse(objectID);
            int issueIDInt = int.Parse(issueID);
            //objectNaam = "1";
            //Risico's data
            sqlConnection.Open();
            //String query = "SELECT * FROM TableRisksUsedInProject WHERE UsedInProjectName = '" + ProjectName + "'";
            string query = "SELECT TableMaatregelen.* FROM TableIssues " +
                " JOIN TableMaatregelen " +
                "ON TableMaatregelen.MaatregelID IN(" +
                "SELECT TableIssueMaatregelen.MaatregelID FROM TableIssueMaatregelen WHERE TableIssues.IssueGevaarID = '" + issueIDInt + "')";//+
               // " AND TableObjectIssues.ObjectID = '" + objectIDInt + "' " +
               // "AND IssueGevaarID = '" +issueIDInt + "'";
            //DIT WORDT LATER GEBRUIKT IN VIEWS
            //"ON TableGevaren.GevaarID IN(" +
            //    "SELECT TableIssues.IssueGevaarID FROM TableIssues WHERE TableIssues.IssueID = TableObjectIssues.IssueID)" +
            //    "AND TableObjectIssues.ObjectID = '" + objectID + "' ";


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
            String query = "SELECT * FROM TableGevaren";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }


        //END REGION -----GET REQUESTS FROM DATABASE


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






        //      END GET FROM MENUS
        //END REGION MENUS

    }
}
