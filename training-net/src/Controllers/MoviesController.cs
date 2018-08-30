using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
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
        View(UnitOfWork.MovieRepository.GetAll().Select(movie =>  new MovieViewModel { ID = movie.ID, Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price }).ToList());

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(MovieViewModel mvm)
        {
            var movie = new Movie { ID = mvm.ID, Title = mvm.Title, ReleaseDate = mvm.ReleaseDate, Genre = mvm.Genre, Price = mvm.Price };
            UnitOfWork.MovieRepository.Add(movie);
            UnitOfWork.Complete();
            return View();
            
        }

        public IActionResult Edit(int id)
        {
            var movie = UnitOfWork.MovieRepository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(new MovieViewModel { ID = movie.ID, Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price });
        }

        [HttpPost]
        public IActionResult Edit(MovieViewModel mvm)
        {   
            try
            {
                UnitOfWork.MovieRepository.Update(new Movie { ID = mvm.ID, Title = mvm.Title, ReleaseDate = mvm.ReleaseDate, Genre = mvm.Genre, Price = mvm.Price });
                UnitOfWork.Complete();     
            }
            catch(DbUpdateConcurrencyException)
            {
                if (mvm == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index","Movies");
        }
    }
}
