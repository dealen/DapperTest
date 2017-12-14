using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperWPF
{
    public class Database
    {
        private string _connectionString = 
            "User=kuba;" +
            "Password=kuba111;" +
            "Database=D:\\!_DEV\\Dapper\\DapperWPF\\dapperTest.fdb;" +
            "DataSource=localhost;" +
            "Port=3050;" +
            "Dialect=3;" +
            "Charset=NONE;" +
            "Role=;" +
            "Connection lifetime=15;" +
            "Pooling=true;" +
            "MinPoolSize=0;" +
            "MaxPoolSize=50;" +
            "Packet Size=8192;" +
            "ServerType=0";

        private FbConnection _connection = null;
        public FbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new FbConnection(_connectionString);
                    _connection.Open();
                }
                if (_connection.State != System.Data.ConnectionState.Open)
                    _connection.Open();
                return _connection;
            }
        }
    }
}
