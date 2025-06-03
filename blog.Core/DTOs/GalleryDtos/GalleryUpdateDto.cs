using Microsoft.AspNetCore.Http;

namespace blog.Core.DTOs.GalleryDtos
{
    public class GalleryUpdateDto
    {
        public IFormFile? gallery_img { get; set; }
        public int? post_id { get; set; }
    }
}
