using Blogger.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Data
{
    public class BloggerDBContext : DbContext
    {
        public BloggerDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Tag> Tag { get; set; }
    }
}
