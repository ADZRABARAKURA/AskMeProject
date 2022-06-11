using AskMe.UseCases.Common.Dtos.User;
using MediatR;

namespace AskMe.UseCases.User.GetUsersByNamePart;

public record GetUsersByNamePartCommand(string Part) : IRequest<IEnumerable<SearchUserDto>>;