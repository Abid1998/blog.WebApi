using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Core.Entities
{
    public class Gallery
    {
        [Key]
        public int gallery_id { get; set; }
        public string? gallery_img { get; set; }

        // Foreign key to Tutorial
        [Required(ErrorMessage = "can't be blank Tutorial id")]
        public int tutorial_id { get; set; }

        // Navigation property
        [ForeignKey("tutorial_id")]
        public Tutorial? Tutorial { get; set; }

    }
}
