using System;

namespace CommentApp.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
