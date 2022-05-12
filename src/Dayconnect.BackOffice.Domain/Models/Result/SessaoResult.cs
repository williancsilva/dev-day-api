#nullable disable

namespace Dayconnect.backoffice.Domain.Models.Result;

public class SessaoResult
{
    public string Id { get; set; }
    public bool IsAuthenticated { get; set; }
    public string SerializedObject { get; set; }
    public Permission Permission { get; set; }
    public int CodSistema { get; set; }
    public string Login { get; set; }
}

public class Permission
{
    public string[] Features { get; set; }
    public string[] Roles { get; set; }
}