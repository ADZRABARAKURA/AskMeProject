using AskMe.UseCases.Common.Dtos.User;
using MediatR;

namespace AskMe.UseCases.User.LoginUser;

public record LoginUserCommand(UserLoginDto User) : IRequest;
