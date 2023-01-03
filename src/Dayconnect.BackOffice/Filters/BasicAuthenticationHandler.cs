using DevSecOps.backoffice.Domain.Interfaces.ExternalService;
using DevSecOps.backoffice.Domain.Models.Result;
using DevSecOps.backoffice.Domain.Models.Signature;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace DevSecOps.backoffice.Filters;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IAccessControlSession _accessControl;
    private const int CodSistema = 353;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IAccessControlSession accessControl)
        : base(options, logger, encoder, clock)
    {
        _accessControl = accessControl;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata.GetMetadata<IAllowAnonymous>() != null)
            return AuthenticateResult.NoResult();

        if (!Request.Headers.ContainsKey("dayId"))
            return AuthenticateResult.Fail("Não contem header de autorização");

        SessaoResult? result;

        try
        {
            Request.Headers.TryGetValue("dayId", out var sessionId);
            result = await _accessControl.ObterSessao(new SessaoSignature(sessionId.ToString()));
        }
        catch
        {
            return AuthenticateResult.Fail("Header de autorização inválido");
        }

        if (result == null || result.IsAuthenticated == false || result.CodSistema != CodSistema)
            return AuthenticateResult.Fail("Autenticação Inválida");

        Context.Items["UserSession"] = result;

        var claimsUser = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, result.Id ?? string.Empty)
        };

        if (result.Permission.Features != null)
            claimsUser.AddRange(result.Permission.Features.Select(x => new Claim(ClaimTypes.Role, x)));

        var claims = claimsUser.ToArray();
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}