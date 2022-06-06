using AskMe.UseCases.Common.Dtos.Subscriptions;
using MediatR;

namespace AskMe.UseCases.Subscriptions.SubscribeUser;

public record SubscribeUserCommand(CreateUserSubscriptionDto UserSubscription) : IRequest;
