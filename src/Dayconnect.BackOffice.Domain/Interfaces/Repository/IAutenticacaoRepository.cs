namespace DevSecOps.BackOffice.Domain.Interfaces.Repository
{
    public interface IAutenticacaoRepository
    {
        Task<string> CriarSessao(string email);
    }
}
