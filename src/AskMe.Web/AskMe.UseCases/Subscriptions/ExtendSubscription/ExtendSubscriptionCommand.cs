using AskMe.UseCases.Common.Dtos.Subscriptions;
using MediatR;

namespace AskMe.UseCases.Subscriptions.ExtendSubscription;

public record ExtendSubscriptionCommand(ExtendUserSubscriptionDto UserSubscription) : IRequest;
