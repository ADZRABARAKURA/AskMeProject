using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.Goals.CreateGoal;

public record CreateGoalCommand(CreateGoalDto Goal) : IRequest;
