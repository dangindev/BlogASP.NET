using System.Collections.Generic;
using System.Threading.Tasks;
using CommentApp.Data.Repositories;
using CommentApp.Domain.Entities;

namespace CommentApp.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _commentRepository.GetCommentsByPostIdAsync(postId);
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _commentRepository.GetCommentByIdAsync(commentId);
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            await _commentRepository.CreateCommentAsync(comment);
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            await _commentRepository.UpdateCommentAsync(comment);
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            await _commentRepository.DeleteCommentAsync(commentId);
        }
    }
}
