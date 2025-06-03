using System.ComponentModel.DataAnnotations;
using blog.Core.Entities;
using blog.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace blog.Core.DTOs
{
    public class WebStoryUpdateDto
    {
        [Required]
        public string title { get; set; } = string.Empty;
        public string? slug { get; set; }
        public IFormFile? cover_image { get; set; }  // ✅ No [MaxLength] here
        [Required]
        public BlogPostStatus status { get; set; }
        public int? updated_by { get; set; }
        public string? schedule { get; set; }
        public int story_id { get; set; }
        public List<IFormFile>? images { get; set; } // ✅ No [MaxLength]
        public List<string>? text_content { get; set; }

    }
}
