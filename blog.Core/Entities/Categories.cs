using blog.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Core.Entities
{
    public class Categories : Comman
    {
        [Key]
        public int category_id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? category_name { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string? category_slug { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? category_meta { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? category_description { get; set; }
        public string? category_image { get; set; }

        public string? category_tags { get; set; }

        [Column(TypeName = "varchar(20)")]
        public CategoryTypes category_type { get; set; }

    }
}
