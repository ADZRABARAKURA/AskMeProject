using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.UseCases.Common.Dtos.Post;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.Goals.GetGoalsByUserId;

internal class GetGoalsByUserIdCommandHandler : IRequestHandler<GetGoalsByUserIdCommand, IEnumerable<GoalDto>>
{
    private readonly IAppDbContext appDbContext;
    private readonly IMapper mapper;

    public GetGoalsByUserIdCommandHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<GoalDto>> Handle(GetGoalsByUserIdCommand request, CancellationToken cancellationToken)
    {
        return await mapper
            .ProjectTo<GoalDto>(appDbContext.Goals)
            .Where(g => g.UserId == request.Id)
            .ToListAsync(cancellationToken);
    }
}
