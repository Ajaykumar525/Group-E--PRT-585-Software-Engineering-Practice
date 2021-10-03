using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Contracter
    {
        public Int64 ContracterID { get; set; }

        public String Contracter_Name { get; set; }

        public String Contracter_ContactNumber { get; set; }

        public String Contracter_EmailAddress { get; set; }
    }
}
