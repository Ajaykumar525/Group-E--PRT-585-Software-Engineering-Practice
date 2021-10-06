using System;

namespace LOGIC.Services.Models.Movie
{
    public class Movie_ResultSet
    {
        public Int64 movie_id { get; set; }
        public String name { get; set; }
        public String Director { get; set; }
        public String Language { get; set; }
        public String Price { get; set; }
    }
}