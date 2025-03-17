

using Microsoft.EntityFrameworkCore;

namespace WebApiExample.Services
{
    public class PostsRepository : IPostsRepository
    {
        private readonly AppDbContext _context;
        public PostsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddPost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePost(int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Post> GetPost(int id)
        {
           return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task UpdatePost(Post post)
        {
           var postToUpdate = _context.Posts.Find(post.id);
            postToUpdate.Title = post.Title;
            postToUpdate.Body = post.Body;
            postToUpdate.BlogId = post.BlogId;
            await _context.SaveChangesAsync();
        }


    }
}
