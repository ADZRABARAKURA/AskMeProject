using Microsoft.AspNetCore.Identity;

namespace AskMe.Web.Web;

public class IdentityOptionsSetup
{
    public void Setup(IdentityOptions options)
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequireNonAlphanumeric = false;
    }
}