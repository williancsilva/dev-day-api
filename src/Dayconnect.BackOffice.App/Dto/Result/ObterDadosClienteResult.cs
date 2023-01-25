namespace DevSecOps.backoffice.App.Dto.Result;

public class ObterDadosClienteResult
{
    public string Nome { get; set; }
    public string CpfCnpj { get; set; }
    public bool Ativo { get; set; }
    public bool Excluido { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
}