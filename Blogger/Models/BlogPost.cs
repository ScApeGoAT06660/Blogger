﻿namespace Blogger.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeatureImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Comment> Commants { get; set; } = new List<Comment>();
    }
}
