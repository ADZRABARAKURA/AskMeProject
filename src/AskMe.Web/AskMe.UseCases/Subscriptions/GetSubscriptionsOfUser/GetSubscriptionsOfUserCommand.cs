using AskMe.UseCases.Common.Dtos.Subscriptions;
using MediatR;

namespace AskMe.UseCases.Subscriptions.GetSubscriptionsOfUser;

public record GetSubscriptionsOfUserCommand : IRequest<IEnumerable<UserSubscriptionDto>>;
