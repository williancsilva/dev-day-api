using Dayconnect.Fidelity.App.Base;
using Dayconnect.Fidelity.App.Converters;
using Dayconnect.Fidelity.App.Dto.Result;
using Dayconnect.Fidelity.App.Dto.Signature;
using Dayconnect.Fidelity.App.Interfaces;
using Dayconnect.Fidelity.App.Notifications;
using Dayconnect.Fidelity.Domain.Interfaces.Repository;

namespace Dayconnect.Fidelity.App;

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