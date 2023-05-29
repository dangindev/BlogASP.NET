using System.Collections.Generic;
using System.Threading.Tasks;
using CommentApp.Data.Repositories;
using CommentApp.Domain;
using CommentApp.Domain.Entities;

namespace CommentApp.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _postRepository.GetPostByIdAsync(postId);
        }

        public async Task CreatePostAsync(Post post)
        {
            await _postRepository.CreatePostAsync(post);
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _postRepository.UpdatePostAsync(post);
        }

        public async Task DeletePostAsync(int postId)
        {
            await _postRepository.DeletePostAsync(postId);
        }
    }
}
