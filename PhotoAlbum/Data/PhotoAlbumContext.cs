using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoAlbum.Models;

namespace PhotoAlbum.Data
{
    public class PhotoAlbumContext : DbContext
    {
        public PhotoAlbumContext (DbContextOptions<PhotoAlbumContext> options)
            : base(options)
        {
        }

        public DbSet<PhotoAlbum.Models.Photo> Photo { get; set; } = default!;
        public DbSet<PhotoAlbum.Models.Tag> Tag { get; set; } = default!;
    }
}
