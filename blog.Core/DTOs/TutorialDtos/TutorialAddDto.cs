using blog.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class TutorialAddDto
{
    [Required]
    public string? tutorial_title { get; set; }

    public string? tutorial_slug { get; set; }

    [Required]
    public string? tutorial_meta { get; set; }

    public IFormFile? tutorial_image { get; set; }

    [Required]
    public int category_id { get; set; }

    public string? schedule { get; set; }

    [Required]
    public BlogPostStatus status { get; set; }

    public DateOnly created_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required]
    public int created_by { get; set; }

    public List<IFormFile> galleries { get; set; } = new();

    public List<string> tutorial_descriptions { get; set; } = new();
    public List<string> languages { get; set; } = new();

    public List<string> tag_name { get; set; } = new();
}
