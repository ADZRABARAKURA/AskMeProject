using AskMe.Desktop.Dtos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AskMe.Desktop.Services;

public class ApiService
{
    private DateTime lastCheckTime;
    private readonly RestClient client;
    private readonly string defaultUrlPart;
    private readonly AuthService authService;

    public ApiService(AuthService authService)
    {
        client = new RestClient();
        defaultUrlPart = GetDefaultUrlPart();
        this.authService = authService;
    }

    private string GetDefaultUrlPart()
    {
        var document = XDocument.Load("AppConfig.xml");
        return document.Root.Value;
    }

    public async Task<IEnumerable<PostDto>> GetPosts()
    {
        var request = new RestRequest($"{defaultUrlPart}");
        var posts = await client.GetAsync<IEnumerable<PostDto>>(request);
        return posts;
    }

    public async Task AuthenticateUser(string identifier, string password)
    {
        var request = new RestRequest($"{defaultUrlPart}/auth/login");
        var form = new AuthDto()
        {
            Identifier = identifier,
            Password = password
        };
        request.AddBody(identifier, "multipart/form-data");
        request.AddBody(password, "multipart/form-data");
        var result = await client.PostAsync(request);
        Console.WriteLine(result.Content);
        //authService.Token = result.Token.Token;
        //authService.UserId = result.Id;
    }
}
