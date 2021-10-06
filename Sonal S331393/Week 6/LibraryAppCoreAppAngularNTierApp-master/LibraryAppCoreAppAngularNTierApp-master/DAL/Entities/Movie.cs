﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Movie
    {
        public Int64 MovieID { get; set; } //(PK)
        public String Movie_Name { get; set; }
        public String Director { get; set; }
        public String Language { get; set; }
        public String Price { get; set; }
    }
}
