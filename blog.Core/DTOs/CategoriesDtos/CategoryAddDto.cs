using blog.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace blog.Core.DTOs.CategoriesDtos
{
    public class CategoryAddDto
    {
        [Required]
        public string? category_name { get; set; }
        public string? category_slug { get; set; }
        [Required]
        public string? category_meta { get; set; }
        [Required]
        public string? category_description { get; set; }
        public IFormFile? category_image { get; set; }
        public string? category_tags { get; set; }
        [Required]
        public BlogPostStatus status { get; set; }
        public DateOnly created_at { get; set; }
        public int created_by { get; set; }
        [Required]
        public CategoryTypes category_type { get; set; }
    }
}
