using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.Publications.UpdatePublication;

internal class UpdatePublicationCommandHandler : AsyncRequestHandler<UpdatePublicationCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public UpdatePublicationCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
    {
        var publication = await appDbContext.Publications.FirstOrDefaultAsync(p => p.Id == request.Publication.Id);
        if (publication == null)
        {
            throw new NotFoundException("Publication not found.");
        }
        if (loggedUserAccessor.GetCurrentUserId() != publication.UserId)
        {
            throw new ForbiddenException("Only the user can create publications for himself.");
        }
        publication.EditDate = DateTime.Now;
        publication.Content = request.Publication.Content;
        publication.Header = request.Publication.Header;
        publication.SubscriptionId = request.Publication.SubscriptionId;
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
