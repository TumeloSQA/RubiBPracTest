using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LearningManagementPortal.DbConnection
{
    public class DbConnect
    {
        public SqlConnection connection;

        public DbConnect()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=TestDB_MaremaneTP;Integrated Security=True");
        }
        public SqlConnection OpenConnection()
        {
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return connection;
        }

        private SqlConnection CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return connection;
        }
    }
}
