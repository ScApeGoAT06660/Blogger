using Microsoft.EntityFrameworkCore;
using Blogger.Data;
using Blogger.Models;

namespace Blogger.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly BloggerDBContext _dbContext;

        public LikeRepository(BloggerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLike(int postId, string userId)
        {
            var like = new Like
            {
                BlogPostId = postId,
                UserId = userId
            };

            await _dbContext.Like.AddAsync(like);
            await _dbContext.SaveChangesAsync();    
        }

        public async Task<int> ReturnTotalLikesForPost(int postId)
        {
            var likes = await _dbContext.Like.CountAsync(X => X.BlogPostId == postId);

            return likes;
        }
    }
}
