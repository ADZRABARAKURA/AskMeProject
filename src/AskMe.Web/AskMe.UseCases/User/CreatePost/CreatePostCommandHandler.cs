using AskMe.Domain.Posts.Entities;
using AskMe.Domain.Users.Entities;
using AskMe.DomainServices.Exceptions;
using AskMe.Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AskMe.UseCases.User.CreatePost;

internal class CreatePostCommandHandler : AsyncRequestHandler<CreatePostCommand>
{
    private readonly IAppDbContext appDbContext;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly ILoggedUserAccessor loggedUserAccessor;
    
    public CreatePostCommandHandler(IAppDbContext appDbContext, ILoggedUserAccessor loggedUserAccessor, UserManager<ApplicationUser> userManager)
    {
        this.appDbContext = appDbContext;
        this.loggedUserAccessor = loggedUserAccessor;
        this.userManager = userManager;
    }
        
    protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var authorId = loggedUserAccessor.GetCurrentUserId();
        var reciever = await userManager.FindByIdAsync($"{request.Post.UserId}");
        if (reciever is null)
        {
            throw new NotFoundException("There is no user with such id.");
        }
        if (request.Post.GoalId != Guid.Empty)
        {
            var goal = await appDbContext.Goals
                .FirstOrDefaultAsync(g => g.Id == request.Post.GoalId);
            if (goal == null)
            {
                throw new NotFoundException("Goal was not found");
            }
            goal.CurrentValue += request.Post.Value;
        }
        var post = new Post()
        {
            RecieverId = reciever.Id,
            RecieverName = reciever.UserName,
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
