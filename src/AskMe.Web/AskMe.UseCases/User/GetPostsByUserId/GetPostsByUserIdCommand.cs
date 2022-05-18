using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.User.GetPostsByUserId;

/// <summary>
/// Get posts by user ID command.
/// </summary>
/// <param name="Id">User ID.</param>
public record GetPostsByUserIdCommand(Guid Id) : IRequest<IEnumerable<PostForStreamerDto>>;