using DevSecOps.backoffice.App;
using DevSecOps.backoffice.App.Notifications;
using DevSecOps.backoffice.Test.App.Fixtures;
using DevSecOps.backoffice.Test.Domain.Fixtures;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using DevSecOps.backoffice.Domain.Interfaces.Repository;
using Xunit;

namespace DevSecOps.backoffice.Test.App;

[Collection(nameof(DtoCollection))]
public class ClienteAppTest
{
    [Fact(DisplayName = "Deve inativar um cliente")]
    public async Task DeveInativarCliente()
    {
        var mocker = new AutoMocker();
        var repository = mocker.GetMock<IClienteRepository>();
        var notificacao = mocker.GetMock<NotificationContext>();
        var signature = DtoFixture.InativarCliente;

        repository.Setup(x => x.InativarCliente(signature.CpfCnpj));

        var app = new ClienteApp(notificacao.Object, repository.Object);

        await app.InativarCliente(signature);

        mocker.GetMock<IClienteRepository>().Verify(x => x.InativarCliente(signature.CpfCnpj), Times.Once);
    }

    [Fact(DisplayName = "Deve obter uma lista de cliente")]
    public async Task DeveObterDadosCliente()
    {
        var mocker = new AutoMocker();
        var repository = mocker.GetMock<IClienteRepository>();
        var notificacao = mocker.GetMock<NotificationContext>();
        var result = ModelFixture.ListaCliente;
        var signature = DtoFixture.ObterDadosCliente;

        repository.Setup(x => x.ObterDadosCliente(signature.CpfCnpj)).ReturnsAsync(result);

        var app = new ClienteApp(notificacao.Object, repository.Object);

        var clientes = await app.ObterDadosCliente(signature);

        mocker.GetMock<IClienteRepository>().Verify(x => x.ObterDadosCliente(signature.CpfCnpj), Times.Once);

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
        var signature = DtoFixture.ObterDadosCliente;
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
        var signature = DtoFixture.InativarCliente;
        signature.CpfCnpj = documento;

        await app.InativarCliente(signature);

        Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Documento Inválido"));
    }
}