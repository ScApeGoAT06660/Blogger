using AutoMapper;
using Blogger.Data;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Pages.Admin.BlogPosts
{
    public class EditModel : PageModel
    {
        private readonly BloggerDBContext _dbContext;
        private readonly IMapper _mapper;

        public EditModel(BloggerDBContext dbcontext, IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        [BindProperty]
        public BlogPost PostToEdit { get; set; }

        public async Task OnGet(int id)
        {
            PostToEdit = await _dbContext.BlogPost.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var post = await _dbContext.BlogPost.FindAsync(PostToEdit.Id);

            if (post != null)
            {
                post.Heading = PostToEdit.Heading;
                post.PageTitle = PostToEdit.PageTitle;
                post.Content = PostToEdit.Content;
                post.ShortDescription = PostToEdit.ShortDescription;
                post.FeatureImageUrl = PostToEdit.FeatureImageUrl;
                post.UrlHandle = PostToEdit.UrlHandle;
                post.PublishedDate = PostToEdit.PublishedDate;
                post.Author = PostToEdit.Author;
                post.Visible = PostToEdit.Visible;

                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/BlogPosts/List");
        }                
    }
}
