using Microsoft.AspNetCore.Http;

namespace blog.Core.DTOs.GalleryDtos
{
    public class GalleryAddDto
    {
        public IFormFile? gallery_img { get; set; }

        public string? gallery_img_path { get; set; }
        public int? post_id { get; set; }
    }
}
