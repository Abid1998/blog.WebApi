namespace blog.Core.DTOs.CategoriesDtos
{
    public class CategoryDto
    {
        public int category_id { get; set; }
        public string? category_name { get; set; }
        public string? category_slug { get; set; }
        public string? category_meta { get; set; }
        public string? category_description { get; set; }
        public string? category_image { get; set; }
        public string? status { get; set; }
        public string? category_tags { get; set; }
        public DateOnly created_at { get; set; }
        public int created_by { get; set; }
        public string? category_type { get; set; }
        public DateOnly? updated_at { get; set; }
        public int? updated_by { get; set; }
    }
}
