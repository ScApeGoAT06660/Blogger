using AutoMapper;
using Blogger.Data;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blogger.Pages.Admin.BlogPosts
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public BlogPostDto CreateBlogPost { get; set; }

        private readonly BloggerDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateModel(BloggerDBContext dBContext, IMapper mapper)
        {
            _dbContext = dBContext;
            _mapper = mapper;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var blogpost = _mapper.Map<BlogPost>(CreateBlogPost);

            _dbContext.BlogPost.Add(blogpost);
            _dbContext.SaveChanges();

            return RedirectToPage("/Admin/BlogPosts/List");
        }
    }
}
