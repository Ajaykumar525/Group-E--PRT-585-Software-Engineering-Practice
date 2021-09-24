using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheatreAdmin.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength =3)]
        public string Name { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string Director { get; set; }
        public string Email { get; set; }

        [Required]
        public string Language { get; set; }

        [Range(1, 100), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
    }
}