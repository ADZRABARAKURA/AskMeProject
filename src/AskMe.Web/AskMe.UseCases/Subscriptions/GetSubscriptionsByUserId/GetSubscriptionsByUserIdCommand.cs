using AskMe.UseCases.Common.Dtos.Subscriptions;
using MediatR;

namespace AskMe.UseCases.Subscriptions;

public record GetSubscriptionsByUserIdCommand(Guid Id) : IRequest<IEnumerable<SubscriptionDto>>;
