using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Movie> movies;
        public SelectListItem genres;
        public string movieGenre { get; set; }
    }
}