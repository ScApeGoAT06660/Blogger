using System.ComponentModel.DataAnnotations;

namespace Blogger.Models.ViewModels
{
    public class Login
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
