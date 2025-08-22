using Microsoft.AspNetCore.Authentication;

namespace STC.Shared.Auth.Consumer;

public class CustomAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "STC.CustomAuthScheme";
}