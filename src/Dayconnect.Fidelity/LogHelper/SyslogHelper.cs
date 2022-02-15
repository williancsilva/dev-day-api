using System.Runtime.InteropServices;
using System.Text;

namespace Dayconnect.Fidelity.LogHelper
{
    public static class SyslogHelper
    {
        public static async Task GravaLog(int codSistema, string message, string funcionalidade, string metodo, string requestId)
        {
            CreateLogDirectories(codSistema);
            var basePath = GetSystemPath(codSistema);

            // Gravar no TXT enquanto o syslog não é migrado para o Core
            // --------------------------------------------------------------------------------
            var erro = $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}###### Horário:{DateTime.Now:HH:mm:ss}{Environment.NewLine}###### Request ID: {requestId}{Environment.NewLine}###### Funcionalidade: {funcionalidade} {Environment.NewLine}###### Método: {metodo} {Environment.NewLine}###### Message:{message}";

            await WriteLogToFile(erro, Path.Combine(basePath, "Log", $"Log_WebApiHelper_DAYSYSTEM_{codSistema}_{DateTime.Now.ToShortDateString().Replace("/", "")}.txt"));
        }

        public static async Task GravaRequest(int codSistema, string message, string metodo, string requestId)
        {
            CreateLogDirectories(codSistema);
            var basePath = GetSystemPath(codSistema);

            // Gravar no TXT enquanto o syslog não é migrado para o Core
            // --------------------------------------------------------------------------------
            var erro = $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}###### Horário:{DateTime.Now:HH:mm:ss}{Environment.NewLine}###### Request ID: {requestId}{Environment.NewLine}###### Funcionalidade: DayApiMiddleware {Environment.NewLine}###### Método: {metodo} {Environment.NewLine}###### Message:{message}";

            await WriteLogToFile(erro, Path.Combine(basePath, "Request", $"RequestLog_WebApiHelper_DAYSYSTEM_{codSistema}_{DateTime.Now.ToShortDateString().Replace("/", "")}.txt"));
        }

        public static async Task GravaBacen(int codSistema, string message, string metodo, string requestId)
        {
            CreateLogDirectories(codSistema);
            var basePath = GetSystemPath(codSistema);

            // Gravar no TXT enquanto o syslog não é migrado para o Core
            // --------------------------------------------------------------------------------
            var erro = $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}###### Horário:{DateTime.Now:HH:mm:ss}{Environment.NewLine}###### Request ID: {requestId}{Environment.NewLine}###### Funcionalidade: DayApiMiddleware {Environment.NewLine}###### Método: {metodo} {Environment.NewLine}###### Message:{message}";

            await WriteLogToFile(erro, Path.Combine(basePath, "Bacen", $"BacenLog_WebApiHelper_DAYSYSTEM_{codSistema}_{DateTime.Now.ToShortDateString().Replace("/", "")}.txt"));
        }

        public static async Task GravaResponse(int codSistema, string message, string metodo, string requestId)
        {
            CreateLogDirectories(codSistema);
            var basePath = GetSystemPath(codSistema);

            // Gravar no TXT enquanto o syslog não é migrado para o Core
            // --------------------------------------------------------------------------------
            var erro = $"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}###### Horário:{DateTime.Now:HH:mm:ss}{Environment.NewLine}###### Request ID: {requestId}{Environment.NewLine}###### Funcionalidade: DayApiMiddleware {Environment.NewLine}###### Método: {metodo} {Environment.NewLine}###### Message:{message}";

            await WriteLogToFile(erro, Path.Combine(basePath, "Request", $"RequestLog_WebApiHelper_DAYSYSTEM_{codSistema}_{DateTime.Now.ToShortDateString().Replace("/", "")}.txt"));
        }

        private static string GetBasePath()
        {
            return OperatingSystem.IsMacOs() ? $"{Environment.GetFolderPath(Environment.SpecialFolder.Personal)}/DayLog" : $"C:\\Log";
        }

        private static string GetSystemPath(int codSistema)
        {
            return Path.Combine(GetBasePath(), $"DAYSYSTEM_{codSistema}");
        }

        public static void CreateLogDirectories(int codSistema)
        {
            var basePath = GetBasePath();
            var systemPath = GetSystemPath(codSistema);
            var basePathLog = Path.Combine(systemPath, "Log");
            var basePathRequest = Path.Combine(systemPath, "Request");
            var basePathBacen = Path.Combine(systemPath, "Bacen");

            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);

            if (!Directory.Exists(systemPath))
                Directory.CreateDirectory(systemPath);

            if (!Directory.Exists(basePathLog))
                Directory.CreateDirectory(basePathLog);

            if (!Directory.Exists(basePathRequest))
                Directory.CreateDirectory(basePathRequest);

            if (!Directory.Exists(basePathBacen))
                Directory.CreateDirectory(basePathBacen);
        }

        public static async Task WriteLogToFile(string erro, string path)
        {
            var encodedText = Encoding.Unicode.GetBytes(erro);

            using (var sourceStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write, bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                await sourceStream.FlushAsync();
                sourceStream.Close();
            }
        }

        private static class OperatingSystem
        {
            public static bool IsMacOs() =>
                RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        }
    }
}
