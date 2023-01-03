using DevSecOps.backoffice.Domain.Models;

namespace DevSecOps.backoffice.Domain.Interfaces.Service;

public interface IAutenticacaoService
{
    Task<Login?> Login(string login, string senha, string ip, string deviceId, string versaoDispositivo);
}