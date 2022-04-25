using Dayconnect.Fidelity.Domain.Interfaces.Repository;
using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Repository.Base;
using Dayconnect.Fidelity.Repository.Mappers;
using DayFw.DataAccess;
using DayFw.DataAccess.Extension.Ado;
using System.Data;
using System.Data.SqlClient;

namespace Dayconnect.Fidelity.Repository;

public class ClienteRepository : DcvDayconnect, IClienteRepository
{
    public async Task<IEnumerable<Cliente>> ObterDadosCliente(string cpfCnpj)
    {
        var parametros = new List<SqlParameter>
        {
            new("@CpfCnpjCliente", SqlDbType.VarChar) {Value = cpfCnpj}
        };

        var execute = new CreateExecuteAdo()
            .WithParameters(parametros)
            .WithProcedure("fidelity.P_OBTER_CLIENTE");

        return await ExecuteListAsync(execute, ClienteMapper.Convert);
    }

    public async Task InativarCliente(string cpfCnpj)
    {
        var parametros = new List<SqlParameter>
        {
            new("@CpfCnpjCliente", SqlDbType.VarChar) {Value = cpfCnpj}
        };

        var execute = new CreateExecuteAdo()
            .WithParameters(parametros)
            .WithProcedure("fidelity.P_INATIVAR_CLIENTE");

        await ExecuteNonQueryAsync(execute);
    }
}