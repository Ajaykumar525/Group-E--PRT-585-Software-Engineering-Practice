using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Customer
{
    public class Customer_ResultSet
    {
        public Int64 CustomerID { get; set; } //(PK)
        public String Customer_Name { get; set; }
        public String Customer_Surname { get; set; }
        public String Contact_Email { get; set; }
        public String Contact_Number { get; set; }
    }
}
