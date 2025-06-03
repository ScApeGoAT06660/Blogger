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

        [BindProperty]
        public string Tags { get; set; }

        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;

        //[BindProperty]
        //public IFormFile Image { get; set; }

        public CreateModel(IMapper mapper, IBlogPostRepository blogPostRepository)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Something went wrong while creating the post.";
                return Page();
            }

            var tagsCollection = new List<Tag>(Tags.Split('#').Select(x => new Tag() { Name = x.Trim() }));

            var blogpost = _mapper.Map<BlogPost>(CreateBlogPost);
            blogpost.Tags = tagsCollection;

            await _blogPostRepository.Create(blogpost);

            TempData["SuccessMessage"] = "Post created successfully!";

            return RedirectToPage("/Admin/BlogPosts/List");
        }
    }
}
