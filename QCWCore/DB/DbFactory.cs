using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCWCore.DB
{
    public class DbFactory
    {
        protected readonly string _connectionString;
        protected IDbConnection _connection;
        public IDbConnection Connection => _connection ?? (_connection = GetOpenConncetion());

        public DbFactory()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Frame_connectionString"].ConnectionString;
        }
        public DbContext GetDbContext()
        {
            return DbContext.Init(Connection as System.Data.Common.DbConnection, commandTimeout: 200);
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
    }
}
