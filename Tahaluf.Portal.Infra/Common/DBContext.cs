using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Tahaluf.Portal.Core.Common;

namespace Tahaluf.Portal.Infra.Common
{
    public class DBContext : IDBContext
    {
        private DbConnection _connection;
        private readonly IConfiguration Configuration;
        public DBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(Configuration["ConnectionStrings:DBConnectionString"]);
                    _connection.Open();


                }
                else
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }
    }
}
