using AutoMapper;
using Blogger.Data;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages.Admin.BlogPosts
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public BlogPostDto CreateBlogPost { get; set; }

        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;

        public CreateModel(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Something went wrong while creating the post.";
                return Page();
            }

            var blogpost = _mapper.Map<BlogPost>(CreateBlogPost);

            await _blogPostRepository.Create(blogpost);

            TempData["SuccessMessage"] = "Post created successfully!";

            return RedirectToPage("/Admin/BlogPosts/List");
        }
    }
}
