using System;

namespace LOGIC.Services.Models.Computer
{
    public class Computer_ResultSet
    {
        public Int64 ComputerId { get; set; } //(PK)
        public String ComputerName { get; set; }
        public String Brand { get; set; }
        public String LastUser { get; set; }
    }
}
