using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Customer
{
    public class Customer_Pass_Object
    {
        public Int64 CustomerID { get; set; } //(PK)
        public String Customer_Name { get; set; }
        public String Customer_Surname { get; set; }
        public String Contact_Email { get; set; }
        public String Contact_Number { get; set; }

    }
}
