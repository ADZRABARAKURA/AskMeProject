using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Post;
using AskMe.UseCases.Common.Dtos.UserProfiles;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.UserProfiles.GetUserProfileById;

internal class GetUserProfileByIdCommandHandler : IRequestHandler<GetUserProfileByIdCommand, UserProfileDto>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IMapper mapper;
    private readonly IAppDbContext appDbContext;

    public GetUserProfileByIdCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IAppDbContext appDbContext)
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.appDbContext = appDbContext;
    }

    public async Task<UserProfileDto> Handle(GetUserProfileByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync($"{request.Id}");
        if (user is null)
        {
            throw new NotFoundException("User with this id was not found.");
        }
        var profile = await appDbContext.Profiles
            .FirstOrDefaultAsync(entity => entity.UserId == user.Id);
        var dto =  mapper.Map<UserProfileDto>(profile);
        var goals = await mapper
            .ProjectTo<GoalDto>(appDbContext.Goals)
            .Where(g => g.UserId == user.Id)
            .ToListAsync(cancellationToken);
        var subscriptions = await appDbContext.Subscriptions
            .Where(s => s.UserId == user.Id)
            .ToListAsync(cancellationToken);
        dto.CheapestSubscriptionPrice = GetCheapestSubscriptionPrice(subscriptions);
        dto.Subscribers = await GetSubscribersAsync(subscriptions, cancellationToken);
        dto.Publications = await GetPublicationsAsync(user, cancellationToken);
        dto.Goals = goals;
        return dto;
    }

    private decimal GetCheapestSubscriptionPrice(IEnumerable<Subscription> subscriptions)
    {
        var cheapestPrice = subscriptions.Min(s => s.Price);
        return (decimal)cheapestPrice;
    }

    private async Task<int> GetSubscribersAsync(IEnumerable<Subscription> subscriptions, CancellationToken cancellationToken)
    {
        var subscriptionsCount = 0;
        foreach (var subscription in subscriptions)
        {
            subscriptionsCount += await appDbContext.UserSubscriptions
                .Where(us => us.SubscriptionId == subscription.Id)
                .CountAsync(cancellationToken);
        }
        return subscriptionsCount;
    }

    private async Task<IEnumerable<PublicationDto>> GetPublicationsAsync(ApplicationUser user, CancellationToken cancellationToken)
    {
        var publicationDtos = new List<PublicationDto>();
        var publications = await appDbContext.Publications
            .Where(p => p.UserId == user.Id)
            .ToListAsync(cancellationToken);
        foreach (var publication in publications)
        {
            var publicationDto = mapper.Map<PublicationDto>(publication);
            var subscription = await appDbContext.Subscriptions
                .FirstOrDefaultAsync(s => s.Id == publication.SubscriptionId);
            publicationDto.Subscription = GetSubscriptionTitle(subscription);
            publicationDto.IsAvailable = await IsSubscriptionAvailableAsync(user, subscription, cancellationToken);
            publicationDtos.Add(publicationDto);
        }
        return publicationDtos;
    }

    private async  Task<bool> IsSubscriptionAvailableAsync(ApplicationUser user, Subscription subscription, CancellationToken cancellationToken)
    {
        var isAvailable = false;
        if (subscription != null)
        {
            var userSubscriptions = await appDbContext.UserSubscriptions
                .Where(us => us.UserId == user.Id && us.ExpireAt > DateTime.Now)
                .ToListAsync(cancellationToken);
            foreach (var userSubscription in userSubscriptions)
            {
                if (userSubscription.SubscriptionId == subscription.Id)
                {
                    return true;
                }
                var relatedSubscription = await appDbContext.Subscriptions
                    .Include(s => s.ChildSubscriptions)
                    .FirstOrDefaultAsync(s => s.Id == userSubscription.SubscriptionId);
                if (relatedSubscription.ChildSubscriptions.Any(cs => cs.Id == subscription.Id))
                {
                    return true;
                }
            }
        } else
        {
            isAvailable = true;
        }
        return isAvailable;
    }

    private string GetSubscriptionTitle(Subscription subscription)
    {
        var title = string.Empty;
        if (subscription != null)
        {
            title = subscription.Title;
        }
        return title;
    }
}
