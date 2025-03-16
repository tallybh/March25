namespace WebApiExample.Contracts
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetBlogs();
        Task<Blog> GetBlog(int id);
        Task AddBlog(Blog blog);
        Task<bool> UpdateBlog(Blog blog);
        Task<bool> DeleteBlog(int id);
    }
}
