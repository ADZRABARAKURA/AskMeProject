using AskMe.Domain.Posts.Entities;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace AskMe.UseCases.User.CreatePost;

internal class CreatePostCommandHandler : AsyncRequestHandler<CreatePostCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    public CreatePostCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var authorId = loggedUserAccessor.GetCurrentUserId();
        var post = new Post()
        {
            UserId = request.Post.UserId,
            SentDate = DateTime.UtcNow,
            AuthorName = request.Post.AuthorName,
            Currency = request.Post.Currency,
            Text = request.Post.Text,
            Value = request.Post.Value,
            AuthorId = authorId
        };
        await appDbContext.Posts.AddAsync(post, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
