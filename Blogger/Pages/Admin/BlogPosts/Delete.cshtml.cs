using AutoMapper;
using Blogger.Data;
using Blogger.Models;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Pages.Admin.BlogPosts
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public BlogPost Post { get; set; }

        private readonly IBlogPostRepository _blogPostRepository;

        public DeleteModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Post = await _blogPostRepository.GetPostById(id);

            if (Post == null)
            {
                TempData["ErrorMessage"] = "Something went wrong while deleting the post.";
                return NotFound();
            }

            return Page(); 
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _blogPostRepository.DeleteById(id);

            TempData["SuccessMessage"] = "Post deleted successfully!";

            return RedirectToPage("/Admin/BlogPosts/List");
        }
    }
}
