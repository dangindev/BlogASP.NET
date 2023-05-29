using System.Collections.Generic;
using System.Threading.Tasks;
using CommentApp.Domain;
using CommentApp.Domain.Entities;

namespace CommentApp.Data.Repositories
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int postId);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int postId);
    }
}
