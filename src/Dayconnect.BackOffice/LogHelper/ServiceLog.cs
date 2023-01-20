namespace DevSecOps.backoffice.LogHelper;

public class ServiceLog
{
    public static async Task GravaLog(string message, string funcionalidade, string metodo)
    {
        await SyslogHelper.GravaLog(439, message, funcionalidade, metodo, string.Empty);
    }

    public static async Task GravaRequest(string message, string metodo)
    {
        await SyslogHelper.GravaRequest(439, message, metodo, string.Empty);
    }

    public static async Task GravaResponse(string message, string metodo)
    {
        await SyslogHelper.GravaResponse(439, message, metodo, string.Empty);
    }
}