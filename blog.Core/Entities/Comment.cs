
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blog.Core.Entities
{
    public class Comment:Comman
    {
        [Key]
        public int comment_id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? comment_name { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? comment_email { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string? comment_phone { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? comment_url { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string? comment_message { get; set; }

        [Column(TypeName = "varchar(300)")]
        public string? comment_reply { get; set; }

        [Required(ErrorMessage = "can't blank tutorial id")]
        public int? tutorial_id { get; set; }

    }
}
