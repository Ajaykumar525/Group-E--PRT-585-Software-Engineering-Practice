using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
