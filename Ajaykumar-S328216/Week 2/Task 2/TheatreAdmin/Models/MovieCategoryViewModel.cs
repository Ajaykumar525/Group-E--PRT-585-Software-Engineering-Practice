using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TheatreAdmin.Models
{
    public class MovieCategoryViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Categories { get; set; }
        public string MovieCategory { get; set; }
        public string SearchString { get; set; }
    }
}