using System.Collections.Generic;
using System.Threading.Tasks;
using CommentApp.Data.Contexts;
using CommentApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace CommentApp.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly QLBDSObjectContext _context;

        public CommentRepository(QLBDSObjectContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _context.Comments
                .Where(c => c.PostId == postId)
                .ToListAsync();
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
