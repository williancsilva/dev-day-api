using Dayconnect.backoffice.Domain.Models;

namespace Dayconnect.backoffice.Domain.Interfaces.Repository;

public interface ILogRepository
{
    Task InserirLog(LogDominio signature);
}