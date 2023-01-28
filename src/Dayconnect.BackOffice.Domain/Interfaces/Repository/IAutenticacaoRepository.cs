using DevSecOps.backoffice.Domain.Models.Result;

namespace DevSecOps.BackOffice.Domain.Interfaces.Repository
{
    public interface IAutenticacaoRepository
    {
        Task<int> CriarSessao(string email);
        Task<SessaoResult> ObterSessao(int dayId);
        Task AtualizarSessao(int dayId, bool isAuthenticated);
    }
}
