using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RiskManagmentTool.DataLayer;

namespace RiskManagmentTool.LogicLayer
{
    class Datacomunication
    {
        private DatabaseCommunication databaseCommunication;
        public Datacomunication()
        {
            databaseCommunication = new DatabaseCommunication();
        }
        public DataTable getTable()
        {
            SqlDataAdapter adapter = databaseCommunication.GetMaatregelen();
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
            //dataGridViewMaatregels.DataSource = data;
            
        }
    }
}
