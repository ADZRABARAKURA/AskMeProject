using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.Domain.Posts.Entities;
using MediatR;
using AskMe.DomainServices.Exceptions;

namespace AskMe.UseCases.Subscriptions.SubscribeUser;

internal class SubscribeUserCommandHandler : AsyncRequestHandler<SubscribeUserCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public SubscribeUserCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(SubscribeUserCommand request, CancellationToken cancellationToken)
    {
        if (request.UserSubscription.UserId != loggedUserAccessor.GetCurrentUserId() )
        {
            throw new ForbiddenException("The user can only subscribe.");
        }
        var subscription = await appDbContext.Subscriptions.FindAsync(request.UserSubscription.Id);
        if (subscription is null)
        {
            throw new NotFoundException("Subscription was not found.");
        }
        await appDbContext.UserSubscriptions.AddAsync(new UserSubscription()
        {
            CreationDate = DateTime.Now,
            UserId = request.UserSubscription.UserId,
            Subscription = subscription,
            SubscriptionId = request.UserSubscription.UserId,
            ExpireAt = DateTime.Now.AddMonths(request.UserSubscription.MonthCount)
        }, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
