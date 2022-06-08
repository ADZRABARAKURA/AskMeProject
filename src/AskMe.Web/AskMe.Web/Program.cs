using AskMe.Domain.Users.Entities;
using AskMe.Infrastructure.DataAccess;
using AskMe.UseCases.User.CreatePost;
using AskMe.UseCases.User.CreateUser;
using AskMe.Web.StartUp;
using AskMe.Web.Web;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(new JwtOptionsSetup(
                configuration["Jwt:SecretKey"],
                configuration["Jwt:Issuer"]).Setup
);
builder.Services.AddDbContext<AppDbContext>(new DatabaseOptionsSetup(configuration.GetConnectionString("AskMeDb")).Setup);
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(SystemTextJsonHelper.GetAssemblyLocationByType(typeof(AskMe.UseCases.Common.Dtos.Post.CreatePostDto)));
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insert JWT token to the field.",
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "bearer",
        Type = SecuritySchemeType.Http
    });
    c.AddSecurityRequirement(SwaggerSecurityRequirement.GetSecurityRequrement());
    c.IncludeXmlComments(SystemTextJsonHelper.GetAssemblyLocationByType(typeof(AskMe.Web.Controllers.PostController)));
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

app.UseAuthentication();
app.UseAuthorization();
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
app.MapControllers();

app.Run();
