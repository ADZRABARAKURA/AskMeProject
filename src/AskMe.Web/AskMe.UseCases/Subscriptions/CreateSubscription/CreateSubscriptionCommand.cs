using AskMe.UseCases.Common.Dtos.Subscriptions;
using MediatR;

namespace AskMe.UseCases.Subscriptions.CreateSubscription;

public record CreateSubscriptionCommand(CreateSubscriptionDto Subscription) : IRequest;
