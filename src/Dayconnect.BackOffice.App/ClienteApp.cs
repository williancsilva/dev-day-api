using Dayconnect.backoffice.App.Base;
using Dayconnect.backoffice.App.Converters;
using Dayconnect.backoffice.App.Dto.Result;
using Dayconnect.backoffice.App.Dto.Signature;
using Dayconnect.backoffice.App.Interfaces;
using Dayconnect.backoffice.App.Notifications;
using Dayconnect.backoffice.Domain.Interfaces.Repository;

namespace Dayconnect.backoffice.App;

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

    public async Task<IEnumerable<ObterDadosClienteResult>> ObterDadosCliente(ObterDadosClienteSignature signature)
    {
        if (!DtoValido(signature))
            return null;

        var result = await _repository.ObterDadosCliente(signature.CpfCnpj);

        return result.Convert();
    }
}