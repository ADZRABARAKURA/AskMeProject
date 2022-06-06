using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.UserProfile;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.GetCurrentUserProfile;

internal class GetCurrentUserProfileCommandHandler : IRequestHandler<GetCurrentUserProfileCommand, UserProfileDto>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IMapper mapper;

    public GetCurrentUserProfileCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
        this.mapper = mapper;
    }

    public async Task<UserProfileDto> Handle(GetCurrentUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userId = loggedUserAccessor.GetCurrentUserId();
        var profile = await appDbContext.Profiles
            .FirstOrDefaultAsync(entity => entity.UserId == userId, cancellationToken);
        if (profile is null)
        {
            throw new NotFoundException("User profile was not found.");
        }
        return mapper.Map<UserProfileDto>(profile);
    }
}
