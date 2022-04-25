using Dayconnect.Fidelity.Domain.Models;

namespace Dayconnect.Fidelity.Domain.Interfaces.Service;

public interface IAutenticacaoService
{
    Task<Login> Login(string login, string senha, string ip, string deviceId, string versaoDispositivo);
}