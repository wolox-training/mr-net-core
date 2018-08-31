using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index() =>
        View(UnitOfWork.Movies.GetAll().ToList().ConvertAll(x => { return new MovieViewModel{ ID = x.ID, Title = x.Title, ReleaseDate = x.ReleaseDate, Genre = x.Genre, Price = x.Price }; }));


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
