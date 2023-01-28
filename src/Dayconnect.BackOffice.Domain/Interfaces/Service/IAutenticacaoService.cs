using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Domain.Models.Result;
using DevSecOps.backoffice.Domain.Models.Signature;

namespace DevSecOps.backoffice.Domain.Interfaces.Service;

public interface IAutenticacaoService
{
    Task<Login?> Login(string login, string senha, string ip, string deviceId, string versaoDispositivo);
    Task<SessaoResult> ObterSessao(SessaoSignature signature);
    Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature);
    Task Logoff(string dayId);
}