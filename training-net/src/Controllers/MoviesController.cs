using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IHtmlLocalizer<MoviesController> _localizer;
        
        public MoviesController(IHtmlLocalizer<MoviesController> localizer)
        {
            this._localizer = localizer;
        }
        // 
        // GET: /HelloWorld/    

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
    }
}
