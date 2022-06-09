using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.Publications.UpdatePublication;

public record UpdatePublicationCommand(UpdatePublicationDto Publication) : IRequest;
