using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace AskMe.UseCases.Subscriptions.ExtendSubscription;

internal class ExtendSubscriptionCommandHandler : AsyncRequestHandler<ExtendSubscriptionCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public ExtendSubscriptionCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(ExtendSubscriptionCommand request, CancellationToken cancellationToken)
    {
        if (request.UserSubscription.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("The user can only extend his subscription");
        }
        var userSubscription = await appDbContext.UserSubscriptions.FindAsync(request.UserSubscription.Id, cancellationToken);
        if (userSubscription is null)
        {
            throw new NotFoundException("Subscription wasn't found.");
        }
        userSubscription.ExpireAt.AddMonths(request.UserSubscription.MonthCount);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
