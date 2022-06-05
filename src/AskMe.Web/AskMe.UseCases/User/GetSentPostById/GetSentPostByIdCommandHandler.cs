using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Post;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.GetSentPostById;

internal class GetSentPostByIdCommandHandler : IRequestHandler<GetSentPostByIdCommand, PostForDonaterDto>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public GetSentPostByIdCommandHandler(IAppDbContext appDbContext, IMapper mapper, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    public async Task<PostForDonaterDto> Handle(GetSentPostByIdCommand request, CancellationToken cancellationToken)
    {
        var post = await appDbContext.Posts
            .FirstOrDefaultAsync(entity => entity.Id == request.Id);
        if (post is null || loggedUserAccessor.GetCurrentUserId() != post.AuthorId)
        {
            throw new NotFoundException("Such post does not exist.");
        }
        return mapper.Map<PostForDonaterDto>(post);
    }
}
