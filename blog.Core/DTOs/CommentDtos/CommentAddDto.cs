namespace blog.Core.DTOs.CommentDtos
{
    public class CommentAddDto
    {
        public string? comment_name { get; set; }
        public string? comment_email { get; set; }
        public string? comment_phone { get; set; }
        public string? comment_url { get; set; }
        public string? comment_message { get; set; }
        public string? comment_reply { get; set; }
        public string? post_id { get; set; }
        public int? status { get; set; }
        public DateOnly created_at { get; set; }
        public int created_by { get; set; }
    }
}
