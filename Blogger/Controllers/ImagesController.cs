using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {

        }
    }
}
