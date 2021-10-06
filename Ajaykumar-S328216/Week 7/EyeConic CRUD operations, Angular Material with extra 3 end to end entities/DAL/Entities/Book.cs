using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Book
    {
        public Int64 BookId { get; set; }
        public String Name { get; set; }
        public String Category { get; set; }
        public Int32 Code { get; set; }
    }
}
