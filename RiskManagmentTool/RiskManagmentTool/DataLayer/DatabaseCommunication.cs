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
            string projectNaam = item.ItemData.ProjectNaam;
            string objectNaam = item.ItemData.ObjectNaam;
            string objectType = item.ItemData.ObjectType;
            string objectOmschrijving = item.ItemData.ObjectOmschrijving;
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableObjecten(ProjectNaam, ObjectNaam, ObjectType, ObjectOmschrijving) VALUES " +
                                                                       "(@ProjectNaam, @ObjectNaam, @ObjectType, @ObjectOmschrijving)", sqlConnection);
            cmd.Parameters.AddWithValue("@ProjectNaam", projectNaam);
            cmd.Parameters.AddWithValue("@ObjectNaam", objectNaam);
            cmd.Parameters.AddWithValue("@ObjectType", objectType);
            cmd.Parameters.AddWithValue("@ObjectOmschrijving", objectOmschrijving);


            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // END REGION INIT ITEMS


        // START REGION -----------GET REQUESTS FROM DATABASE

        public SqlDataAdapter GetProjecten()
        {
            sqlConnection.Open();
            String query = "SELECT ProjectNaam FROM TableProjecten";
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

        public SqlDataAdapter GetObjectenFromProject(string projectNaam)
        {
            sqlConnection.Open();
            String query = "SELECT ProjectNaam, ObjectNaam, ObjectType, ObjectOmschrijving FROM TableObjecten WHERE ProjectNaam = '" + projectNaam + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }


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
        public void AddToMenu(string menuTitel, string optionToAdd)
        {


            string databaseTableName = "ObjectTypes";
            
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO " + databaseTableName + "(ObjectType) VALUES " +
                                                                       "(@ObjectType)", sqlConnection);
            //cmd.Parameters.AddWithValue("@ProjectNaam", projectNaam);
            cmd.Parameters.AddWithValue("@ObjectType", optionToAdd);


            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }































        public SqlDataAdapter GetTemplates()
        {
            sqlConnection.Open();
            String query = "SELECT * FROM TableTemplatesList";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            sqlConnection.Close();
            return adapter;
        }

        public List<string> GetGekoppeldeObjecten()
        {
            List<string> objectNamen = new List<string>();
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT ObjectNaam FROM TableProjectenLijst", sqlConnection);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    objectNamen.Add((dr[0]).ToString());
                }
            }
            sqlConnection.Close();
            return objectNamen;
        }

        public SqlDataAdapter GetIssues(string objectNaam)
        {
            //Risico's data
            sqlConnection.Open();
            //String query = "SELECT * FROM TableRisksUsedInProject WHERE UsedInProjectName = '" + ProjectName + "'";
            String query = "SELECT TableRisicos.* FROM TableRisksUsedInProject " +
                " JOIN TableRisicos " +
                "ON TableRisksUsedInProject.RisicoID = TableRisicos.RiskID WHERE UsedInProjectName = '" + objectNaam + "' ";


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

        public SqlDataAdapter GetMaatregelen()
        {
            
            sqlConnection.Open();
            String query = "SELECT * FROM TableMaatregels";
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
            //DataTable data = new DataTable();
            //adapter.Fill(data);
            //SqlCommand cmd = new SqlCommand("INSERT INTO TableTemplatesList(TemplateID,TemplateType,TemplateName) VALUES " +
            //                                                           "(@TemplateID,@TemplateType,@TemplateName)", sqlConnection);
            //cmd.Parameters.AddWithValue("@TemplateID", input);

           // cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return adapter;

        }
    }
}
