using Blogger.Repositories.Interfaces;
using CloudinaryDotNet;

namespace Blogger.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly Account account;

        public ImageRepository(IConfiguration configuration)
        {
            account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]);

            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        public async Task<string> Upload(IFormFile file)
        {
            var client = new Cloudinary(account);

            var uploadFileResult = await client.UploadAsync(new CloudinaryDotNet.Actions.ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName,
            });

            if (uploadFileResult != null && uploadFileResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadFileResult.SecureUrl.ToString();
            }

            return null;
        }
    }
}
