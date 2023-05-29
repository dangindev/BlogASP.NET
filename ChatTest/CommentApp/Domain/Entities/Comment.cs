using System;
using System.Collections.Generic;

namespace CommentApp.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int AccountId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Post Post { get; set; }
        public Account Account { get; set; }
        public List<Reply> Replies { get; set; }
    }
}
