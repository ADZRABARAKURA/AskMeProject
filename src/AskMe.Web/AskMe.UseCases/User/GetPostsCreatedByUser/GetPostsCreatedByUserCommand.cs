using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.User.GetPostsCreatedByUser;

public record GetPostsCreatedByUserCommand : IRequest<IEnumerable<PostForDonaterDto>>;