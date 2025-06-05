namespace Blogger.Repositories
{
    public interface ILikeRepository
    {
        Task<int> ReturnTotalLikesForPost(int postId);

        Task AddLike(int postId, string userId);
    }
}
