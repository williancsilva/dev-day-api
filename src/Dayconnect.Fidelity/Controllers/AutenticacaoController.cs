using Dayconnect.Fidelity.App.Dto.Signature;
using Dayconnect.Fidelity.App.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Dayconnect.Fidelity.Controllers
{
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginAsync([FromBody, SwaggerRequestBody("A signature para logar no sistema", Required = true)] LoginSignature signature)
        {
            signature.Ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var result = await _app.Login(signature);
            
            if(result != null)
                return Ok(result);

            return BadRequest("Dados incorretos.");
        }
    }
}
