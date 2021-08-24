using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheatreAdmin.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}