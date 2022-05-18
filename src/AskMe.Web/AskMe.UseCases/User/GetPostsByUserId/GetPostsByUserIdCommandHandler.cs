using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Post;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.GetPostsByUserId;

/// <summary>
/// Get posts by user ID command handler.
/// </summary>
internal class GetPostsByUserIdCommandHandler : IRequestHandler<GetPostsByUserIdCommand, IEnumerable<PostForStreamerDto>>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public GetPostsByUserIdCommandHandler(IAppDbContext appDbContext, IMapper mapper, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
        this.loggedUserAccessor = loggedUserAccessor;
    }


    public async Task<IEnumerable<PostForStreamerDto>> Handle(GetPostsByUserIdCommand request, CancellationToken cancellationToken)
    {
        if (loggedUserAccessor.GetCurrentUserId() != request.Id)
        {
            throw new NotFoundException("No posts found.");
        }
        var posts = await appDbContext.Posts
            .Where(post => post.UserId == request.Id)
            .ToListAsync(cancellationToken);
        return mapper.Map<IEnumerable<PostForStreamerDto>>(posts);
    }
}
