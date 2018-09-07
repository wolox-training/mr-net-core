using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models.View
{
    public class MovieGenreViewModel
    {
        public List<Movie> movies;
        public List<SelectListItem> genres;
        public string movieGenre { get; set; }
    }
}
