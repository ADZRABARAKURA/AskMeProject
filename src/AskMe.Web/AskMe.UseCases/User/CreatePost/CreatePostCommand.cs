using AskMe.UseCases.Common.Dtos.Post;
using MediatR;

namespace AskMe.UseCases.User.CreatePost;

public record CreatePostCommand(PostDto Post) : IRequest;
