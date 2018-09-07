using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Models.View;
using MvcMovie.Models.Views;
using Repositories.Interfaces;

namespace MvcMovie.Controllers
{
    [Authorize]
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

        [HttpGet]
        public IActionResult Index(string movieGenre, string searchString)
        {
            var movies = UnitOfWork.MovieRepository.GetAll().Select(movie =>  new Movie { ID = movie.ID, Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price }).ToList();
            var moviesGenres = (from movie in UnitOfWork.MovieRepository.GetAll() orderby movie.Genre select movie.Genre).ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(movie => movie.Title.Contains(searchString)).ToList();
            }
            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(movie => movie.Genre.Contains(movieGenre)).ToList();
            }
            var movieGenreVM = new MovieGenreViewModel();
            movieGenreVM.genres = moviesGenres.Distinct().Select(genre => new SelectListItem(genre, genre)).ToList();
            movieGenreVM.movies = movies.ToList();
            return View(movieGenreVM);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(MovieViewModel mvm)
        {
            if(ModelState.IsValid)
            {
            var movie = new Movie { ID = mvm.ID ?? default(int), Title = mvm.Title, ReleaseDate = mvm.ReleaseDate, Genre = mvm.Genre, Price = mvm.Price };
            UnitOfWork.MovieRepository.Add(movie);
            UnitOfWork.Complete();
            }
            return View();
        }

        [HttpGet("Edit")]
        public IActionResult Edit(int id)
        {
            var movie = UnitOfWork.MovieRepository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(new MovieViewModel { ID = movie.ID, Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price });
        }

        [HttpPost("Edit")]
        public IActionResult Edit(MovieViewModel mvm)
        {   
            try
            {
                if (ModelState.IsValid)
                {
                    UnitOfWork.MovieRepository.Update(new Movie { ID = mvm.ID ?? default(int), Title = mvm.Title, ReleaseDate = mvm.ReleaseDate, Genre = mvm.Genre, Price = mvm.Price });
                    UnitOfWork.Complete();
                }
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
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            var movie = UnitOfWork.MovieRepository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(new MovieViewModel { ID = movie.ID, Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price });
        }

        [HttpGet("Delete")]
        public IActionResult Delete(int id)
        {
            var movie = UnitOfWork.MovieRepository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(new MovieViewModel { ID = movie.ID, Title = movie.Title, ReleaseDate = movie.ReleaseDate,Genre = movie.Genre, Price = movie.Price });  
        }

        [HttpPost("DeleteConfirmation")]
        public IActionResult DeleteConfirmation(MovieViewModel mvm)
        {
            UnitOfWork.MovieRepository.Remove(UnitOfWork.MovieRepository.Get(mvm.ID ?? default(int)));
            UnitOfWork.Complete();
            return RedirectToAction("Index", "Movies");
        }
    }
}
