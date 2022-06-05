using MediatR;

namespace AskMe.UseCases.Role.GiveRoleToUser;

public record GiveRoleToUserCommand(Guid Id, string RoleName) : IRequest;
