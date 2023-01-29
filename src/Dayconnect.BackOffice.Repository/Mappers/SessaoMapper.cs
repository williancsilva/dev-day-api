using DevSecOps.backoffice.Domain.Models;
using System.Data;
using System;
using DevSecOps.backoffice.Domain.Models.Result;

namespace DevSecOps.backoffice.Repository.Mappers;

public static class SessaoMapper
{
    public static SessaoResult Convert(IDataReader dReader)
    {
        var id = (int)dReader["id"];
        var isAuthenticated = (bool)dReader["isAuthenticated"];
        var login = dReader["login"] as string;
        var dataExpiracao = (DateTime)dReader["Expiracao"];
        var senha = dReader["senha"] as string;
        var salt = dReader["salt"] as string;

        var role = dReader["roles"] as string;
        string[] roles = { role ?? "" };

        var feature = dReader["features"] as string;

        var features = feature?.Split(',');

        var permissoes = new Permission(features, roles);

        return new SessaoResult(id, isAuthenticated, "", permissoes, login, dataExpiracao, senha, salt);
    }
}