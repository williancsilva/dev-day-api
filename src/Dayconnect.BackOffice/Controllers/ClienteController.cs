using Dayconnect.backoffice.App.Dto.Result;
using Dayconnect.backoffice.App.Dto.Signature;
using Dayconnect.backoffice.App.Interfaces;
using Dayconnect.backoffice.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Dayconnect.backoffice.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = "BasicAuthenticationHandler")]
public class ClienteController : ControllerBase
{
    private readonly IClienteApp _app;

    public ClienteController(IClienteApp app)
    {
        _app = app;
    }

    [HttpPost]
    [Route(nameof(ObterDadosCliente))]
    [SwaggerOperation("Obtem informações do cliente")]
    [ProducesResponseType(typeof(ObterDadosClienteResult), (int) HttpStatusCode.OK)]
    [Authorize(Roles = "consultar")]
    [AcoesFilterAttribute]
    public async Task<IActionResult> ObterDadosCliente([SwaggerRequestBody("A signature para obter o cliente", Required = true)] ObterDadosClienteSignature signature)
    {
        var result = await _app.ObterDadosCliente(signature);
        return Ok(result);
    }

    [HttpPost]
    [Route(nameof(InativaCliente))]
    [SwaggerOperation("Inativa o cliente Dayconnect")]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [Authorize(Roles = "bloquear")]
    [AcoesFilterAttribute]
    public async Task<IActionResult> InativaCliente(
        [FromBody, SwaggerRequestBody("A signature para inativar o cliente", Required = true)] InativarClienteSignature signature)
    {
        await _app.InativarCliente(signature);
        return Ok("Cliente inativado com sucesso!");
    }
}