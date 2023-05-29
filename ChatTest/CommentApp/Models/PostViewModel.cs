using System.Collections.Generic;

namespace CommentApp.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Models.CommentViewModel> Comments { get; set; }
    }
}
