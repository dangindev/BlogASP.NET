using System;

namespace CommentApp.Domain.Entities
{
    public class Reply
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int AccountId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Comment Comment { get; set; }
        public Account Account { get; set; }
    }
}
