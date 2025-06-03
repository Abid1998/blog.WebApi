using blog.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace blog.Core.DTOs.CategoriesDtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public string? category_name { get; set; }
        public string? category_slug { get; set; }
        [Required]
        public string? category_meta { get; set; }
        [Required]
        public string? category_description { get; set; }
        public IFormFile? category_image { get; set; }
        [Required]
        public BlogPostStatus status { get; set; }
        public DateOnly? updated_at { get; set; }
        public int? updated_by { get; set; }
        [Required]
        public CategoryTypes category_type { get; set; }
    }
}
