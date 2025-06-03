using Blogger.Models;

namespace Blogger.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllPosts();
        Task<BlogPost> GetPostById(int id);
        Task<BlogPost> GetPostByUrl(string urlHandle);
        Task<BlogPost> Create(BlogPost post);
        Task<BlogPost> Update(BlogPost post);
        Task DeleteById(int id);
    }
}
