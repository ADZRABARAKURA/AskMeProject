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
internal class GetPostsRecievedByUserCommandHandler : IRequestHandler<GetPostsRecievedByUserCommand, IEnumerable<PostForStreamerDto>>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public GetPostsRecievedByUserCommandHandler(IAppDbContext appDbContext, IMapper mapper, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
        this.loggedUserAccessor = loggedUserAccessor;
    }


    public async Task<IEnumerable<PostForStreamerDto>> Handle(GetPostsRecievedByUserCommand request, CancellationToken cancellationToken)
    {
        var posts = await appDbContext.Posts
            .Where(post => post.RecieverId == loggedUserAccessor.GetCurrentUserId())
            .ToListAsync(cancellationToken);
        return mapper.Map<IEnumerable<PostForStreamerDto>>(posts);
    }
}
