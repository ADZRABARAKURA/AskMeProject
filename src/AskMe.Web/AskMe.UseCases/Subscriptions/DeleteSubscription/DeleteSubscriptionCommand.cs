using MediatR;

namespace AskMe.UseCases.Subscriptions.DeleteSubscription;

public record DeleteSubscriptionCommand(Guid Id) : IRequest;
