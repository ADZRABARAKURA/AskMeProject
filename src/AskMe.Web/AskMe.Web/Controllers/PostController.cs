using AskMe.UseCases.Common.Dtos.Post;
using AskMe.UseCases.User.CreatePost;
using AskMe.UseCases.User.GetPostsByUserId;
using AskMe.UseCases.User.GetPostsCreatedByUser;
using AskMe.UseCases.User.GetRecievedPostById;
using AskMe.UseCases.User.GetSentPostById;
using AskMe.Web.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers;

[Route("api/post/")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IMediator mediator;

    public PostController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("")]
    public async Task Create([FromForm] CreatePostDto post, CancellationToken cancellationToken)
    {
        var command = new CreatePostCommand(post);
        await mediator.Send(command, cancellationToken);
    }

    [HttpGet("history/sent/{id}")]
    [Authorize(Roles = ExistingRoles.User)]
    public async Task<PostForDonaterDto> GetSentPostById(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetSentPostByIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }

    [HttpGet("history/received/{id}")]
    [Authorize(Roles = ExistingRoles.Streamer)]
    public async Task<PostForStreamerDto> GetRecievedPostById(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetRecievedPostByIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }

    [HttpGet("history/received/{id}")]
    [Authorize(Roles = ExistingRoles.Streamer)]
    public async Task<IEnumerable<PostForStreamerDto>> GetUserPosts(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetPostsByUserIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }

    [HttpGet("history/sent")]
    [Authorize(Roles = ExistingRoles.User)]
    public async Task<IEnumerable<PostForDonaterDto>> GetPostsCreatedByUser(CancellationToken cancellationToken)
    {
        var command = new GetPostsCreatedByUserCommand();
        return await mediator.Send(command, cancellationToken);
    }
}

