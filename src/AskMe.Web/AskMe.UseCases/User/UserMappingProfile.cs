using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using AskMe.UseCases.Common.Dtos.Post;
using AskMe.UseCases.Common.Dtos.User;
using AskMe.UseCases.Common.Dtos.UserProfile;
using AutoMapper;

namespace AskMe.UseCases.User;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, PostForStreamerDto>();
        CreateMap<Post, PostForDonaterDto>();
        CreateMap<UserProfile, UserProfileDto>()
            .ForMember(dto => dto.CheapestSubscriptionPrice, opt => opt.MapFrom(entity => entity.Subscriptions.Min(sub => sub.Price)))
            .ForMember(dto => dto.Subscribers, opt => opt.MapFrom(entity => entity.Subscribers.Count));
        CreateMap<Publication, PublicationDto>();
        CreateMap<ApplicationUser, UserDto>().ReverseMap();
    }
}
