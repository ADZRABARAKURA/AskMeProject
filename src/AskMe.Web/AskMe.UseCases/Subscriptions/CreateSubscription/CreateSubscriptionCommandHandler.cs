using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.Subscriptions.CreateSubscription;

internal class CreateSubscriptionCommandHandler : AsyncRequestHandler<CreateSubscriptionCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly UserManager<ApplicationUser> userManager;

    public CreateSubscriptionCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor, UserManager<ApplicationUser> userManager)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
        this.userManager = userManager;
    }

    protected override async Task Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var user = userManager.FindByIdAsync($"{request.Subscription.UserId}");
        if (user is null)
        {
            throw new NotFoundException("User not found.");
        }
        if (request.Subscription.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("Only the user can create subscriptions for himself");
        }
        var childSubscriptions = await appDbContext.Subscriptions
            .Where(s => s.Price < request.Subscription.Price)
            .ToListAsync(cancellationToken);
        await appDbContext.Subscriptions.AddAsync(new Subscription()
        {
            UserId = request.Subscription.UserId,
            Title = request.Subscription.Title,
            Price = request.Subscription.Price,
            ChildSubscriptions = childSubscriptions,
            IsActive = true,
            Description = request.Subscription.Description,
            CreationDate = DateTime.UtcNow
        }, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
