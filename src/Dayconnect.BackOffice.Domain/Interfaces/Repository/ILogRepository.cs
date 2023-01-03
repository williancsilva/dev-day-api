using DevSecOps.backoffice.Domain.Models;

namespace DevSecOps.backoffice.Domain.Interfaces.Repository;

public interface ILogRepository
{
    Task InserirLog(LogDominio signature);
}