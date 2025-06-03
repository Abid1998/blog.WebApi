using Microsoft.AspNetCore.Http;

namespace blog.Core.DTOs.WebStoryPageDtos
{
    public class WebStoryPageAddDto
    {
        public IFormFile? image_url { get; set; }
        public string? text_content { get; set; }
    }
}
