using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Authorization.Handlers
{
    public class CookieHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public CookieHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock):base(options,logger,encoder,clock)
        {

        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var username = Request.Query["username"];
            var password = Request.Query["password"];

            if(username == "pradip" && password == "password")
            {

                var claims = new List<Claim>()
                {
                    new Claim("user" , "pradip"),
                    new Claim("canRead" , "Y")
                };

                var principle = new ClaimsPrincipal(new ClaimsIdentity(claims, "MyScheme"));
                return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principle, "MyScheme")));
            } else
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Credentials!!"));
            }

        }
    }
}
