using blog.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace blog.Core.DTOs.WebStoryDtos
{
    public class WebStoryAddDto
    {
        [Required]
        public string? title { get; set; }
        public string? slug { get; set; }
        public IFormFile? cover_image_url { get; set; }
        public string? schedule { get; set; }
        [Required]
        public BlogPostStatus status { get; set; }
        public DateOnly created_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        [Required]
        public int created_by { get; set; }

        public List<IFormFile>? images { get; set; }

        public List<string>? text_content { get; set; }
    }
}
