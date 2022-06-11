using AskMe.UseCases.Common.Dtos.Post;
using AskMe.UseCases.Publications.DeletePublication;
using AskMe.UseCases.Publications.UpdatePublication;
using AskMe.UseCases.Publications.CreatePublication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers;

[Route("api/publication")]
[ApiController]
public class PublicationController : ControllerBase
{
    private readonly IMediator mediator;
    public PublicationController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Create a new publication.
    /// </summary>
    /// <param name="publication">Publication to create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize]
    [HttpPost]
    public async Task Create(CreatePublicationDto publication, CancellationToken cancellationToken)
    {
        var command = new CreatePublicationCommand(publication);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Delete publication by id.
    /// </summary>
    /// <param name="id">Publication id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize]
    [HttpDelete]
    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeletePublicationCommand(id);
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Update publication.
    /// </summary>
    /// <param name="publication">Publication.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize]
    [HttpPatch]
    public async Task Update([FromForm] UpdatePublicationDto publication, CancellationToken cancellationToken)
    {
        var command = new UpdatePublicationCommand(publication);
        await mediator.Send(command, cancellationToken);
    }
}
