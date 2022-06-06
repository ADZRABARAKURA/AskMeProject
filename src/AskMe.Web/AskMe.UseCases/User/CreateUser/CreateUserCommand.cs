using AskMe.UseCases.Common.Dtos.User;
using MediatR;

namespace AskMe.UseCases.User.CreateUser;

public record CreateUserCommand(UserDto User) : IRequest;
