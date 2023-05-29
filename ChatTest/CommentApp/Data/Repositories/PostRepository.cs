using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentApp.Domain.Entities;
using CommentApp.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using CommentApp.Domain;

namespace CommentApp.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly QLBDSObjectContext _dbContext;

        public PostRepository(QLBDSObjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _dbContext.Posts.FindAsync(postId);
        }

        public async Task CreatePostAsync(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            _dbContext.Posts.Update(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int postId)
        {
            var post = await _dbContext.Posts.FindAsync(postId);
            if (post != null)
            {
                _dbContext.Posts.Remove(post);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
