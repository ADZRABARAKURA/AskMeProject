using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Post;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.GetPostsCreatedByUser;

internal class GetPostsCreatedByUserCommandHandler : IRequestHandler<GetPostsCreatedByUserCommand, IEnumerable<PostForDonaterDto>>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public GetPostsCreatedByUserCommandHandler(IAppDbContext appDbContext, IMapper mapper, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    public async Task<IEnumerable<PostForDonaterDto>> Handle(GetPostsCreatedByUserCommand request, CancellationToken cancellationToken)
    {
        var userId = loggedUserAccessor.GetCurrentUserId();
        if (userId == default)
        {
            throw new NotFoundException("");
        }

        var posts = await appDbContext.Posts
            .Where(post => post.AuthorId == userId)
            .ToListAsync(cancellationToken);
        return mapper.Map<IEnumerable<PostForDonaterDto>>(posts);
    }
}
