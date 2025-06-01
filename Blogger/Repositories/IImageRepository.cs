namespace Blogger.Repositories
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file);
    }
}
