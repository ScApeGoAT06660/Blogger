using AutoMapper;
using Blogger.Models;
using Blogger.Models.ViewModels;

namespace Blogger
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPostDto, BlogPost>().ReverseMap();
        }
    }
}
