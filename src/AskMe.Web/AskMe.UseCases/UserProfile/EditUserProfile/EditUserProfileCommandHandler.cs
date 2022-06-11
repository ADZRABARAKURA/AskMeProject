using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.UserProfiles.EditUserProfile;

internal class EditUserProfileCommandHandler : AsyncRequestHandler<EditUserProfileCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public EditUserProfileCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(EditUserProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = await appDbContext.Profiles
            .FirstOrDefaultAsync(p => p.UserId == request.Profile.UserId);
        if (profile == null)
        {
            throw new NotFoundException("User was not found");
        }
        if (loggedUserAccessor.GetCurrentUserId() != request.Profile.UserId)
        {
            throw new ForbiddenException("Only user can edit his profile");
        }
        if (request.Profile.References != null)
        {
            profile.References = string.Join(',', request.Profile.References);
        }
        profile.Description = request.Profile.Description;
        profile.Passion = request.Profile.Passion;
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
