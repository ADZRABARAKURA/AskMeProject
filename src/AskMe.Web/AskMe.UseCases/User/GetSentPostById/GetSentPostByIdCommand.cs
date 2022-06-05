using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.User.GetSentPostById;

public record GetSentPostByIdCommand(Guid Id) : IRequest<PostForDonaterDto>;
