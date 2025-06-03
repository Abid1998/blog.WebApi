using blog.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace blog.Core.DTOs.TutorialDtos
{
    public class TutorialUpdateDto
    {
        [Required]
        public string? tutorial_title { get; set; }

        public string? tutorial_slug { get; set; }

        [Required]
        public string? tutorial_meta { get; set; }

        public IFormFile? tutorial_image { get; set; }

        [NotMapped]
        public string? tutorial_image_path { get; set; }

        [Required]
        public int category_id { get; set; }

        [Required]
        public BlogPostStatus status { get; set; }

        public DateTime? updated_at { get; set; } = DateTime.Now;

        public int? updated_by { get; set; }

        public string? schedule { get; set; }

        public List<IFormFile> galleries { get; set; } = new();

        public List<string> galleries_paths { get; set; } = new();

        public List<string> tutorial_descriptions { get; set; } = new();

        public List<string> languages { get; set; } = new();
        public List<string> tag_name { get; set; } = new();
    }
}
