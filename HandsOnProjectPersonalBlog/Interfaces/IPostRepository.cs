using HandsOnProjectPersonalBlog.Models;

namespace HandsOnProjectPersonalBlog.Interfaces
{
    public interface IPostRepository
    {
        Task Create(Post post);
        Task<List<Post>> GetAll();
    }
}