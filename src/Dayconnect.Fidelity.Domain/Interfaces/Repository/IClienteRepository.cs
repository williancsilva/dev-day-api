using Dayconnect.Fidelity.Domain.Models;

namespace Dayconnect.Fidelity.Domain.Interfaces.Repository;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ObterDadosCliente(string cpfCnpj);
    Task InativarCliente(string cpfCnpj);
}