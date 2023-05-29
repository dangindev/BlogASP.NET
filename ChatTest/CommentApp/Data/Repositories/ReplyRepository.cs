using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentApp.Data.Contexts;
using CommentApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommentApp.Data.Repositories
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly QLBDSObjectContext _context;

        public ReplyRepository(QLBDSObjectContext context)
        {
            _context = context;
        }

        public async Task<Reply> GetReplyByIdAsync(int replyId)
        {
            return await _context.Replies.FindAsync(replyId);
        }

        public async Task<List<Reply>> GetRepliesByCommentIdAsync(int commentId)
        {
            return await _context.Replies
                .Where(r => r.CommentId == commentId)
                .ToListAsync();
        }

        public async Task CreateReplyAsync(Reply reply)
        {
            _context.Replies.Add(reply);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReplyAsync(Reply reply)
        {
            _context.Entry(reply).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReplyAsync(int replyId)
        {
            var reply = await _context.Replies.FindAsync(replyId);
            if (reply != null)
            {
                _context.Replies.Remove(reply);
                await _context.SaveChangesAsync();
            }
        }
    }
}
