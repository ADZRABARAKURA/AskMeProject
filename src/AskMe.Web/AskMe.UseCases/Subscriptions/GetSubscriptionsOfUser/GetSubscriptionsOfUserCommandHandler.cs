using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Subscriptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.Subscriptions.GetSubscriptionsOfUser;

internal class GetSubscriptionsOfUserCommandHandler : IRequestHandler<GetSubscriptionsOfUserCommand, IEnumerable<UserSubscriptionDto>>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;

    public GetSubscriptionsOfUserCommandHandler(ILoggedUserAccessor loggedUserAccessor, IAppDbContext appDbContext, IMapper mapper)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<UserSubscriptionDto>> Handle(GetSubscriptionsOfUserCommand request, CancellationToken cancellationToken)
    {
        return await mapper
             .ProjectTo<UserSubscriptionDto>(appDbContext.UserSubscriptions)
             .Where(entity => entity.UserId == loggedUserAccessor.GetCurrentUserId())
             .ToListAsync(cancellationToken);
    }
}
