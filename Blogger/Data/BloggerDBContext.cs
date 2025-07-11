﻿using Blogger.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Data
{
    public class BloggerDBContext : DbContext
    {
        public BloggerDBContext(DbContextOptions<BloggerDBContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
