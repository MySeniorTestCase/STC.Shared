using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using STC.Shared.Contracts.Auth;

namespace STC.Shared.Auth.Consumer;

/// <summary>
/// The custom authentication handler should use by all microservices that need to authenticate users based on headers set by the API gateway.
/// </summary>
/// <param name="options"></param>
/// <param name="logger"></param>
/// <param name="encoder"></param>
public class CustomAuthenticationHandler(
    IOptionsMonitor<CustomAuthenticationOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder)
    : AuthenticationHandler<CustomAuthenticationOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (base.Context.GetEndpoint()?.Metadata.GetMetadata<IAllowAnonymous>() is not null)
            return Task.FromResult(AuthenticateResult.Success(ticket: new AuthenticationTicket(
                principal: new ClaimsPrincipal(identities: []),
                authenticationScheme: CustomAuthenticationOptions.DefaultScheme)));

        // Api gateway will set these headers and pass them to the microservices

        ICollection<Claim> claims = [];

        if (base.Context.Request.Headers.TryGetValue(key: SharedClaimConstants.UserId, out StringValues userId))
            claims.Add(new Claim(type: ClaimTypes.NameIdentifier, value: userId.ToString()));
        else
            return Task.FromResult(AuthenticateResult.Fail(failureMessage: "UserId is not found in the headers.",
                properties: null));

        if (base.Context.Request.Headers.TryGetValue(key: SharedClaimConstants.Role, out StringValues roleClaim))
            claims.Add(new Claim(type: ClaimTypes.Role, value: roleClaim.ToString()));

        AuthenticationTicket ticket = new AuthenticationTicket(
            principal: new ClaimsPrincipal(identities:
            [
                new ClaimsIdentity(claims: claims,
                    authenticationType: CustomAuthenticationOptions.DefaultScheme)
            ]),
            authenticationScheme: CustomAuthenticationOptions.DefaultScheme);

        return Task.FromResult(AuthenticateResult.Success(ticket: ticket));
    }
}