namespace HandsOnProjectPersonalBlog.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public DateTime PostDateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}