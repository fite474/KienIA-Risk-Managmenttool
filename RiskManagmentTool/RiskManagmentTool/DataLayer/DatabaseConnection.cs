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
       
        public SqlConnection sqlConnection;

        public DatabaseConnection()
        {
            //maak check op het verlopen van een wachtwoord
            //sqlConnection = new SqlConnection(@"Data Source=MSI-MAURICE;Initial Catalog=KRMTVersionOne;User ID=Maurice;Password=6776756mb");
            sqlConnection = new SqlConnection(@"Data Source=Kienia.database.windows.net;Initial Catalog=KRMTVersionOne;User ID=TestRobert;Password=Robert-1234");


        }

        public string GetConnectionString()
        {
            //not in use!
            string connectionString = @"Data Source=MSI-MAURICE;Initial Catalog=KRMTVersionOne;User ID=Maurice;Password=6776756mb";
            return connectionString;
        }


    }
}
