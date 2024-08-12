using HandsOnProjectPersonalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace HandsOnProjectPersonalBlog.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Post { get; set; }
        
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
    }
}