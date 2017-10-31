using Dapper;
using MySql.Data.MySqlClient;
using QCWService.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCService.Interceptor;
using Autofac.Extras.DynamicProxy;

namespace QCWService.Infrastructure
{
    public class FrameContext : Database<FrameContext>, IUnitOfWork
    {
        protected readonly string _connectionString;
        protected IDbConnection _connection;
        public IDbConnection Connection => _connection ?? (_connection = GetOpenConncetion());
        public Table<dynamic> FrameUser { get; set; }

        public FrameContext()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Frame_connectionString"].ConnectionString;
        }

        public FrameContext Init()
        {
            return Init(Connection as System.Data.Common.DbConnection, commandTimeout: 200);
        }

        public IDbConnection GetOpenConncetion()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
