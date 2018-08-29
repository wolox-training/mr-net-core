using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using MvcMovies.Models.Views;
using Repositories.Interfaces;
using System.Text.Encodings.Web;

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

        public IActionResult Create()
        {
            return View();
        }

         [HttpPost]
         public IActionResult Create(MovieViewModel mvm)
         {
             UnitOfWork.Movies.Add(mvm);
         }        
    }
}
