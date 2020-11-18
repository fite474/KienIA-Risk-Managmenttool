using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace RiskManagmentTool.DataLayer
{
    class DatabaseConnection
    {
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=MSI-MAURICE;Initial Catalog=ProtoTypeProject;User ID=Maurice;Password=6776756");
        public SqlConnection sqlConnection;// = new SqlConnection(DatabaseComunication.);

        public DatabaseConnection()
        {
            //maak check op het verlopen van een wachtwoord
            sqlConnection = new SqlConnection(@"Data Source=MSI-MAURICE;Initial Catalog=KRMTVersionOne;User ID=Maurice;Password=6776756mb");


        }

        public string GetConnectionString()
        {
            string connectionString = @"Data Source=MSI-MAURICE;Initial Catalog=KRMTVersionOne;User ID=Maurice;Password=6776756mb";
            return connectionString;
        }


    }
}
