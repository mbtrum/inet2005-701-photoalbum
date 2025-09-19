using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.Models;

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
            List<Photo> photos = new List<Photo>();

            // Create 2 photos
            Photo photo1 = new Photo();
            photo1.PhotoId = 1;
            photo1.Title = "Penny";
            photo1.Description = "My cat Penny, loves sitting in the window sill";
            photo1.Filename = "penny.jpg";
            photo1.PublishDate = DateTime.Now;

            Photo photo2 = new Photo();
            photo2.PhotoId = 2;
            photo2.Title = "Audrey";
            photo2.Description = "My pug Audrey loves sleeping on the couch.";
            photo2.Filename = "audrey.jpg";
            photo2.PublishDate = DateTime.Now;

            photos.Add(photo1);
            photos.Add(photo2);

            _logger.Log(LogLevel.Information, "Number of photos: " +  photos.Count);

            // Pass the list into the View

            return View(photos);
        }

        public IActionResult Details(int id)
        {
            int photoId = id;

            return View();
        }
    }
}
