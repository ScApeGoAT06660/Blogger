using Blogger.Models;
using Blogger.Models.ViewModels;
using Blogger.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Blogger.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogPost Post { get; set; }
        public int Likes { get; set; }
        public List<DisplayComment> Comments { get; set; }

        [BindProperty]
        public int PostId { get; set; }

        [BindProperty]
        [Required]
        [MaxLength(200)]
        [MinLength(1)]
        public string CommentDescription { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository, 
            ILikeRepository likeRepository,
            ICommentRepository commentRepository,
            UserManager<IdentityUser> userManager)
        {
            _blogPostRepository = blogPostRepository;
            _likeRepository = likeRepository;
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet(string urlHandle)
        {
            await GetPost(urlHandle);

            return Page();
        }

        [Authorize]
        public async Task<IActionResult> OnPost(string urlHandle) 
        {
            if (!ModelState.IsValid)
            {
                await GetPost(urlHandle);
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();
            else if(userId != null && !string.IsNullOrWhiteSpace(CommentDescription))
            {
                var comment = new Comment()
                {
                    BlogPostId = PostId,
                    Description = CommentDescription,
                    DateAdded = DateTime.Now,
                    UserId = userId
                };

                _commentRepository.Add(comment);
            }

            return RedirectToPage("/Blog/Details", new {urlHandle = urlHandle});
        }

        private async Task GetComments()
        {
            var comments = await _commentRepository.GetAll(PostId);

            var commentsViewModel = new List<DisplayComment>();

            foreach (var comment in comments) 
            {
                commentsViewModel.Add(new DisplayComment()
                {
                    DateAdded = comment.DateAdded,
                    Description = comment.Description,
                    Username = (await _userManager.FindByIdAsync(comment.UserId.ToString())).UserName
                });
            }

            Comments = commentsViewModel;
        }

        private async Task GetPost(string urlHandle)
        {
            Post = await _blogPostRepository.GetPostByUrl(urlHandle);

            if (Post != null)
            {
                Likes = await _likeRepository.ReturnTotalLikesForPost(Post.Id);
                PostId = Post.Id;
                await GetComments();
            }
        }
    }
}


