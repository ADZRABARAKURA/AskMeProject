using MediatR;

namespace AskMe.UseCases.Goals.DeleteGoal;

public record DeleteGoalCommand(Guid Id) : IRequest;
