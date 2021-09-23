using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Admin
    {
        public Int64 AdminID { get; set; } //(PK)
        public String Admin_Name { get; set; }
    }
}