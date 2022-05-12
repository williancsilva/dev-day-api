using Dayconnect.backoffice.App.Dto.Signature;
using Dayconnect.backoffice.App.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Dayconnect.backoffice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutenticacaoController : ControllerBase
{
    private readonly IAutenticacaoApp _app;

    public AutenticacaoController(IAutenticacaoApp app)
    {
        _app = app;
    }

    [HttpPost]
    [Route("Login")]
    [SwaggerOperation("Efetua o login no sistema")]
    [ProducesResponseType((int) HttpStatusCode.OK)]
    public async Task<IActionResult> LoginAsync([FromBody, SwaggerRequestBody("A signature para logar no sistema", Required = true)] LoginSignature signature)
    {
        signature.Ip = string.IsNullOrEmpty(HttpContext.Request.Headers["X-REAL-IP"]) ? HttpContext.Connection.RemoteIpAddress?.ToString() : HttpContext.Request.Headers["X-REAL-IP"].ToString();
        
        var result = await _app.Login(signature);

        if (result != null)
            return Ok(result);

        return BadRequest("Dados incorretos.");
    }
}