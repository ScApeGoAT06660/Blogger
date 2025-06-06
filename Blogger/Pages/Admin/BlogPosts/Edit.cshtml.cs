using AutoMapper;
using Blogger.Data;
using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Blogger.Pages.Admin.BlogPosts
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditPost PostToEdit { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public EditModel(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }      

        public async Task OnGet(int id)
        {
            var post = await _blogPostRepository.GetPostById(id);
            PostToEdit = _mapper.Map<EditPost>(post);

            Tags = string.Join(" ", post.Tags.Select(t => $"#{t.Name}"));
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

            var editedPost = _mapper.Map<BlogPost>(PostToEdit);
            editedPost.Tags = tagsCollection;

            await _blogPostRepository.Update(editedPost);

            TempData["SuccessMessage"] = "Post edited successfully!";

            return RedirectToPage("/Admin/BlogPosts/List");
        }                
    }
}
