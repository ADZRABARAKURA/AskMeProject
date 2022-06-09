using MediatR;

namespace AskMe.UseCases.Publications.DeletePublication;

public record DeletePublicationCommand(Guid Id) : IRequest;
