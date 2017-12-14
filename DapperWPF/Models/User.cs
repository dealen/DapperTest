using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperWPF.Models
{
    public class User : IEntity
    {
        //public Guid Id
        //{
        //    get { return new Guid(IdString); }
        //    set { IdString = value.ToString(); }
        //}
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
