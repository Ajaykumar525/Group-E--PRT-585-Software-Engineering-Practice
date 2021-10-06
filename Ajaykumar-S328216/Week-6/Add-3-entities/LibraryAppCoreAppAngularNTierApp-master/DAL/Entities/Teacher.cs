using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Teacher
    {
        public Int64 TeacherId { get; set; }
        public String Name { get; set; }
        public Int32 Experience { get; set; }
    }
}
