using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCWCore.DB
{
    public class DBBase : IDisposable
    {
        protected string _connectionString;
        protected IDbConnection _connection;
        public IDbConnection Connection => _connection ?? (_connection = GetOpenConncetion());
        public DBContext DBContext => DBContext.Init(Connection as System.Data.Common.DbConnection, commandTimeout: 200);
        public DBBase()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Frame_connectionString"].ConnectionString;
            _connection = new MySqlConnection(_connectionString);
        }

        public DBBase(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new MySqlConnection(_connectionString);
        }

        public IDbConnection GetOpenConncetion()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public IDbConnection GetClosedConnection()
        {
            var conn = new MySqlConnection(_connectionString);
            if (conn.State != ConnectionState.Closed) throw new InvalidOperationException("should be closed!");
            return conn;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
