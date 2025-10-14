using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoAlbum.Data;
using PhotoAlbum.Models;
using System.Diagnostics;

namespace PhotoAlbum.Controllers
{
    // restricted access
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PhotoAlbumContext _context;
       
        // My Home Controller
        public HomeController(ILogger<HomeController> logger, PhotoAlbumContext context)
        {
            _logger = logger;
            _context = context;
        }
                
        // GET: Photos
        public async Task<IActionResult> Index()
        {
            // Get all photos
            var photos = await _context.Photo
                .OrderByDescending(m => m.PublishDate)
                .ToListAsync();

            return View(photos);
        }

        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // URL is missing the 3rd parameter ID
            if (id == null)
            {
                return NotFound();
            }

            // Get record where PK = id
            var photo = await _context.Photo.FirstOrDefaultAsync(m => m.PhotoId == id);

            // Record not found in the database
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }
    }
}
