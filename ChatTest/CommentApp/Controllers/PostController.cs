using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentApp.Domain;
using CommentApp.Domain.Entities;
using CommentApp.Models;
using CommentApp.Services;
using CommentApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CommentApp.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly PostService _postService;
        private readonly CommentService _commentService;

        public PostController(PostService postService, CommentService commentService)
        {
            _postService = postService;
            _commentService = commentService;
        }

        // ...

        public async Task<IActionResult> ViewPost(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            var comments = await _commentService.GetCommentsByPostIdAsync(id);

            var postViewModel = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                Comments = comments.Select(c => new CommentViewModel
                {
                    Id = c.Id,
                    Author = c.Account.Username,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                }).ToList()
            };

            return View(postViewModel);
        }



    }
}
