using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using AskMe.UseCases.Common.Dtos.Post;
using AskMe.UseCases.Common.Dtos.Subscriptions;
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
        CreateMap<Subscription, SubscriptionDto>();
        CreateMap<UserSubscription, UserSubscriptionDto>()
            .ForMember(dto => dto.IsActive, opt => opt.MapFrom(entity => entity.ExpireAt > DateTime.Now))
            .ForMember(dto => dto.SubscriptionTitle, opt => opt.MapFrom(entity => entity.Subscription.Title));
        CreateMap<UserProfile, UserProfileDto>()
            .ForMember(dto => dto.CheapestSubscriptionPrice, opt => opt.MapFrom(entity => FindCheapestSubscription(entity.Subscriptions)))
            .ForMember(dto => dto.Subscribers, opt => opt.MapFrom(entity => entity.Subscribers.Count))
            .ForMember(dto => dto.References, opt => opt.MapFrom(entity => GetReferences(entity.References)));
        CreateMap<Publication, PublicationDto>()
            .ForMember(dto => dto.Subscription, opt => opt.MapFrom(entity => entity.Subscription == null 
                ? null : entity.Subscription.Title));
        CreateMap<ApplicationUser, UserDto>().ReverseMap();
    }

    private string[] GetReferences(string references)
    {
        return references is null ? new string[0] : references.Split(',');
    }

    private object FindCheapestSubscription(List<Subscription> subscriptions)
    {
        var cheapestSubscription = 1000M;
        foreach (var subscription in subscriptions)
        {
            var price = ((int)subscription.Price);
            if (((int)subscription.Price) < cheapestSubscription)
            {
                cheapestSubscription = price;
            }
        }

        return cheapestSubscription == 1000 ? default : cheapestSubscription;
    }
}
