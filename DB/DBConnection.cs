using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PharmaCO_MVC.DB
{
    public class DBConnection
    {
        public SqlConnection cnn;

        public DBConnection()
        {
            if ((cnn = _cnn()) == null)
            {
                this.Dispose();
            }
        }

        private SqlConnection _cnn()
        {
            SqlConnection conn = null;
            string server = ConfigurationManager.AppSettings["Server"];
            string db = ConfigurationManager.AppSettings["DataBase"];

            var cnnString = string.Format("Server={0};Database={1};Trusted_Connection=True;", server, db);
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = cnnString;
                conn.Open();
                return conn;
            }
            catch
            {
                conn.Dispose();
                return null;
            }
        }
        public void Dispose()
        {
            if (cnn != null)
            {
                cnn.Dispose();
            }
        }
    }
}