using System.Collections.Generic;
using System.Threading.Tasks;
using CommentApp.Data.Repositories;
using CommentApp.Domain.Entities;

namespace CommentApp.Services
{
    public class ReplyService
    {
        private readonly IReplyRepository _replyRepository;

        public ReplyService(IReplyRepository replyRepository)
        {
            _replyRepository = replyRepository;
        }

        public async Task<Reply> GetReplyByIdAsync(int replyId)
        {
            return await _replyRepository.GetReplyByIdAsync(replyId);
        }

        public async Task<List<Reply>> GetRepliesByCommentIdAsync(int commentId)
        {
            return await _replyRepository.GetRepliesByCommentIdAsync(commentId);
        }

        public async Task CreateReplyAsync(Reply reply)
        {
            await _replyRepository.CreateReplyAsync(reply);
        }

        public async Task UpdateReplyAsync(Reply reply)
        {
            await _replyRepository.UpdateReplyAsync(reply);
        }

        public async Task DeleteReplyAsync(int replyId)
        {
            await _replyRepository.DeleteReplyAsync(replyId);
        }
    }
}
