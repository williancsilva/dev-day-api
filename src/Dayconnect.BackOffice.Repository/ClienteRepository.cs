using Dayconnect.backoffice.Domain.Interfaces.Repository;
using Dayconnect.backoffice.Domain.Models;
using Dayconnect.backoffice.Repository.Base;
using Dayconnect.backoffice.Repository.Mappers;
using DayFw.DataAccess;
using DayFw.DataAccess.Extension.Ado;
using System.Data;
using System.Data.SqlClient;

namespace Dayconnect.backoffice.Repository;

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
            .WithProcedure("backoffice.P_OBTER_CLIENTE");

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
            .WithProcedure("backoffice.P_INATIVAR_CLIENTE");

        await ExecuteNonQueryAsync(execute);
    }
}