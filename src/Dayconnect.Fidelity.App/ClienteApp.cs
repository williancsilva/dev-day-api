using Dayconnect.Fidelity.App.Base;
using Dayconnect.Fidelity.App.Converters;
using Dayconnect.Fidelity.App.Dto.Result;
using Dayconnect.Fidelity.App.Dto.Signature;
using Dayconnect.Fidelity.App.Interfaces;
using Dayconnect.Fidelity.App.Notifications;
using Dayconnect.Fidelity.Domain.Interfaces.Service;

namespace Dayconnect.Fidelity.App
{
    public class ClienteApp : ApplicationBase, IClienteApp
    {
        private readonly IClienteService _service;
        public ClienteApp(NotificationContext notificationContext, IClienteService service) : base(notificationContext)
        {
            _service = service;
        }
        public async Task InativarCliente(InativarClienteSignature signature)
        {
            if (!DtoValido(signature))
                return;

            await _service.InativarCliente(signature.CpfCnpj);
        }

        public async Task<IEnumerable<ObterDadosClienteResult>> ObterDadosCliente(ObterDadosClienteSignature signature)
        {
            if (!DtoValido(signature))
                return null;

            var result = await _service.ObterDadosCliente(signature.CpfCnpj);

            return result.Convert();
        }
    }
}