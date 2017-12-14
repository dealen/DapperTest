using DapperWPF.Models;
using DapperWPF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperWPF
{
    public class DatabaseSQLite
    {
        public DatabaseSQLite()
        {
            Console.WriteLine($"------");
            Console.WriteLine($"SQLITE");
            Console.WriteLine($"------");
            var _usersMoq = new List<User>
            {
                new User { Firstname = "Jakub", LastName = "Marcickiewicz", Role = "Admin" },
                new User { Firstname = "Andrzej", LastName = "Bufon", Role = "user" },
                new User { Firstname = "Kacper", LastName = "Kasprzak", Role = "user" }
            };

            foreach (var item in _usersMoq)
            {
                UserRepository.SaveUser(item);
            }

            var insertUser = new User
            {
                Firstname = "Jan",
                LastName = "Nowak",
                Role = "User"
            };
            UserRepository.SaveUser(insertUser);

            var u = UserRepository.GetUser(insertUser.Id);

            Console.WriteLine($"User: {u.Firstname} {u.LastName}");

            var users = UserRepository.GetUsers();
            foreach (var item in users)
            {
                Console.WriteLine($"User: {item.Firstname} {item.LastName}");
            }
        }

        private SqLiteUserRepository _userRepository;
        public SqLiteUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new SqLiteUserRepository();
                }
                return _userRepository;
            }
        }
    }
}
