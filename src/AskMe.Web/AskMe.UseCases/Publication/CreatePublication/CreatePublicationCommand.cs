using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.Publications.CreatePublication;

public record CreatePublicationCommand(CreatePublicationDto Publication) : IRequest;
