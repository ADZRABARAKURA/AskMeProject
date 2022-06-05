using AskMe.Domain.Users.Entities;
using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.UserProfile;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.UserProfiles.GetUserProfileById;

internal class GetUserProfileByIdCommandHandler : IRequestHandler<GetUserProfileByIdCommand, UserProfileDto>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IMapper mapper;
    private readonly IAppDbContext appDbContext;

    public GetUserProfileByIdCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper, IAppDbContext appDbContext)
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.appDbContext = appDbContext;
    }

    public async Task<UserProfileDto> Handle(GetUserProfileByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync($"{request.Id}");
        if (user is null)
        {
            throw new NotFoundException("User with this id was not found.");
        }
        var profile = await appDbContext.Profiles
            .FirstOrDefaultAsync(entity => entity.UserId == user.Id);
        return mapper.Map<UserProfileDto>(profile);
    }
}
