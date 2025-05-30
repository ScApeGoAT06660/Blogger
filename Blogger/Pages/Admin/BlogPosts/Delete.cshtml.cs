using AutoMapper;
using Blogger.Data;
using Blogger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Pages.Admin.BlogPosts
{
    public class DeleteModel : PageModel
    {
        private readonly BloggerDBContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteModel(BloggerDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [BindProperty]
        public BlogPost Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Post = await _dbContext.BlogPost.FirstOrDefaultAsync(p => p.Id == id);

            if (Post == null)
            {
                return NotFound();
            }

            return Page(); 
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var post = await _dbContext.BlogPost.FindAsync(id);

            if (post != null)
            {
                _dbContext.BlogPost.Remove(post);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("/Admin/BlogPosts/List");
        }
    }
}
