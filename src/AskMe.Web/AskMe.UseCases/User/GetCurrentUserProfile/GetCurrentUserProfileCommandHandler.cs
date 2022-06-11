using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.UserProfiles;
using AskMe.UseCases.UserProfiles.GetUserProfileById;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.GetCurrentUserProfile;

internal class GetCurrentUserProfileCommandHandler : IRequestHandler<GetCurrentUserProfileCommand, UserProfileDto>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IMapper mapper;
    private readonly IMediator mediator;

    public GetCurrentUserProfileCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor, IMapper mapper, IMediator mediator)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
        this.mapper = mapper;
        this.mediator = mediator;
    }

    public async Task<UserProfileDto> Handle(GetCurrentUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userId = loggedUserAccessor.GetCurrentUserId();
        var command = new GetUserProfileByIdCommand(userId.GetValueOrDefault());
        var profile = await mediator.Send(command, cancellationToken);
        return mapper.Map<UserProfileDto>(profile);
    }
}
