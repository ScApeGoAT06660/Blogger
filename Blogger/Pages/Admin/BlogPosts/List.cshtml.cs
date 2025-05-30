using Blogger.Data;
using Blogger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public void OnGet()
        {
            Posts = _dbcontext.BlogPost.ToList();
        }
    }
}
