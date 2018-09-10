using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models.Views;
using System.Collections.Generic;

namespace MvcMovie.Models.View
{
    public class MovieCommentModel
    {
        public Movie movie;
        public List<CommentViewModel> comments;
    }
}