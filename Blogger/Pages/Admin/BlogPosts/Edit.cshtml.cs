using AutoMapper;
using Blogger.Data;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Pages.Admin.BlogPosts
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public BlogPost PostToEdit { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        private readonly IBlogPostRepository _blogPostRepository;

        public EditModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }      

        public async Task OnGet(int id)
        {
            PostToEdit = await _blogPostRepository.GetPostById(id);
            Tags = string.Join(" ", PostToEdit.Tags.Select(t => $"#{t.Name}"));

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Something went wrong while editing the post.";
                return Page();
            }

            var tagsCollection = Tags
            .Split('#', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => new Tag { Name = x.Trim() })
            .ToList();

            PostToEdit.Tags = tagsCollection;

            await _blogPostRepository.Update(PostToEdit);

            TempData["SuccessMessage"] = "Post edited successfully!";

            return RedirectToPage("/Admin/BlogPosts/List");
        }                
    }
}
