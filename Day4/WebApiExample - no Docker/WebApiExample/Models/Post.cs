namespace WebApiExample.Models
{
    public class Post
    {
        public int id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }


    }
}