

using Dayconnect.Fidelity.Domain.Models;

namespace Dayconnect.Fidelity.Domain.Interfaces.Service
{
    public interface IAutenticacaoService
    {
        Task<Login> Login(string _login, string _senha, string _ip, string _deviceId, string _versaoDispositivo);
    }
}
