﻿using Dayconnect.Fidelity.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dayconnect.Fidelity.Domain.Interfaces.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObterDadosCliente(string cpfCnpj);
        Task InativarCliente(string cpfCnpj);
    }
}
