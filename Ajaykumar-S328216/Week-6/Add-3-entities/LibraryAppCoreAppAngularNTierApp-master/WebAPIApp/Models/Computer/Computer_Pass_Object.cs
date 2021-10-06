using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Computer
{
    public class Computer_Pass_Object
    {
        public Int64 ComputerId { get; set; } //(PK)
        public String ComputerName { get; set; }
        public String Brand { get; set; }
        public String LastUser { get; set; }
    }
}
