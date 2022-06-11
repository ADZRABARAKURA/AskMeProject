using AskMe.UseCases.Common.Dtos.Post;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.UseCases.Goals.GetGoalsByUserId;

public record GetGoalsByUserIdCommand(Guid Id) : IRequest<IEnumerable<GoalDto>>;
