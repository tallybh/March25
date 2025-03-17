using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiExample.Models
{
    [Table("WonderBlogs")]
    public class Blog
    {
        public Blog()
        {
            List<Post> Posts = new List<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}
