using AskMe.UseCases.Common.Dtos.UserProfiles;
using MediatR;

namespace AskMe.UseCases.UserProfiles.EditUserProfile;

public record EditUserProfileCommand(EditUserProfileDto Profile) : IRequest;
