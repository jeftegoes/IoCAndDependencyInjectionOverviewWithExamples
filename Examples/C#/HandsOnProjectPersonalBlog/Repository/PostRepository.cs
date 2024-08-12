using HandsOnProjectPersonalBlog.Data;
using HandsOnProjectPersonalBlog.Interfaces;
using HandsOnProjectPersonalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace HandsOnProjectPersonalBlog.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;

        public PostRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAll()
        {
            return await _context.Post.ToListAsync();
        }

        public async Task Create(Post post)
        {
            await _context.Post.AddAsync(post);
            await _context.SaveChangesAsync();
        }
    }
}