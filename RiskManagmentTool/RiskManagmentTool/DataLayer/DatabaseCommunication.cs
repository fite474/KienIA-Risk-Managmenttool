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

        // END REGION INIT ITEMS

        // START REGION ADD TO OBJECT
        public void AddGevaarToObject(string objectId, string gevaarId)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableIssues(ObjectID, IssueGevaarID) VALUES " +
                                                                       "(@ObjectID, @IssueGevaarID)", sqlConnection);
            cmd.Parameters.AddWithValue("@ObjectID", objectId);
            cmd.Parameters.AddWithValue("@IssueGevaarID", gevaarId);

            //cmd.Parameters.AddWithValue("@MaatregelID", objectId);
            //cmd.Parameters.AddWithValue("@RisicoInschattingID", gevaarId);

            var issueID = (int)cmd.ExecuteScalar();
            //cmd.ExecuteNonQuery();
            sqlConnection.Close();
            AddMaatregelToIssue(issueID, 0);

        }

        public void AddMaatregelToIssue(int issueId, int maatregelId)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableIssues " +
                                             "SET MaatregelID = '" + maatregelId + "'" +
                                              "WHERE IssueID = '" + issueId + "'", sqlConnection);
            //cmd.Parameters.AddWithValue("@ObjectID", objectId);
            //cmd.Parameters.AddWithValue("@IssueGevaarID", gevaarId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            AddRisicoInschattingToIssue(issueId, 0);

        }

        public void AddRisicoInschattingToIssue(int issueId, int risicoInschattingId)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TableIssues " +
                                 "SET RisicoInschattingID = '" + risicoInschattingId + "'" +
                                  "WHERE IssueID = '" + issueId + "'", sqlConnection);

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
                "ON TableObjectIssues.IssueID = TableGevaren.GevaarID WHERE ObjectID = '" + objectID + "' ";
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
            //objectNaam = "1";
            //Risico's data
            sqlConnection.Open();
            //String query = "SELECT * FROM TableRisksUsedInProject WHERE UsedInProjectName = '" + ProjectName + "'";
            string query = "SELECT TableGevaren.*, TableMaatregelen.MaatregelNaam, TableMaatregelen.MaatregelCategory,TableMaatregelen.MaatregelNorm, RisicoInschatting.*" +
                " FROM TableObjectIssues " +
                " JOIN TableGevaren " +
                "ON TableObjectIssues.IssueID = TableGevaren.GevaarID " +//WHERE ObjectID = '" + objectID + "' " +
                "LEFT JOIN TableMaatregelen" +
                "  ON TableMaatregelen.MaatregelID = TableIssues.MaatregelID " + //WHERE ObjectID = '" + objectID + "' " +
                "LEFT JOIN RisicoInschatting " +
                "  ON RisicoInschatting.IssueID = TableIssues.RisicoInschattingID ";//WHERE ObjectID = '" + objectID + "'";
            //DIT WORDT LATER GEBRUIKT IN VIEWS


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
