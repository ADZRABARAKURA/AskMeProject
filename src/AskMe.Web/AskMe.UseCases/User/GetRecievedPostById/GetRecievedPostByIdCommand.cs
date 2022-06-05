using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.User.GetRecievedPostById;

public record GetRecievedPostByIdCommand(Guid Id) : IRequest<PostForStreamerDto>;
