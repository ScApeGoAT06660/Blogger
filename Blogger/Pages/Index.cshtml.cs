using Blogger.Models;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostRepository _blogPostRepository;

        public IEnumerable<BlogPost> Posts { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostRepository blogPostRepository)
        {
            _logger = logger;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Posts = await _blogPostRepository.GetAllPosts();
            return Page();
        }
    }
}
