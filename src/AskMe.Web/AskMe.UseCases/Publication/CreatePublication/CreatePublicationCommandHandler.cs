using AskMe.Domain.Posts.Entities;
using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace AskMe.UseCases.Publications.CreatePublication;

internal class CreatePublicationCommandHandler : AsyncRequestHandler<CreatePublicationCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public CreatePublicationCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
    {
        if (loggedUserAccessor.GetCurrentUserId() != request.Publication.UserId)
        {
            throw new ForbiddenException("Only the user can create publications for himself.");
        }
        var publication = new Publication()
        {
            Content = request.Publication.Content,
            CreationDate = DateTime.Now,
            Header = request.Publication.Header,
            SubscriptionId = request.Publication.SubscriptionId,
            UserId = request.Publication.UserId
        };
        await appDbContext.Publications.AddAsync(publication, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
