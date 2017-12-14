using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DapperWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            // FIREBIRD
            //var firebird = new DatabaseFirebird();               

            // SQLITE http://blog.maskalik.com/asp-net/sqlite-simple-database-with-dapper/
            var sqLite = new DatabaseSQLite();

            // LiteDB http://www.litedb.org/
            var liteDb = new DatabaseLiteDB();
        }
    }
}
