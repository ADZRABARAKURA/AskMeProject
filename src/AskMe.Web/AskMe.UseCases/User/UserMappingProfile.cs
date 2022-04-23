using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using AskMe.UseCases.Common.Dtos.Post;
using AskMe.UseCases.Common.Dtos.User;
using AutoMapper;

namespace AskMe.UseCases.User;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<ApplicationUser, UserDto>().ReverseMap();
    }
}
