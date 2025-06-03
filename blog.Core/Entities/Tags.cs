using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace blog.Core.Entities
{
    public class Tags
    {
        [Key]
        public int tag_id { get; set; }
        public string? tag_name { get; set; }
        // Foreign key to Tutorial
        [Required(ErrorMessage = "can't be blank Tutorial id")]
        public int tutorial_id { get; set; }

        // Navigation property
        [ForeignKey("tutorial_id")]
        public Tutorial? Tutorial { get; set; }
    }
}
