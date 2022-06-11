using AskMe.UseCases.Common.Dtos.UserProfiles;
using MediatR;

namespace AskMe.UseCases.UserProfiles.GetUserProfileById;

public record GetUserProfileByIdCommand(Guid Id) : IRequest<UserProfileDto>;
