using AskMe.Domain.Entities.User;
using AskMe.Infrastructure.Abstractions.Interfaces;
using AskMe.Infrastructure.DataAccess;
using AskMe.UseCases.User.CreateUser;
using AskMe.Web.Web;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
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
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IJsonHelper, SystemTextJsonHelper>();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<ILoggedUserAccessor, LoggedUserAccessor>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/auth/login";
    options.LogoutPath = $"/auth/logout";
});
var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
            configuration.GetConnectionString("AskMeDb"),
            sqlOptions => sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name)));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AskMeApi",
        Version = "v1"
    });
});

var app = builder.Build();

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
