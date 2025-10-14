using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhotoAlbum.Data;
using PhotoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Controllers
{
    // restricted access
    [Authorize]
    public class PhotosController : Controller
    {
        private readonly PhotoAlbumContext _context;

        public PhotosController(PhotoAlbumContext context)
        {
            _context = context;
        }        

        // GET: Photos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoId,Title,Description,FormFile")] Photo photo)
        {
            // Set the publish date
            photo.PublishDate = DateTime.Now;

            // Validate form input
            if (ModelState.IsValid)
            {
                //
                // Step 1: save the file (optionally)
                //
                if (photo.FormFile != null)
                {
                    // Create a unique filename using a GUID
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(photo.FormFile.FileName); // e.g. 8D8AC610-566D-4EF0-9C22-186B2A5ED793.jpg

                    // Set the filename from upload file
                    photo.Filename = filename;

                    // Use Path.Combine to get the file path to save file to
                    string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos", filename);    // e.g., C:\Users\... /home/app/                

                    // Save file
                    using(var fileStream = new FileStream(saveFilePath, FileMode.Create))
                    {
                        await photo.FormFile.CopyToAsync(fileStream);
                    }
                }

                //
                // Step 2: save the record in db
                //
                _context.Add(photo);

                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index", "Home");
            }

            return View(photo);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo.FindAsync(id);

            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotoId,Title,Description,Filename,PublishDate,FormFile")] Photo photo)
        {
            if (id != photo.PhotoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //
                // Step 1: save the new file (optionally)
                //
                if(photo.FormFile != null)
                {
                    // 1. Change the filename in photo.Filename

                    // 2. Save the new file

                    // 3. Delete the old file
                }

                //
                // Step 2: save the record
                //

                try
                {
                    _context.Update(photo);
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotoExists(photo.PhotoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            return View(photo);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo
                .FirstOrDefaultAsync(m => m.PhotoId == id);

            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photo = await _context.Photo.FindAsync(id);

            if (photo != null)
            {
                _context.Photo.Remove(photo);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        private bool PhotoExists(int id)
        {
            return _context.Photo.Any(e => e.PhotoId == id);
        }
    }
}
