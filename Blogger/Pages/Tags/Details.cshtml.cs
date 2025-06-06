using Blogger.Models;
using Blogger.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages.Tags
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;

        [BindProperty]
        public List<BlogPost> Posts { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> OnGet(string tagName)
        {
            Posts = (await _blogPostRepository.GetAllPosts(tagName)).ToList();
            return Page();
        }

    }
}
