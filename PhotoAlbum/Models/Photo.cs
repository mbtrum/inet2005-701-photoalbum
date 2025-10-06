using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoAlbum.Models
{
    public class Photo
    {
        // Primary key
        [Display(Name = "Photo Id")]
        public int PhotoId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        // The photo's filename on the server
        public string Filename { get; set; } = string.Empty;

        [Display(Name = "Published")]
        public DateTime PublishDate { get; set; }

        // Navigation Property (code)
        public List<Tag>? Tags { get; set; } //nullable

        // Image file
        [NotMapped]
        [Display(Name = "Photo")]
        public IFormFile? FormFile { get; set; } //nullable
    }
}
