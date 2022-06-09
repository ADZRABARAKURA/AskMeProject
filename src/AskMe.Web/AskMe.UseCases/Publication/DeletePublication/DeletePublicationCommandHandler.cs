using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.Publications.DeletePublication;

internal class DeletePublicationCommandHandler : AsyncRequestHandler<DeletePublicationCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public DeletePublicationCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
    {
        var publication = await appDbContext.Publications.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (publication == null)
        {
            throw new NotFoundException("Publication not found");
        }
        if (loggedUserAccessor.GetCurrentUserId() != publication.UserId)
        {
            throw new ForbiddenException("Only the user can delete publications for himself");
        }
        appDbContext.Publications.Remove(publication);
        await appDbContext.SaveChangesAsync();
    }
}
