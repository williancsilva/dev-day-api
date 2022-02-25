using Dayconnect.Fidelity.Domain.Models;

namespace Dayconnect.Fidelity.Domain.Interfaces.Repository;

public interface ILogRepository
{
    Task InserirLog(LogDominio signature);
}