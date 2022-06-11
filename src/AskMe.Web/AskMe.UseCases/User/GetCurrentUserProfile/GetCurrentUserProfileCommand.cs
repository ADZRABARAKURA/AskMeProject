using AskMe.UseCases.Common.Dtos.UserProfiles;
using MediatR;

namespace AskMe.UseCases.User.GetCurrentUserProfile;

public record GetCurrentUserProfileCommand : IRequest<UserProfileDto>;
