using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IHtmlLocalizer<MoviesController> _localizer;
        public IHtmlLocalizer<MoviesController> Localizer { get { return this._localizer; } }
        
        public MoviesController(IHtmlLocalizer<MoviesController> localizer)
        {
            this._localizer = localizer;
        }
        
        public IActionResult Index()
        {   
            ViewData["Message"] = Localizer["DescriptionPage"];
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }        
    }
}
