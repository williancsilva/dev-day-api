using DevSecOps.backoffice.Domain.Interfaces.Repository;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Repository.Base;
using DevSecOps.backoffice.Repository.Mappers;
using DayFw.DataAccess;
using DayFw.DataAccess.Extension.Ado;
using System.Data;
using System.Data.SqlClient;

namespace DevSecOps.backoffice.Repository;

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

    public async Task ExcluirCliente(string cpfCnpj)
    {
        var parametros = new List<SqlParameter>
        {
            new("@CpfCnpjCliente", SqlDbType.VarChar) {Value = cpfCnpj}
        };

        var execute = new CreateExecuteAdo()
            .WithParameters(parametros)
            .WithProcedure("backoffice.P_EXCLUIR_CLIENTE");

        await ExecuteNonQueryAsync(execute);
    }
}