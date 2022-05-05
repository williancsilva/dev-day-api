using Dayconnect.Fidelity.App.Dto.Result;
using Dayconnect.Fidelity.App.Dto.Signature;
using Dayconnect.Fidelity.App.Interfaces;
using Dayconnect.Fidelity.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Dayconnect.Fidelity.Controllers;

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
    [SwaggerOperation("Obtem informa��es do cliente")]
    [ProducesResponseType(typeof(ObterDadosClienteResult), (int) HttpStatusCode.OK)]
    [Authorize(Roles = "consultar")]
    [AcoesFilterAttribute]
    public async Task<IActionResult> ObterDadosCliente([SwaggerRequestBody("A signature para obter o cliente Dayconnect", Required = true)] ObterDadosClienteSignature signature)
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
        [FromBody, SwaggerRequestBody("A signature para inativar o cliente Dayconnect", Required = true)] InativarClienteSignature signature)
    {
        await _app.InativarCliente(signature);
        return Ok("Cliente inativado com sucesso!");
    }
}