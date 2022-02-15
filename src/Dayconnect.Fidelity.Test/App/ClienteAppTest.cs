using Bogus;
using Dayconnect.Fidelity.App;
using Dayconnect.Fidelity.App.Notifications;
using Dayconnect.Fidelity.Domain.Interfaces.Service;
using Dayconnect.Fidelity.Test.App.Fixtures;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace Dayconnect.Fidelity.Test.App
{
    [Collection(nameof(DtoCollection))]
    public class ClienteAppTest
    {
        private readonly DtoFixture _dtoFixture;
        private readonly Faker _faker;
        public ClienteAppTest(DtoFixture dtoFixture)
        {
            _dtoFixture = dtoFixture;
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Deve inativar um cliente")]
        public async Task DeveInativarCliente()
        {
            var mocker = new AutoMocker();
            var model = new ModelFixture();

            var service = mocker.GetMock<IClienteService>();
            var notificacao = mocker.GetMock<NotificationContext>();
            var signature = _dtoFixture.InativarCliente;

            service.Setup(x => x.InativarCliente(signature.CpfCnpj));

            var app = new ClienteApp(notificacao.Object, service.Object);

            await app.InativarCliente(signature);

            mocker.GetMock<IClienteService>().Verify(x => x.InativarCliente(signature.CpfCnpj), Times.Once);

        }

        [Fact(DisplayName = "Deve obter uma lista de cliente")]
        public async Task DeveObterDadosCliente()
        {
            var mocker = new AutoMocker();
            var model = new ModelFixture();

            var service = mocker.GetMock<IClienteService>();
            var notificacao = mocker.GetMock<NotificationContext>();
            var result = model.ListaCliente;
            var signature = _dtoFixture.ObterDadosCliente;

            service.Setup(x => x.ObterDadosCliente(signature.CpfCnpj)).ReturnsAsync(result);

            var app = new ClienteApp(notificacao.Object, service.Object);

            var clientes = await app.ObterDadosCliente(signature);

            mocker.GetMock<IClienteService>().Verify(x => x.ObterDadosCliente(signature.CpfCnpj), Times.Once);

            Assert.Contains(clientes, item => item.Ativo);
        }

        [Theory(DisplayName = "Deve Conter Uma Notificacao Para Obter Dados Cliente Com Documento Invalido.")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("28870752841")]
        [InlineData("10231533000137")]
        public async Task DeveConterUmaNotificacaoParaObterDadosClienteComDocumentoInvalido(string documento)
        {
            var mocker = new AutoMocker();
            var app = mocker.CreateInstance<ClienteApp>();
            var signature = _dtoFixture.ObterDadosCliente;
            signature.CpfCnpj = documento;

            await app.ObterDadosCliente(signature);

            Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Documento Inválido"));
        }

        [Theory(DisplayName = "Deve Conter Uma Notificacao Para Obter Dados Cliente Com Documento Invalido.")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("28870752841")]
        [InlineData("10231533000137")]
        public async Task DeveConterUmaNotificacaoParaInativarClienteComDocumentoInvalido(string documento)
        {
            var mocker = new AutoMocker();
            var app = mocker.CreateInstance<ClienteApp>();
            var signature = _dtoFixture.InativarCliente;
            signature.CpfCnpj = documento;

            await app.InativarCliente(signature);

            Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Documento Inválido"));
        }
    }
}
