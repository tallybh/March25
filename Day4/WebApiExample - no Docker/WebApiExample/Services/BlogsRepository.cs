
using Microsoft.EntityFrameworkCore;

namespace WebApiExample.Services
{
    public class BlogsRepository : IBlogRepository
    {
        private readonly AppDbContext _context;
        public BlogsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBlog(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return false;
            }
            _context.Remove(id);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Blog> GetBlog(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetBlogs()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<bool> UpdateBlog(Blog blog)
        {
            var updateBlog = await _context.Blogs.FindAsync(blog.Id);
            if (blog == null)
            {
                return false;
            }
            updateBlog.Name = blog.Name;
            updateBlog.Url = blog.Url;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
