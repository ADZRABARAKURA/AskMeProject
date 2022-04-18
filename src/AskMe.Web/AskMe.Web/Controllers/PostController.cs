using AskMe.UseCases.Common.Dtos.Post;
using AskMe.UseCases.User.CreatePost;
using MediatR;
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

    [HttpPost("create")]
    public async Task Register([FromForm] PostDto post, CancellationToken cancellationToken)
    {
        var command = new CreatePostCommand(post);
        await mediator.Send(command, cancellationToken);
    }
}

