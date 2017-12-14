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
