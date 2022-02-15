using Dayconnect.Fidelity.Domain.Models;
using System.Threading.Tasks;

namespace Dayconnect.Fidelity.Domain.Interfaces.Repository
{
    public interface ILogRepository
    {
        Task InserirLog(LogDominio signature);
    }
}
