namespace Blogger.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BlogPostId { get; set; }
        public string UserId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
