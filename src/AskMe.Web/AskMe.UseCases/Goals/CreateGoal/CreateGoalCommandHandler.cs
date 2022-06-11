using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.Domain.Posts.Entities;
using MediatR;

namespace AskMe.UseCases.Goals.CreateGoal;

internal class CreateGoalCommandHandler : AsyncRequestHandler<CreateGoalCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public CreateGoalCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(CreateGoalCommand request, CancellationToken cancellationToken)
    {
        if (loggedUserAccessor.GetCurrentUserId() != request.Goal.UserId)
        {
            throw new ForbiddenException("Only the user can create goals for himself");
        }
        await appDbContext.Goals.AddAsync(new Goal()
        {
            UserId = request.Goal.UserId,
            Value = request.Goal.Value,
            CreationDate = DateTime.Now,
            Title = request.Goal.Title,
        }, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
