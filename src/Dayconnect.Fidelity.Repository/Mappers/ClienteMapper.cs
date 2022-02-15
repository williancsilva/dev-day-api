using Dayconnect.Fidelity.Domain.Models;
using DayFw.DataAccess.Helpers;
using System.Data;

namespace Dayconnect.Fidelity.Repository.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente Convert(IDataReader dReader, string nomeProcedure)
        {
            var _nome = ConverterHelper.ConvertToString(dReader, "NomeCartao", nomeProcedure);
            var _cpfCnpj = ConverterHelper.ConvertToString(dReader, "CpfCnpjCliente", nomeProcedure);
            var _ativo = ConverterHelper.ConvertToBoolean(dReader, "Ativo", nomeProcedure);

            var _cliente = new Cliente(_nome, _cpfCnpj);
            _cliente.SetAtivo(_ativo);

            return _cliente;
        }
    }
}
