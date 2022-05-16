using AskMe.Domain.Users.Entities;
using AskMe.Infrastructure.DataAccess;
using AskMe.UseCases.User.CreatePost;
using AskMe.UseCases.User.CreateUser;
using AskMe.Web.StartUp;
using AskMe.Web.Web;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "AskMe.AuthCookie";
            });
builder.Services.AddMediatR(typeof(CreateUserCommand).Assembly);
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(new IdentityOptionsSetup().Setup);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/auth/login";
    options.LogoutPath = $"/auth/logout";
});
var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(new DatabaseOptionsSetup(configuration.GetConnectionString("AskMeDb")).Setup);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AskMeApi",
        Version = "v1"
    });
});
builder.Services.AddAutoMapper(typeof(CreatePostCommand).Assembly);
AskMe.Web.DI.ApplicationServices.Register(builder.Services);

var app = builder.Build();

#region InitializeDatabase
using (var scope = app.Services.CreateScope())
using (var appDbContext = scope.ServiceProvider.GetService<AppDbContext>())
using (var roleManager = scope.ServiceProvider.GetService<RoleManager<ApplicationRole>>())
{
    var dbInitializer = new DatabaseInitializer(appDbContext, roleManager);
    await dbInitializer.InitializeAsync();
}
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "AksMeApi v1");
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<ApiExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();
