using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RiskManagmentTool.DataLayer
{
    class DatabaseCommunication
    {
        SqlConnection sqlConnection;
        public DatabaseCommunication()
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            sqlConnection = new SqlConnection(databaseConnection.GetConnectionString());


        }

        private void CommunicateToDatabase(string input)
        {
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TableTemplatesList(TemplateID,TemplateType,TemplateName) VALUES " +
                                                                       "(@TemplateID,@TemplateType,@TemplateName)", sqlConnection);
            cmd.Parameters.AddWithValue("@TemplateID", input);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();

        }
    }
}
