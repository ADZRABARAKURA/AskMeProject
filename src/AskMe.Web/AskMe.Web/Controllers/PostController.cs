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

    /// <summary>
    /// Create a post(donate to a streamer).
    /// </summary>
    /// <param name="post">Post to create.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [HttpPost("")]
    public async Task Create([FromForm] CreatePostDto post, CancellationToken cancellationToken)
    {
        var command = new CreatePostCommand(post);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get a post that was created by a currently logged in user
    /// by post id.
    /// </summary>
    /// <param name="id">Post id.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>Post.</returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [HttpGet("history/sent/{id}")]
    [Authorize(Roles = ExistingRoles.User)]
    public async Task<PostForDonaterDto> GetSentPostById(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetSentPostByIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }


    /// <summary>
    /// Get a post that was received by a currently logged in user
    /// by post id.
    /// </summary>
    /// <param name="id">Post id</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>Post.</returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [HttpGet("history/received/{id}")]
    [Authorize(Roles = ExistingRoles.Streamer)]
    public async Task<PostForStreamerDto> GetRecievedPostById(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetRecievedPostByIdCommand(id);
        return await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get a list of posts that were received by currently logged in user.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of posts.</returns>
    [ProducesResponseType(200)]
    [HttpGet("history/received")]
    [Authorize(Roles = ExistingRoles.Streamer)]
    public async Task<IEnumerable<PostForStreamerDto>> GetUserPosts( CancellationToken cancellationToken)
    {
        var command = new GetPostsRecievedByUserCommand();
        return await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get a list of posts that were created by currently logged in user.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token to cancel the request</param>
    /// <returns>A list of posts.</returns>
    [ProducesResponseType(200)]
    [HttpGet("history/sent")]
    [Authorize(Roles = ExistingRoles.User)]
    public async Task<IEnumerable<PostForDonaterDto>> GetPostsCreatedByUser(CancellationToken cancellationToken)
    {
        var command = new GetPostsCreatedByUserCommand();
        return await mediator.Send(command, cancellationToken);
    }
}

