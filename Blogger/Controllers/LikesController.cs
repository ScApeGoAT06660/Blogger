using Blogger.Models;
using Blogger.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : Controller
    {
        private readonly ILikeRepository _likeRepository;

        public LikesController(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }



        [HttpPost("Add")]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddLikeRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized();

            await _likeRepository.AddLike(request.BlogPostId, userId);
            var totalLikes = await _likeRepository.ReturnTotalLikesForPost(request.BlogPostId);

            return Ok(new { totalLikes });
        }

    }
}
