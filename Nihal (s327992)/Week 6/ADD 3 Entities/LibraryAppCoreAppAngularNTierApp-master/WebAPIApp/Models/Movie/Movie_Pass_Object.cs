using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Models.Movie
{
    public class Movie_Pass_Object
    {
        public Int64 Movie_id { get; set; }
        public String name { get; set; }
        public String Director { get; set; }
        public String Genre { get; set; }
        public String Language { get; set; }
        public decimal Price { get; set; }
    }
}
