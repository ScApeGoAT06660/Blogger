using AutoMapper;
using Blogger.Models;
using Blogger.Models.ViewModels;

namespace Blogger
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePost, BlogPost>().ReverseMap();
            CreateMap<EditPost, BlogPost>().ReverseMap();
        }
    }
}
