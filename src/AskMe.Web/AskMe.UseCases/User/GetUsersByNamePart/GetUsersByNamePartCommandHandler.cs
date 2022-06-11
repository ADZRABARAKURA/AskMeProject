using AskMe.Domain.Users.Entities;
using AskMe.UseCases.Common.Dtos.User;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.GetUsersByNamePart;

internal class GetUsersByNamePartCommandHandler : IRequestHandler<GetUsersByNamePartCommand, IEnumerable<SearchUserDto>>
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IMapper mapper;

    public GetUsersByNamePartCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<SearchUserDto>> Handle(GetUsersByNamePartCommand request, CancellationToken cancellationToken)
    {
        return await mapper.ProjectTo<SearchUserDto>(userManager.Users)
            .Where(user => user.Name
                .StartsWith(request.Part))
            .ToListAsync(cancellationToken);
    }
}
