using Blogger.Models;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPost Post { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            Post = await _blogPostRepository.GetPostByUrl(urlHandle);
            return Page();
        }
    }
}
