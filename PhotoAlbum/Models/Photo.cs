namespace PhotoAlbum.Models
{
    public class Photo
    {
        // Primary key
        public int PhotoId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // The photo's filename on the server
        public string Filename { get; set; } = string.Empty;

        public DateTime PublishDate { get; set; }

        // Navigation Property (code)
        public List<Tag>? Tags { get; set; }
    }
}
