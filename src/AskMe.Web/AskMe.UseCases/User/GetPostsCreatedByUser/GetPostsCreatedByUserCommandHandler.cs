using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Post;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.GetPostsCreatedByUser;

internal class GetPostsCreatedByUserCommandHandler : IRequestHandler<GetPostsCreatedByUserCommand, IEnumerable<PostDto>>
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

    public Task<IEnumerable<PostDto>> Handle(GetPostsCreatedByUserCommand request, CancellationToken cancellationToken)
    {
        if (loggedUserAccessor.GetCurrentUserId() != request.Id)
        {
            throw new NotFoundException("");
        }

        var posts = mapper.ProjectTo<PostDto>(appDbContext.Posts)
            .Where(post => post.AuthorID == request.Id)
            .ToListAsync(cancellationToken);
    }
}
