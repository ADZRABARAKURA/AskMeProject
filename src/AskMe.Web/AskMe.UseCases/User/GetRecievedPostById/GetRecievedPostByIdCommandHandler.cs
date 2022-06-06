using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Post;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.UseCases.User.GetRecievedPostById;

internal class GetRecievedPostByIdCommandHandler : IRequestHandler<GetRecievedPostByIdCommand, PostForStreamerDto>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IMapper mapper;

    public GetRecievedPostByIdCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
        this.mapper = mapper;
    }

    public async Task<PostForStreamerDto> Handle(GetRecievedPostByIdCommand request, CancellationToken cancellationToken)
    {
        var post = await appDbContext.Posts
            .FirstOrDefaultAsync(entity => entity.Id == request.Id);
        if (post is null || post.RecieverId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new NotFoundException("Such post does not exist.");
        }
        return mapper.Map<PostForStreamerDto>(post);
    }
}
