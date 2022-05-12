using Dayconnect.backoffice.Domain.Interfaces.ExternalService;
using Dayconnect.backoffice.Domain.Models.Result;
using Dayconnect.backoffice.Domain.Models.Signature;
using System.Text;
using System.Text.Json;

#nullable disable

namespace Dayconnect.backoffice.ExternalService;

public class AccessControlSession : IAccessControlSession
{
    private HttpClient Http { get; }

    public AccessControlSession(HttpClient http)
    {
        Http = http;
    }

    public async Task<SessaoResult> ObterSessao(SessaoSignature signature)
    {
        var response = await Http.GetAsync($"{Http.BaseAddress}/Session/?sessionId={signature.SessionId}&expiration={signature.Expiration}");
        if (!response.IsSuccessStatusCode) return null;
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<SessaoResult>(json);
    }

    public async Task<string> CriarSessao(CriarSessaoSignature signature)
    {
        var response = await Http.PostAsync($"{Http.BaseAddress}Session", new StringContent(JsonSerializer.Serialize(signature), Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<string>(content);
    }

    public async Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature)
    {
        var response = await Http.PostAsync($"{Http.BaseAddress}Security/AutenticarUsuario", new StringContent(JsonSerializer.Serialize(signature), Encoding.UTF8, "text/json"));
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AutenticarUsuarioResult>(content);
    }
    public async Task<int> ObterTipoAutenticacao(ObterTipoAutenticacaoSignature signature)
    {
        var response = await Http.PostAsync($"{Http.BaseAddress}Security/SelecionarUsuario", new StringContent(JsonSerializer.Serialize(signature), Encoding.UTF8, "text/json"));
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var model = JsonSerializer.Deserialize<ObterTipoAutenticacaoResult>(content);
        return model != null ? model.MutiploFatorAutenticacao.FirstOrDefault().TipoAutenticacao : 0;
    }
}