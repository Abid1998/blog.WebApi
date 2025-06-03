using blog.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace blog.Core.DTOs.Tutorial_DetailsDtos
{
    public class Tutorial_DetailsAddDto
    {
        public string? tutorial_description { get; set; }

        [Required]
        public string? languages { get; set; }

        public int tutorial_id { get; set; }
    }
}
