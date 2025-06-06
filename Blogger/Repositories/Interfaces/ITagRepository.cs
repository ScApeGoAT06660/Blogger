using Blogger.Models;
using Blogger.Pages.Admin.BlogPosts;

namespace Blogger.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllTags();
    }
}
