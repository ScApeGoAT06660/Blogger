using Blogger.Models;
using Blogger.Pages.Admin.BlogPosts;

namespace Blogger.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllTags();
    }
}
