using AskMe.Domain.Users.Entities;
using AskMe.DomainServices.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AskMe.UseCases.Role.GiveRoleToUser;

internal class GiveRoleToUserCommandHandler : AsyncRequestHandler<GiveRoleToUserCommand>
{
    private readonly UserManager<ApplicationUser> userManager;

    public GiveRoleToUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        this.userManager = userManager;
    }

    protected override async Task Handle(GiveRoleToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync($"{request.Id}");
        if (user is null)
        {
            throw new NotFoundException("User with such id was not found.");
        }
        var result = await userManager.AddToRoleAsync(user, request.RoleName);
        if (!result.Succeeded)
        {
            throw new ServerErrorException("An error occurred while trying to add a user to a role");
        }
    }
}
