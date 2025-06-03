using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.Core.DTOs.CommentDtos
{
    public class CommentUpdateDto
    {
        public int comment_id { get; set; }
        public string? comment_name { get; set; }
        public string? comment_email { get; set; }
        public string? comment_phone { get; set; }
        public string? comment_url { get; set; }
        public string? comment_message { get; set; }
        public string? comment_reply { get; set; }
        public string? post_id { get; set; }
        public int? status { get; set; }
        public DateOnly? updated_at { get; set; }
        public int? updated_by { get; set; }
    }
}
