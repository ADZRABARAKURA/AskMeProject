using AskMe.Domain.Entities.User;
using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.UseCases.User.CreateUser;

public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly UserManager<ApplicationUser> userManager;

    public CreateUserCommandHandler(ILoggedUserAccessor loggedUserAccessor, UserManager<ApplicationUser> userManager)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.userManager = userManager;
    }

    protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (loggedUserAccessor.GetCurrentUserId() != default)
        {
            throw new ValidationException("Logged user can not register new account.");
        }

        var user = new ApplicationUser()
        {
            UserName = request.User.UserName,
            Email = request.User.Email
        };
        await userManager.CreateAsync(user, request.User.Password);
    }
}
