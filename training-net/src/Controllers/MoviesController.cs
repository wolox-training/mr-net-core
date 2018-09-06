using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovie.Models.View;
using MvcMovie.Models.Views;
using MvcMovies.PaginatedList;
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
        public IActionResult Index(string movieGenre, string searchString, string sortOrder, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = movieGenre;
            ViewData["FilterParm"] = String.IsNullOrEmpty(movieGenre) ? "":"";
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["GenreSortParm"] = sortOrder == "Genre" ? "genre_desc" : "Genre";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = movieGenre;
            }
            int pageSize = 6;
            var movies = UnitOfWork.MovieRepository.GetAll().Select(movie =>  new MovieViewModel { ID = movie.ID, Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price }).ToList();
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
            switch(sortOrder)
            {
                case "title_desc":
                    movieGenreVM.MovieList = PaginatedList<MovieViewModel>.Create(movies.OrderByDescending(movie => movie.Title).ToList(), page ?? 1, pageSize);
                    break;
                case "Date":
                    movieGenreVM.MovieList = PaginatedList<MovieViewModel>.Create(movies.OrderBy(movie => movie.ReleaseDate).ToList(), page ?? 1, pageSize);
                    break;
                case "date_desc":
                    movieGenreVM.MovieList = PaginatedList<MovieViewModel>.Create(movies.OrderByDescending(movie => movie.ReleaseDate).ToList(), page ?? 1, pageSize);
                    break;
                case "Genre":
                    movieGenreVM.MovieList = PaginatedList<MovieViewModel>.Create(movies.OrderBy(movie => movie.Genre).ToList(), page ?? 1, pageSize);
                    break;
                case "genre_desc":
                    movieGenreVM.MovieList = PaginatedList<MovieViewModel>.Create(movies.OrderByDescending(movie => movie.Genre).ToList(), page ?? 1, pageSize);
                    break;
                default:
                    movieGenreVM.MovieList = PaginatedList<MovieViewModel>.Create(movies.OrderBy(movie => movie.Title).ToList(), page ?? 1, pageSize);
                    break;
            }
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
                var movie = new Movie { Title = mvm.Title, ReleaseDate = mvm.ReleaseDate, Genre = mvm.Genre, Price = mvm.Price };
                UnitOfWork.MovieRepository.Add(movie);
                UnitOfWork.Complete();
            }
            return RedirectToAction("Index","Movies");
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
                    UnitOfWork.MovieRepository.Update(new Movie { ID = mvm.ID, Title = mvm.Title, ReleaseDate = mvm.ReleaseDate, Genre = mvm.Genre, Price = mvm.Price });
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
            try
            {
                UnitOfWork.MovieRepository.Remove(UnitOfWork.MovieRepository.Get(mvm.ID));
                UnitOfWork.Complete();
                return RedirectToAction("Index", "Movies");
            }
            catch(DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        [HttpGet("Mail")]
        public IActionResult Mail(int id)
        {
            var movie = UnitOfWork.MovieRepository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(new MovieViewModel { ID = movie.ID, Title = movie.Title, ReleaseDate = movie.ReleaseDate, Genre = movie.Genre, Price = movie.Price });  
        }

        [HttpPost("SendMail")]
        public IActionResult SendMail(MovieViewModel mvm)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("testdontnet@gmail.com", "Dotnet1133");
            client.EnableSsl = true;
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("testdontnet@gmail.com");
            mailMessage.To.Add("testdontnet@gmail.com");
            mailMessage.Body = string.Format("Title: {0} \n Release Date: {1} \n Genre: {2} \n Price {3}".Replace("\n",Environment.NewLine), mvm.Title, mvm.ReleaseDate.ToString(), mvm.Genre, mvm.Price.ToString());
            mailMessage.Subject = "subject";
            client.Send(mailMessage);
            return RedirectToAction("Index", "Movies");
        }
    }
}
