using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCWCore.DB
{
    public class DB_Base
    {
        public IDbConnection connection;
        public DB_Base()
        {
            connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Frame_connectionString"].ConnectionString);
        }

        public DB_Base(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }

        public void Execute(string sql, IDbTransaction transaction = null)
        {
            connection.Execute(sql, transaction);
        }
    }
}
