using blog.Core.DTOs.GalleryDtos;
using blog.Core.DTOs.TagsDtos;
using blog.Core.DTOs.Tutorial_DetailsDtos;

namespace blog.Core.DTOs.TutorialDtos
{
    public class TutorialDto
    {
        public int tutorial_id { get; set; }
        public string? tutorial_title { get; set; }
        public string? tutorial_slug { get; set; }
        public string? tutorial_meta { get; set; }
        public string? tutorial_image { get; set; }
        public int category_id { get; set; }
        public int? status { get; set; }
        public DateOnly created_at { get; set; }
        public int created_by { get; set; }
        public DateOnly? updated_at { get; set; }

        public string? schedule { get; set; }

        public int? updated_by { get; set; }
     
        public ICollection<GalleryDto>? Galleries { get; set; }
        public ICollection<TagsDto>? Tags { get; set; }
        public ICollection<Tutorial_DetailsDto>? Tutorial_Details { get; set; }

    }
}
