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
        SqlConnection sqlConnection;// = new SqlConnection(DatabaseComunication.);

        public DatabaseConnection()
        {
            
            sqlConnection = new SqlConnection(@"Data Source=MSI-MAURICE;Initial Catalog=ProtoTypeProject;User ID=Maurice;Password=6776756");


        }

        public string GetConnectionString()
        {
            string x = @"Data Source=MSI-MAURICE;Initial Catalog=ProtoTypeProject;User ID=Maurice;Password=6776756";
            return x;
        }

        private int GetObjectX()
        {
            int x = 0;
            return x;

        }
    }
}
