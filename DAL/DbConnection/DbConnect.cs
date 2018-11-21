using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbConnection
{
    public class DbConnect
    {
        public SqlConnection connection;

        public DbConnect()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=TestDB_Tumelo;Integrated Security=True");
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
