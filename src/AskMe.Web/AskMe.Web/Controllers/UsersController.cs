using AskMe.UseCases.Common.Dtos.User;
using AskMe.UseCases.User.GetUsersByNamePart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AskMe.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get users whose nicknames start 
        /// with the input string.
        /// </summary>
        /// <param name="startsWith">The string that the name starts with</param>
        /// <returns>List of users.</returns>
        [ProducesResponseType(typeof(IEnumerable<SearchUserDto>), 200)]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<SearchUserDto>> GetUsers([FromQuery] string startsWith, CancellationToken cancellationToken)
        {
            var command = new GetUsersByNamePartCommand(startsWith);
            return await mediator.Send(command, cancellationToken);
        }
    }
}
