namespace Blogger.Repositories.Interfaces
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file);
    }
}
