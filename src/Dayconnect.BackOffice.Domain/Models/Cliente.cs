namespace DevSecOps.backoffice.Domain.Models;

public class Cliente
{
    public string Nome { get; }
    public string CpfCnpj { get; }
    public bool Ativo { get; }
    public bool Excluido { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public bool IsValid { get; private set; }

    public Cliente(string nome, string cpfCnpj, bool ativo, bool excluido, string endereco, string telefone)
    {
        Nome = nome;
        CpfCnpj = cpfCnpj;
        Ativo = ativo;
        Excluido = excluido;
        Endereco = endereco;
        Telefone = telefone;    
        Validar();
    }

    private void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            throw new ArgumentNullException(Nome, "Nome obrigatório");

        if (string.IsNullOrWhiteSpace(CpfCnpj))
            throw new ArgumentNullException(CpfCnpj, "Documento obrigatório");

        IsValid = true;
    }
}