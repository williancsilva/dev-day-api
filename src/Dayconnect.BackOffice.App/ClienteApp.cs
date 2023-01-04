using DevSecOps.backoffice.App.Base;
using DevSecOps.backoffice.App.Converters;
using DevSecOps.backoffice.App.Dto.Result;
using DevSecOps.backoffice.App.Dto.Signature;
using DevSecOps.backoffice.App.Interfaces;
using DevSecOps.backoffice.App.Notifications;
using DevSecOps.backoffice.Domain.Interfaces.Repository;

namespace DevSecOps.backoffice.App;

public class ClienteApp : ApplicationBase, IClienteApp
{
    private readonly IClienteRepository _repository;

    public ClienteApp(NotificationContext notificationContext, IClienteRepository repository) : base(notificationContext)
    {
        _repository = repository;
    }

    public async Task InativarCliente(InativarClienteSignature signature)
    {
        if (!DtoValido(signature))
            return;

        await _repository.InativarCliente(signature.CpfCnpj);
    }

    public async Task ExcluirCliente(ExcluirClienteSignature signature)
    {
        await _repository.ExcluirCliente(signature.CpfCnpj);
    }

    public async Task<IEnumerable<ObterDadosClienteResult>> ObterDadosCliente(ObterDadosClienteSignature signature)
    {
        if (!DtoValido(signature))
            return null;

        var result = await _repository.ObterDadosCliente(signature.CpfCnpj);

        return result.Convert();
    }
}