using Blogger.Models;

namespace Blogger.Repositories.Interfaces
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllPosts();
        Task<IEnumerable<BlogPost>> GetAllPosts(string tagName);
        Task<BlogPost> GetPostById(int id);
        Task<BlogPost> GetPostByUrl(string urlHandle);
        Task<BlogPost> Create(BlogPost post);
        Task<BlogPost> Update(BlogPost post);
        Task DeleteById(int id);
    }
}
