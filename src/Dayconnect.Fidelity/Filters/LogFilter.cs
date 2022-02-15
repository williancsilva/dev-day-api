using Dayconnect.Fidelity.LogHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Text.Json;

#nullable disable

namespace Dayconnect.Fidelity.Filters
{
    public class LogFilter : IActionFilter
    {
        private readonly bool enabledLog;
        public LogFilter(IConfiguration _config)
        {
            enabledLog = Convert.ToBoolean(_config.GetSection("EnabledLogRequest").Value);
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (enabledLog)
            {
                var returnValue = ReadBodyAsString(context).GetAwaiter().GetResult();
                string metodo = GetMetodo(context.HttpContext);
                ServiceLog.GravaRequest(returnValue, metodo).GetAwaiter();
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (enabledLog)
            {
                var returnValue = JsonSerializer.Serialize(((ObjectResult)context.Result).Value);
                var metodo = $"{context.HttpContext.Request.Path}/{context.HttpContext.Request.Method}";
                ServiceLog.GravaResponse(returnValue, metodo).GetAwaiter();
            }
        }

        private static string GetMetodo(HttpContext context)
        {
            return $"{context.Request.Path}/{context.Request.Method}";
        }
        private async Task<string> ReadBodyAsString(ActionExecutingContext context)
        {
            var returnValue = string.Empty;
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
}
