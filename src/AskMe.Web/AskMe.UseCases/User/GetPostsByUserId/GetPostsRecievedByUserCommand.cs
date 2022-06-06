using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.User.GetPostsByUserId;

/// <summary>
/// Get posts by user ID command.
/// </summary>
public record GetPostsRecievedByUserCommand : IRequest<IEnumerable<PostForStreamerDto>>;