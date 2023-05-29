using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommentApp.Domain.Entities;
using CommentApp.Services;

namespace CommentApp.Controllers
{
    public class ReplyController : Controller
    {
        private readonly ReplyService _replyService;

        public ReplyController(ReplyService replyService)
        {
            _replyService = replyService;
        }

        public async Task<IActionResult> GetReplyById(int replyId)
        {
            var reply = await _replyService.GetReplyByIdAsync(replyId);
            return Json(reply);
        }

        public async Task<IActionResult> GetRepliesByCommentId(int commentId)
        {
            var replies = await _replyService.GetRepliesByCommentIdAsync(commentId);
            return Json(replies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReply(Reply reply)
        {
            await _replyService.CreateReplyAsync(reply);
            return RedirectToAction("Index", "Home"); // Replace "Index" and "Home" with your desired action and controller
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReply(Reply reply)
        {
            await _replyService.UpdateReplyAsync(reply);
            return RedirectToAction("Index", "Home"); // Replace "Index" and "Home" with your desired action and controller
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReply(int replyId)
        {
            await _replyService.DeleteReplyAsync(replyId);
            return RedirectToAction("Index", "Home"); // Replace "Index" and "Home" with your desired action and controller
        }
    }
}
