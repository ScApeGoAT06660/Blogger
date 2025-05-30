using Blogger.Data;
using Blogger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Pages.Admin.BlogPosts
{
    public class ListModel : PageModel
    {
        private readonly BloggerDBContext _dbcontext;

        public List<BlogPost> Posts { get; set; }

        public ListModel(BloggerDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task OnGet()
        {
            Posts = await _dbcontext.BlogPost.ToListAsync();
        }
    }
}
