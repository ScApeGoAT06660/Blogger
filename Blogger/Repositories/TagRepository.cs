using Blogger.Data;
using Blogger.Models;
using Blogger.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggerDBContext _dbContext;

        public TagRepository(BloggerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            var tags = await _dbContext.Tag.ToListAsync();

            return tags.DistinctBy(x => x.Name.ToLower());
        }
    }
}
