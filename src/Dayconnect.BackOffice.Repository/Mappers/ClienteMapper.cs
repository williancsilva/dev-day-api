using DevSecOps.backoffice.Domain.Models;
using System.Data;
using System;

namespace DevSecOps.backoffice.Repository.Mappers;

public static class ClienteMapper
{
    public static Cliente Convert(IDataReader dReader)
    {
        var nome = dReader["nome"] as string;
        var cpfCnpj = dReader["documento"] as string;
        bool ativo = (bool)dReader["Ativo"];
        var excluido = (bool)dReader["excluido"];
        var endereco = dReader["endereco"] as string;
        var telefone = dReader["telefone"] as string;

        return new Cliente(nome, cpfCnpj, ativo, excluido, endereco, telefone);
    }
}