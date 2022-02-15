using Dayconnect.Fidelity.Domain.Interfaces.Repository;
using Dayconnect.Fidelity.Domain.Interfaces.Service;
using Dayconnect.Fidelity.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dayconnect.Fidelity.Domain.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task InativarCliente(string cpfCnpj)
        {
            await _repository.InativarCliente(cpfCnpj);
        }

        public async Task<IEnumerable<Cliente>> ObterDadosCliente(string cpfCnpj)
        {
            return await _repository.ObterDadosCliente(cpfCnpj);
        }
    }
}
