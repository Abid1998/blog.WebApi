using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace blog.Core.Entities
{
    public class WebStory:Comman
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int story_id { get; set; }

        [Required]
        [MaxLength(255)]
        public string title { get; set; } = string.Empty;

        public string? slug { get; set; }

        [MaxLength(500)]
        public string? cover_image_url { get; set; }
        public string? schedule {  get; set; }

        public ICollection<WebStoryPage> Pages { get; set; } = new List<WebStoryPage>();

    }
}
