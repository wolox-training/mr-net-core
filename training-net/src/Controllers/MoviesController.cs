using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using MvcMovie.Models;
using MvcMovies.Models.Views;
using Repositories.Interfaces;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IHtmlLocalizer<MoviesController> _localizer;
        private readonly IUnitOfWork _unitOfWork;
        public IHtmlLocalizer<MoviesController> Localizer { get { return this._localizer; } }
        public IUnitOfWork UnitOfWork { get { return this._unitOfWork; } }
        public MoviesController(IHtmlLocalizer<MoviesController> localizer, IUnitOfWork unitOfWork)
        {
            this._localizer = localizer;
            this._unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {   
            ViewData["Message"] = Localizer["DescriptionPage"];
            return View();
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(MovieViewModel mvm)
        {
            var movie = new Movie { ID = mvm.ID, Title = mvm.Title, ReleaseDate = mvm.ReleaseDate, Genre = mvm.Genre, Price = mvm.Price };
            UnitOfWork.Movies.Add(movie);
            UnitOfWork.Complete();
            return View();
        }        
    }
}
