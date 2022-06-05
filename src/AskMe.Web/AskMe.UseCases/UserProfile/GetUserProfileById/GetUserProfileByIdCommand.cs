using AskMe.UseCases.Common.Dtos.UserProfile;
using MediatR;

namespace AskMe.UseCases.UserProfiles.GetUserProfileById;

public record GetUserProfileByIdCommand(Guid Id) : IRequest<UserProfileDto>;
