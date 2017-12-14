using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperWPF.Models;

namespace DapperWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            var _usersMoq = new List<User>
            {
                new User { Firstname = "Jakub", LastName = "Marcickiewicz", Role = "Admin" },
                new User { Firstname = "Andrzej", LastName = "Bufon", Role = "user" },
                new User { Firstname = "Kacper", LastName = "Kasprzak", Role = "user" },
                //new User { Id = Guid.NewGuid(), Firstname = "Jakub", LastName = "Marcickiewicz", Role = "Admin" },
                //new User { Id = Guid.NewGuid(), Firstname = "Andrzej", LastName = "Bufon", Role = "user" },
            };

            // FIREBIRD

            //var db = new Database();

            //string sqlQuery = "INSERT INTO Users(Id, Firstname, LastName, UserRole) VALUES(@Id, @FirstName, @LastName, @Role)";
            //foreach (var user in _usersMoq)
            //{
            //    int rowsAffected = db.Connection.Execute(sqlQuery, user);
            //}

            //var users = db.Connection.Query<User>("Select * From Users").ToList();

            //foreach (var item in users)
            //{
            //    Console.WriteLine($"User: {item.Firstname} {item.LastName}");
            //}

            // SQLITE
            var db = new DatabaseSQLite();
            var userRepo = db.UserRepository;

            foreach (var item in _usersMoq)
            {
                userRepo.SaveUser(item);
            }
            //var insertUser = new User
            //{
            //    Firstname = "Jan",
            //    LastName = "Nowak",
            //    Role = "User"
            //};
            //userRepo.SaveUser(insertUser);

            //var u = userRepo.GetUser(insertUser.Id);

            //Console.WriteLine($"User: {u.Firstname} {u.LastName}");

            var users = userRepo.GetUsers();
            foreach (var item in users)
            {
                Console.WriteLine($"User: {item.Firstname} {item.LastName}");
            }
        }
    }
}
