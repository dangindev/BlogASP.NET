using System.Collections.Generic;
using System.Threading.Tasks;
using CommentApp.Domain.Entities;

namespace CommentApp.Data.Repositories
{
    public interface IReplyRepository
    {
        Task<Reply> GetReplyByIdAsync(int replyId);
        Task<List<Reply>> GetRepliesByCommentIdAsync(int commentId);
        Task CreateReplyAsync(Reply reply);
        Task UpdateReplyAsync(Reply reply);
        Task DeleteReplyAsync(int replyId);
    }
}
