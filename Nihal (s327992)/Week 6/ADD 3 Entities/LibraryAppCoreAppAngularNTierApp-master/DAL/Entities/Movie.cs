using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Movie
    {
        public Int64 MovieId { get; set; }
        public String Movie_Name { get; set; }
        public String Director { get; set; }
        public String Genre { get; set; }
        public String Language { get; set; }
        public decimal Price { get; set; }
    }
}
