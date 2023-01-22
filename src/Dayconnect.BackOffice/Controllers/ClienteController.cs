using DevSecOps.backoffice.App.Dto.Result;
using DevSecOps.backoffice.App.Dto.Signature;
using DevSecOps.backoffice.App.Interfaces;
using DevSecOps.backoffice.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace DevSecOps.backoffice.Controllers;

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
    [Authorize(Roles = "Consulta")]
    public async Task<IActionResult> ObterDadosCliente([SwaggerRequestBody("A signature para obter o cliente", Required = true)] ObterDadosClienteSignature signature)
    {
        var result = await _app.ObterDadosCliente(signature);
        return Ok(result);
    }

    [HttpPost]
    [Route(nameof(BloquearCliente))]
    [SwaggerOperation("Bloquea o cliente")]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    [Authorize(Roles = "Ativar")]
    public async Task<IActionResult> BloquearCliente(
        [FromBody, SwaggerRequestBody("A signature para bloquear o cliente", Required = true)] InativarClienteSignature signature)
    {
        await _app.InativarCliente(signature);
        return Ok("Cliente bloqueado com sucesso!");
    }

    [HttpPost]
    [Route(nameof(ExcluirCliente))]
    [SwaggerOperation("Exclui o cliente")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Authorize(Roles = "Excluir")]
    public async Task<IActionResult> ExcluirCliente(
        [FromBody, SwaggerRequestBody("A signature para excluir o cliente", Required = true)] ExcluirClienteSignature signature)
    {
        await _app.ExcluirCliente(signature);
        return Ok("Cliente excluído com sucesso!");
    }
}