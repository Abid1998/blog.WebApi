using blog.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


public class Tutorial : Comman
{
    [Key]
    public int tutorial_id { get; set; }

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string tutorial_title { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string tutorial_slug { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string? tutorial_meta { get; set; }

    public string? schedule { get; set; }

    public string? tutorial_image { get; set; }

    [Required]
    public int category_id { get; set; }

    [ForeignKey("category_id")]
    public Categories? Category { get; set; }

    public ICollection<Gallery>? galleries { get; set; }

    public ICollection<Tags>? tags { get; set; }

    public ICollection<Tutorial_Details>? TutorialDetails { get; set; }
}
