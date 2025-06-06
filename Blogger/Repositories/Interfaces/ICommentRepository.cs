using Blogger.Models;

namespace Blogger.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> Add(Comment comment);
        Task<IEnumerable<Comment>> GetAll(int postId);
    }
}
