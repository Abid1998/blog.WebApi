using blog.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using blog.Core.DTOs.WebStoryPageDtos;
using Microsoft.AspNetCore.Http;

namespace blog.Core.DTOs.WebStoryDtos
{
    public class WebStoryDto
    {
        public int story_id { get; set; }

        [Required]
        public string title { get; set; } = string.Empty;

        public string? slug { get; set; }

        [MaxLength(500)]
        public string? cover_image_url { get; set; }

        public List<WebStoryPage> Pages { get; set; } = new();
    }
}
