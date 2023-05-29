using System.Threading.Tasks;
using CommentApp.Domain.Entities;
using CommentApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommentApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(int postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);
            return View(comments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                await _commentService.CreateCommentAsync(comment);
                return RedirectToAction("Details", "Post", new { id = comment.PostId });
            }

            return View(comment);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _commentService.UpdateCommentAsync(comment);
                return RedirectToAction("Details", "Post", new { id = comment.PostId });
            }

            return View(comment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("Details", "Post", new { id = comment.PostId });
        }
    }
}
