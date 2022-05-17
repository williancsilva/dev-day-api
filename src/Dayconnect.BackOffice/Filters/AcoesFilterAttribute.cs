using Dayconnect.backoffice.Domain.Models.Result;
using Dayconnect.backoffice.Mediator.Handles;
using Dayconnect.backoffice.Mediator.Notifications;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

#nullable disable

namespace Dayconnect.backoffice.Filters;

public class AcoesFilterAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var mediatorHandler = (IMediatorHandler) context.HttpContext.RequestServices.GetService(typeof(IMediatorHandler));

        var signature = await CriarSignature(context);

        if (mediatorHandler != null)
            await mediatorHandler.PublicarEvento(new LogNotification(signature.cpfCnpj, signature.Metodo, signature.Url, signature.Operador, signature.Ip));

        await next();
    }

    private async Task<BaseSignature> CriarSignature(ActionExecutingContext context)
    {
        var returnValue = await ReadBodyAsString(context);
        var ip = string.IsNullOrEmpty(context.HttpContext.Request.Headers["X-REAL-IP"]) ? context.HttpContext.Connection.RemoteIpAddress?.ToString() : context.HttpContext.Request.Headers["X-REAL-IP"].ToString();
        var session = (SessaoResult) context.HttpContext.Items["UserSession"];

        var signature = JsonSerializer.Deserialize<BaseSignature>(returnValue);

        if (signature == null)
            return null;

        signature.Metodo = context.HttpContext.Request.Method;
        signature.Url = context.HttpContext.Request.Path;
        signature.Ip = ip;
        signature.Operador = session?.Login;

        return signature;
    }

    private static async Task<string> ReadBodyAsString(ActionContext context)
    {
        string returnValue;
        var request = context.HttpContext.Request;
        request.EnableBuffering();
        request.Body.Position = 0;

        using (var stream = new StreamReader(request.Body, Encoding.UTF8, true, 1024, leaveOpen: true))
        {
            returnValue = await stream.ReadToEndAsync();
        }

        request.Body.Position = 0;

        return returnValue;
    }

    public class BaseSignature
    {
        public string cpfCnpj { get; set; }
        public string Metodo { get; set; }
        public string Url { get; set; }
        public string Operador { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Ip { get; set; }
    }
}