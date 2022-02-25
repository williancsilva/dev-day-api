using Dayconnect.Fidelity.Domain.Models;
using DayFw.DataAccess.Helpers;
using System.Data;

namespace Dayconnect.Fidelity.Repository.Mappers;

public static class ClienteMapper
{
    public static Cliente Convert(IDataReader dReader, string nomeProcedure)
    {
        var nome = ConverterHelper.ConvertToString(dReader, "NomeCartao", nomeProcedure);
        var cpfCnpj = ConverterHelper.ConvertToString(dReader, "CpfCnpjCliente", nomeProcedure);
        var ativo = ConverterHelper.ConvertToBoolean(dReader, "Ativo", nomeProcedure);

        return new Cliente(nome, cpfCnpj, ativo);
    }
}