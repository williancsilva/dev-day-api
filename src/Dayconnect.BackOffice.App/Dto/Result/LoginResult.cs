using DevSecOps.backoffice.Domain.Models.Result;

namespace DevSecOps.backoffice.App.Dto.Result;

public class LoginResult
{
    public int DayId { get; set; }
    public bool Logado { get; set; }
    
    public string Senha { get; set; }
    
    public Permission Permissoes { get; set; }
}