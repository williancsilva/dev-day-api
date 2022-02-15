using Dayconnect.Fidelity.Domain.Interfaces.ExternalService;
using Dayconnect.Fidelity.Domain.Models.Result;
using Dayconnect.Fidelity.Domain.Models.Signature;
using System.Text;
using System.Text.Json;

#nullable disable

namespace Dayconnect.Fidelity.ExternalService
{
    public class AccessControlSession : IAccessControlSession
    {
        public  HttpClient _http { get; }
        public AccessControlSession(HttpClient http)
        {
            _http = http;
        }

        public async Task<SessaoResult> ObterSessao(SessaoSignature signature)
        {
            var response = await _http.GetAsync($"{_http.BaseAddress}/Session/?sessionId={signature.SessionId}&expiration={signature.Expiration}");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SessaoResult>(json);
        }

        public async Task<string> CriarSessao(CriarSessaoSignature signature)
        {

            var response = await _http.PostAsync($"{_http.BaseAddress}Session", new StringContent(JsonSerializer.Serialize(signature), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<string>(content);

        }
        public async Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature)
        {
            var response = await _http.PostAsync($"{_http.BaseAddress}Security/AutenticarUsuario", new StringContent(JsonSerializer.Serialize(signature), Encoding.UTF8, "text/json"));
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AutenticarUsuarioResult>(content);
        }
    }
}