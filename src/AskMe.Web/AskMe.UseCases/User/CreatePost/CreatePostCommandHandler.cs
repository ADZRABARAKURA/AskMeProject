using AskMe.Domain.Entities.Post;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;

namespace AskMe.UseCases.User.CreatePost;

internal class CreatePostCommandHandler : AsyncRequestHandler<CreatePostCommand>
{
    private readonly IAppDbContext appDbContext;
    
    public CreatePostCommandHandler(IAppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post()
        {
            UserId = request.Post.UserId,
            SentDate = DateTime.UtcNow,
            AuthorName = request.Post.AuthorName,
            Currency = request.Post.Currency,
            Text = request.Post.Text,
            Value = request.Post.Value
        };
        await appDbContext.Posts.AddAsync(post, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);
    }
}
