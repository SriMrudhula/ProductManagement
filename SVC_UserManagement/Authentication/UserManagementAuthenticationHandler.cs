using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace UserManagement.Authentication
{
    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {

    }
    public class UserManagementAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>

    {

        private readonly IUserManagementAuthenticationManager iUserManagementAuthenticationManager;
            public UserManagementAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options,ILoggerFactory logger,
            UrlEncoder encoder,ISystemClock clock,IUserManagementAuthenticationManager iUserManagementAuthenticationManager)
            : base(options, logger, encoder, clock)
            {
                this.iUserManagementAuthenticationManager =iUserManagementAuthenticationManager;
            }
            protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
            {
                if (!Request.Headers.ContainsKey("Authorization"))
                    return AuthenticateResult.Fail("Unauthorized");
                string authorizationHeader = Request.Headers["Authorization"];
                if (string.IsNullOrEmpty(authorizationHeader))
                {
                    return AuthenticateResult.NoResult();
                }
                if (!authorizationHeader.StartsWith("bearer", StringComparison.OrdinalIgnoreCase))
                {
                    return AuthenticateResult.Fail("Unauthorized");
                }
                string token = authorizationHeader.Substring("bearer".Length).Trim();
                if (string.IsNullOrEmpty(token))
                {
                    return AuthenticateResult.Fail("Unauthorized");
                }
                try
                {
                    return validateToken(token);
                }
                catch (Exception ex)
                {
                    return AuthenticateResult.Fail(ex.Message);
                }
            }
            private AuthenticateResult validateToken(string token)
            {
                var validatedToken = iUserManagementAuthenticationManager.Tokens.FirstOrDefault(t => t.Key == token);
                if (validatedToken.Key == null)
                {
                    return AuthenticateResult.Fail("Unauthorized");
                }
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, validatedToken.Value),
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new System.Security.Principal.GenericPrincipal(identity, null);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
        }
    }
