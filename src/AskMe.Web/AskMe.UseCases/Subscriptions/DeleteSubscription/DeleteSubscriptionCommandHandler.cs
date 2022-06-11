using AskMe.Domain.Users.Entities;
using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.Subscriptions.DeleteSubscription;

internal class DeleteSubscriptionCommandHandler : AsyncRequestHandler<DeleteSubscriptionCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly UserManager<ApplicationUser> userManager;

    public DeleteSubscriptionCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor, UserManager<ApplicationUser> userManager)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
        this.userManager = userManager;
    }

    protected override async Task Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await appDbContext.Subscriptions
            .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken);
        if (subscription is null)
        {
            throw new NotFoundException("Subscription wasn't found.");
        }
        var currentUser = await userManager.FindByIdAsync($"{loggedUserAccessor.GetCurrentUserId()}");
        var roles = await userManager.GetRolesAsync(currentUser);
        if (loggedUserAccessor.GetCurrentUserId() != subscription.UserId && !roles.Contains("Admin"))
        {
            throw new ForbiddenException("Only the user himself can delete his subscriptions");
        }
        subscription.IsActive = false;
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
