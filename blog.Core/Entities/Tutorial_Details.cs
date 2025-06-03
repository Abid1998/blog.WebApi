using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace blog.Core.Entities
{
    public class Tutorial_Details
    {
        [Key]
        public int tutorial_details_id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? tutorial_description { get; set; }

        [Required(ErrorMessage = "can't be blank languages")]
        public string? languages { get; set; }
      
        // Foreign key to Tutorial
        [Required(ErrorMessage = "can't be blank Tutorial id")]
        public int tutorial_id { get; set; }

        // Navigation property
        [ForeignKey("tutorial_id")]
        public Tutorial? Tutorial { get; set; }

    }
}
