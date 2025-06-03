using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace blog.Core.Entities
{
    public class WebStoryPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int page_id { get; set; }

        [MaxLength(500)]
        public string? image_url { get; set; }

        [Column(TypeName = "text")]
        public string? text_content { get; set; }

        [ForeignKey("WebStory")]
        public int story_id { get; set; }
        [JsonIgnore]
        public WebStory? WebStory { get; set; }
    }
}
