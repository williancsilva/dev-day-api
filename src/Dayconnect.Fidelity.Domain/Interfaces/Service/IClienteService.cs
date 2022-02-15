using Dayconnect.Fidelity.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dayconnect.Fidelity.Domain.Interfaces.Service
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObterDadosCliente(string cpfCnpj);
        Task InativarCliente(string cpfCnpj);
    }
}
