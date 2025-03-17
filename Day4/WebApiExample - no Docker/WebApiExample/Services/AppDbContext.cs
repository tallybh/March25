using Microsoft.EntityFrameworkCore;

namespace WebApiExample.Services
{
    public class AppDbContext:DbContext
    {
        protected readonly DbContextOptions Configuration;
        public AppDbContext(DbContextOptions configuration) : base(configuration)
        {
            Configuration = configuration;
        }

      
        //public DbSet<Product> Products { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }

    }
}
