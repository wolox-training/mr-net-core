using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models.Views;
using MvcMovies.PaginatedList;
using System.Collections.Generic;

namespace MvcMovie.Models.View
{
    public class MovieGenreViewModel
    {
        public List<MovieViewModel> movies;
        public List<SelectListItem> genres;
        public string movieGenre { get; set; }
        public PaginatedList<MovieViewModel> MovieList { get; set; }
    }
}
