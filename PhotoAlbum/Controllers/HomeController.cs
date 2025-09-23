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
            // List of 2 photos 
            List<Photo> photos = new List<Photo>();

            // Create 2 photos
            Photo photo1 = new Photo();
            photo1.PhotoId = 1;
            photo1.Title = "Penny";
            photo1.Description = "My cat Penny, loves sitting in the window sill";
            photo1.Filename = "penny.jpg";
            photo1.PublishDate = new DateTime(2020, 12, 20);

            Photo photo2 = new Photo();
            photo2.PhotoId = 2;
            photo2.Title = "Audrey";
            photo2.Description = "My pug Audrey loves sleeping on the couch.";
            photo2.Filename = "audrey.jpg";
            photo2.PublishDate = new DateTime(2024, 09, 30, 9, 30, 0);

            photos.Add(photo1);
            photos.Add(photo2);

            _logger.Log(LogLevel.Information, "Number of photos: " +  photos.Count);

            // Pass the list into the View

            return View(photos);
        }

        public IActionResult Details(int id)
        {
            int photoId = id;

            Photo photo = new Photo();
            photo.PhotoId = photoId;

            if (photo.PhotoId == 1)
            {
                photo.Title = "Penny";
                photo.Description = "My cat Penny, loves sitting in the window sill";
                photo.Filename = "penny.jpg";
                photo.PublishDate = new DateTime(2020, 12, 20);
            }
            else
            {
                photo.Title = "Audrey";
                photo.Description = "My pug Audrey loves sleeping on the couch.";
                photo.Filename = "audrey.jpg";
                photo.PublishDate = new DateTime(2024, 09, 30, 9, 30, 0);
            }

            return View(photo);
        }
    }
}
