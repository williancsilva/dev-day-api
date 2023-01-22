using DevSecOps.backoffice.Domain.Interfaces.ExternalService;
using DevSecOps.backoffice.Domain.Models.Result;
using DevSecOps.backoffice.Domain.Models.Signature;
using DevSecOps.BackOffice.Domain.Interfaces.Repository;

namespace DevSecOps.backoffice.ExternalService;

public class AccessControlSession : IAccessControlSession
{
    private readonly IAutenticacaoRepository _autenticacaoRepository;

    public AccessControlSession(IAutenticacaoRepository autenticacaoRepository)
    {
        _autenticacaoRepository = autenticacaoRepository;
    }

    
}