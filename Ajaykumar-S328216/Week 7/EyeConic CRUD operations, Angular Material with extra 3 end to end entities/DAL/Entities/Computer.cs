using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Computer
    {
        public Int64 ComputerId { get; set; } //(PK)
        public String ComputerName { get; set; }
        public String Brand { get; set; }
        public String LastUser { get; set; }
    }
}
