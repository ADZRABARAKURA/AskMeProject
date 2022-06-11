using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Subscriptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.Subscriptions;

internal class GetSubscriptionsByUserIdCommandHandler : IRequestHandler<GetSubscriptionsByUserIdCommand, IEnumerable<SubscriptionDto>>
{
    private readonly IMapper mapper;
    private readonly IAppDbContext appDbContext;

    public GetSubscriptionsByUserIdCommandHandler(IMapper mapper, IAppDbContext appDbContext)
    {
        this.mapper = mapper;
        this.appDbContext = appDbContext;
    }

    public async Task<IEnumerable<SubscriptionDto>> Handle(GetSubscriptionsByUserIdCommand request, CancellationToken cancellationToken)
    {
        var subscriptions = await appDbContext.Subscriptions
            .Where(entity => entity.UserId == request.Id && entity.IsActive)
            .ToListAsync(cancellationToken);
        return mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
    }
}
