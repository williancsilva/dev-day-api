using Dayconnect.backoffice.LogHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Text.Json;

#nullable disable

namespace Dayconnect.backoffice.Filters;

public class LogFilter : IActionFilter
{
    private readonly bool _enabledLog;

    public LogFilter(IConfiguration config)
    {
        _enabledLog = Convert.ToBoolean(config.GetSection("EnabledLogRequest").Value);
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!_enabledLog)
            return;

        var returnValue = ReadBodyAsString(context).GetAwaiter().GetResult();
        var metodo = GetMetodo(context.HttpContext);

        ServiceLog.GravaRequest(returnValue, metodo).GetAwaiter();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (!_enabledLog)
            return;

        var returnValue = JsonSerializer.Serialize(((ObjectResult) context.Result)?.Value);
        var metodo = $"{context.HttpContext.Request.Path}/{context.HttpContext.Request.Method}";

        ServiceLog.GravaResponse(returnValue, metodo).GetAwaiter();
    }

    private static string GetMetodo(HttpContext context)
    {
        return $"{context.Request.Path}/{context.Request.Method}";
    }

    private async Task<string> ReadBodyAsString(ActionExecutingContext context)
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
}