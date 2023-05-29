using System.Collections.Generic;
using System.Threading.Tasks;
using CommentApp.Domain.Entities;

namespace CommentApp.Data.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task CreateCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);
    }
}
