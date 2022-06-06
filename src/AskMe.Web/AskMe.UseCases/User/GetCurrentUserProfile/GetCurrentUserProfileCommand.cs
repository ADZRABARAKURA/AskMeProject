using AskMe.UseCases.Common.Dtos.UserProfile;
using MediatR;

namespace AskMe.UseCases.User.GetCurrentUserProfile;

public record GetCurrentUserProfileCommand : IRequest<UserProfileDto>;
