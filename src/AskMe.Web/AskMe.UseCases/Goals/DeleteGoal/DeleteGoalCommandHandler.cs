using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.Goals.DeleteGoal;

internal class DeleteGoalCommandHandler : AsyncRequestHandler<DeleteGoalCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;

    public DeleteGoalCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
    {
        var goal = await appDbContext.Goals.FirstOrDefaultAsync(g => g.Id == request.Id);
        if (goal == null)
        {
            throw new NotFoundException("Goal was not found.");
        }
        if (loggedUserAccessor.GetCurrentUserId() != goal.UserId)
        {
            throw new ForbiddenException("Only the user can delete goals for himself");
        }

        appDbContext.Goals.Remove(goal);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
