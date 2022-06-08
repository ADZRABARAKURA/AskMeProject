using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.DomainServices;

public static class AuthenticationConstants
{
    public static readonly TimeSpan TokenExpirationTime = TimeSpan.FromDays(1);

    public const string IatClaimType = "iat";
}
