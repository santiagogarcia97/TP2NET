using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        const string consKeyDefaultCnnString = "ConnStringLocal";
        private SqlConnection _SqlConn;
        public SqlConnection SqlConn { get => _SqlConn; set => _SqlConn = value; }

        protected void OpenConnection(){
            String connString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;

            SqlConn = new SqlConnection();
            SqlConn.ConnectionString = connString;
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
