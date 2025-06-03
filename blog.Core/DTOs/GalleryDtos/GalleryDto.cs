using Microsoft.AspNetCore.Http;

namespace blog.Core.DTOs.GalleryDtos
{
    public class GalleryDto
    {
        public int gallery_id { get; set; }
        public string? gallery_img { get; set; }
        public int? tutorial_id { get; set; }
    }
}
