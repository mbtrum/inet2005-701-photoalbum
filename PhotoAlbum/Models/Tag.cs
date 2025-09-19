using System.Numerics;

namespace PhotoAlbum.Models
{
    public class Tag
    {
        // Primary key
        public int TagId { get; set; }

        public string Title { get; set; } = string.Empty;

        // Foreign key (database)
        public int PhotoId { get; set; }

        // Navigation Property (code)
        public Photo? Photo { get; set; }

    }
}
