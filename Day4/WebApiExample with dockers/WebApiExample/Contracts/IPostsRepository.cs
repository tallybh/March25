namespace WebApiExample.Contracts
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);
        Task AddPost(Post post);
        Task UpdatePost(Post post);
        Task<bool> DeletePost(int id);    
    }
}
