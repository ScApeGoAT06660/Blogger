using Blogger.Models;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ILikeRepository _likeRepository;

        public BlogPost Post { get; set; }
        public int Likes { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository, ILikeRepository likeRepository)
        {
            _blogPostRepository = blogPostRepository;
            _likeRepository = likeRepository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            Post = await _blogPostRepository.GetPostByUrl(urlHandle);

            if (Post != null)
            {
                 Likes = await _likeRepository.ReturnTotalLikesForPost(Post.Id);
            }

            return Page();
        }
    }
}

