using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Movie
{
    public class Movie_ResultSet
    {
        public Int64 Movie_id { get; set; }
        public String name { get; set; }
        public String Director { get; set; }
        public String Genre { get; set; }
        public String Language { get; set; }
        public decimal Price { get; set; }
    }
}

