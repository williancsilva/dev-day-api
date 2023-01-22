#nullable disable

namespace DevSecOps.backoffice.Domain.Models.Result;

public class SessaoResult
{
    public SessaoResult()
    {

    }
    public SessaoResult(string id, bool isAuthenticated, string serializedObject, Permission permission, string login, DateTime dataExpiracao, string senha)
    {
        Id = id;
        IsAuthenticated = isAuthenticated;
        SerializedObject = serializedObject;
        Permission = permission;
        Login = login;
        DataExpiracao = dataExpiracao;
        Senha = senha;
    }

    public string Id { get; set; }
    public bool IsAuthenticated { get; set; }
    public string SerializedObject { get; set; }
    public Permission Permission { get; set; }
    public string Login { get; set; }
    public DateTime DataExpiracao { get; set; }
    public string Senha { get; set; }
}

public class Permission
{
    public Permission(string[] features, string[] roles)
    {
        Features = features;
        Roles = roles;
    }

    public string[] Features { get; set; }
    public string[] Roles { get; set; }
}