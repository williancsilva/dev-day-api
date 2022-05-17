﻿using Dayconnect.backoffice.Domain.Models;
using DayFw.DataAccess.Helpers;
using System.Data;

namespace Dayconnect.backoffice.Repository.Mappers;

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