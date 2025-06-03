using Blogger.Data;
using Blogger.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggerDBContext _dbContext;

        public BlogPostRepository(BloggerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BlogPost> Create(BlogPost post)
        {
            await _dbContext.BlogPost.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task DeleteById(int id)
        {
            var post = await _dbContext.BlogPost.FindAsync(id);

            if (post != null)
            {
                _dbContext.BlogPost.Remove(post);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BlogPost>> GetAllPosts()
        {
            var posts = await _dbContext.BlogPost
                .Include(p => p.Tags)
                .ToListAsync(); 
            return posts;
        }

        public async Task<BlogPost> GetPostById(int id)
        {
            var post = await _dbContext.BlogPost
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(p => p.Id == id);

            return post;
        }

        public async Task<BlogPost> GetPostByUrl(string urlHandle)
        {
            var post = await _dbContext.BlogPost
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);

            return post;
        }

        public async Task<BlogPost> Update(BlogPost post)
        {
            var postToEdit = await GetPostById(post.Id);

            postToEdit.Heading = post.Heading;
            postToEdit.PageTitle = post.PageTitle;
            postToEdit.Content = post.Content;
            postToEdit.ShortDescription = post.ShortDescription;
            postToEdit.FeatureImageUrl = post.FeatureImageUrl;
            postToEdit.UrlHandle = post.UrlHandle;
            postToEdit.PublishedDate = post.PublishedDate;
            postToEdit.Author = post.Author;
            postToEdit.Visible = post.Visible;
            postToEdit.Tags = post.Tags;

            await _dbContext.SaveChangesAsync();

            return post;
        }
    }
}
