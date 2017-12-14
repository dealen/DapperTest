using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperWPF.Models;
using System.IO;
using Dapper;

namespace DapperWPF.Repository
{
    public class SqLiteUserRepository : SqLiteBaseRepository, IUserRepository
    {
        public User GetUser(int id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                User result = connection.Query<User>(
                    @"SELECT Id, Firstname, Lastname, Userrole
                    From Users
                    WHERE Id = @id", new { id }
                    ).FirstOrDefault();
                return result;
            }
        }

        public void SaveUser(User user)
        {
            if (!File.Exists(DbFile)) CreateTable();

            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                connection.Query(
                    //"INSERT INTO Users(Id, Firstname, Lastname, UserRole) Values(@Id, @Firstname, @LastName, @Role);", 
                    "INSERT INTO Users(Firstname, Lastname, UserRole) Values(@Firstname, @LastName, @Role);", 
                    user);
            }
        }

        private static void CreateTable()
        {
            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                connection.Execute(
                        @"CREATE TABLE USERS
                        (
                          ID                                  integer primary key AUTOINCREMENT,
                          FirstName                           varchar(100) not null,
                          LastName                            varchar(100) not null,
                          USERROLE                            varchar(10) not null
                        );"
                    );
            }
        }

        public IEnumerable<User> GetUsers()
        {
            if (!File.Exists(DbFile)) return null;

            using (var connection = SimpleDbConnection())
            {
                connection.Open();
                var result = connection.Query<User>(
                    @"SELECT Id, Firstname, Lastname, Userrole
                    From Users"
                    ).ToList();
                return result;
            }
        }
    }
}
