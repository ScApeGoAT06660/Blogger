using Blogger.Data;
using Blogger.Models;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Pages.Admin.BlogPosts
{
    public class ListModel : PageModel
    {
        public IEnumerable<BlogPost> Posts { get; set; }
        private readonly IBlogPostRepository _blogPostRepository;

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task OnGet()
        {
            Posts = await _blogPostRepository.GetAllPosts();
        }
    }
}
