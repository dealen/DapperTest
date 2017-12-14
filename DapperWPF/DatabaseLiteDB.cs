using DapperWPF.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperWPF
{
    public class DatabaseLiteDB
    {
        public DatabaseLiteDB()
        {
            Console.WriteLine($"------");
            Console.WriteLine($"LITEDB");
            Console.WriteLine($"------");
            var usersLiteDb = new List<Users2>
            {
                new Users2 { Id = Guid.NewGuid(), Firstname = "Jakub", LastName = "Marcickiewicz", Role = "Admin" },
                new Users2 { Id = Guid.NewGuid(), Firstname = "Andrzej", LastName = "Bufon", Role = "user" },
            };

            var lite = new LiteDatabase("liteDb.db");
            var users = lite.GetCollection<Users2>("users");

            Console.WriteLine("--");
            foreach (var item in usersLiteDb)
            {
                users.Insert(item);
            }
            Console.WriteLine("--");
            foreach (var item in users.FindAll())
            {
                Console.WriteLine($"User: {item.Firstname} {item.LastName}");
            }

            var user = users.FindOne(x => x.Firstname == "Jakub");
            user.Firstname = "Kuba";
            users.Update(user);

            Console.WriteLine("--");
            foreach (var item in users.FindAll())
            {
                Console.WriteLine($"User: {item.Firstname} {item.LastName}");
            }
        }
    }
}
