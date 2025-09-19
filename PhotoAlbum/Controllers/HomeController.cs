using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PhotoAlbum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // My Home Controller
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // List of 3 photos 


            // Pass the list into the View

            return View();
        }

        public IActionResult Details(int id)
        {

            int photoId = id;

            return View();
        }
    }
}
