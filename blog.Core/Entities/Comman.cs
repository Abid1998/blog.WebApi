using blog.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

public class Comman
{
    [Column(TypeName = "varchar(20)")]
    public BlogPostStatus status { get; set; }

    public DateOnly created_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public int created_by { get; set; }

    public DateOnly? updated_at { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public int? updated_by { get; set; }
}
