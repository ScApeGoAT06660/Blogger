using Blogger.Data;
using Blogger.Models;
using Blogger.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Blogger.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BloggerDBContext _dbContext;

        public CommentRepository(BloggerDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Comment> Add(Comment comment)
        {
            await _dbContext.Comment.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetAll(int postId)
        {
            var comments = await _dbContext.Comment.Where(x => x.BlogPostId == postId).ToListAsync();
            return comments;     
        }
    }
}
