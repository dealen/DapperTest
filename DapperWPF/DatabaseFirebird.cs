using Dapper;
using DapperWPF.Models;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DapperWPF
{
    public class DatabaseFirebird
    {
        public DatabaseFirebird()
        {
            Console.WriteLine($"--------");
            Console.WriteLine($"FIREBIRD");
            Console.WriteLine($"--------");
            var _usersMoq = new List<User>
            {
                new User { Firstname = "Jakub", LastName = "Marcickiewicz", Role = "Admin" },
                new User { Firstname = "Andrzej", LastName = "Bufon", Role = "user" },
                new User { Firstname = "Kacper", LastName = "Kasprzak", Role = "user" }
            };

            string sqlQuery = "INSERT INTO Users(Id, Firstname, LastName, UserRole) VALUES(@Id, @FirstName, @LastName, @Role)";
            foreach (var user in _usersMoq)
            {
                int rowsAffected = Connection.Execute(sqlQuery, user);
            }

            var users = Connection.Query<User>("Select * From Users").ToList();

            foreach (var item in users)
            {
                Console.WriteLine($"User: {item.Firstname} {item.LastName}");
            }
        }

        private string _connectionString = 
            "User=kuba;" +
            "Password=kuba111;" +
            "DatabaseFirebird=D:\\!_DEV\\Dapper\\DapperWPF\\dapperTest.fdb;" +
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
