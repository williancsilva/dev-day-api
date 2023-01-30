using DevSecOps.backoffice.Domain.Interfaces.Service;
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
    private readonly IAutenticacaoService _autenticacaoService;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IAutenticacaoService autenticacaoService)
        : base(options, logger, encoder, clock)
    {
        _autenticacaoService = autenticacaoService;
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
            Request.Headers.TryGetValue("dayId", out var dayId);
            result = await _autenticacaoService.ObterSessao(new SessaoSignature(Convert.ToInt32(dayId)));
        }
        catch
        {
            return AuthenticateResult.Fail("Header de autorização inválido");
        }

        if (result == null || result.IsAuthenticated == false)
            return AuthenticateResult.Fail("Autenticação Inválida");

        Context.Items["UserSession"] = result;

        var claimsUser = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, result.DayId.ToString() ?? string.Empty)
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