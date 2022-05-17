using Dayconnect.backoffice.App;
using Dayconnect.backoffice.App.Notifications;
using Dayconnect.backoffice.Domain.Interfaces.Service;
using Dayconnect.backoffice.Test.App.Fixtures;
using Dayconnect.backoffice.Test.Domain.Fixtures;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace Dayconnect.backoffice.Test.App;

[Collection(nameof(DtoCollection))]
public class AutenticacaoAppTest
{
    [Fact(DisplayName = "Deve Efetuar o Login com usuario e senha validos")]
    public async Task DeveEfetuarLoginComUsuarioSenhaValidos()
    {
        var mocker = new AutoMocker();
        var service = mocker.GetMock<IAutenticacaoService>();
        var notificacao = mocker.GetMock<NotificationContext>();
        var result = ModelFixture.Login;
        var signature = DtoFixture.EfetuarLogin;

        service.Setup(x => x.Login(signature.Login, signature.Password, signature.Ip, signature.DeviceId, signature.VersaoDispositivo)).ReturnsAsync(result);

        var app = new AutenticacaoApp(notificacao.Object, service.Object);

        var atual = await app.Login(signature);

        mocker.GetMock<IAutenticacaoService>().Verify(x => x.Login(signature.Login, signature.Password, signature.Ip, signature.DeviceId, signature.VersaoDispositivo), Times.Once);

        Assert.True(atual.Logado);
    }

    [Theory(DisplayName = "Deve Conter Uma Notificacao Para Login Invalido Ao Efetuar o Login.")]
    [InlineData(null)]
    [InlineData("")]
    public async Task DeveConterUmaNotificacaoParaLoginInvalidoAoEfetuarLogin(string login)
    {
        var mocker = new AutoMocker();
        var app = mocker.CreateInstance<AutenticacaoApp>();
        var signature = DtoFixture.EfetuarLogin;
        signature.Login = login;

        await app.Login(signature);

        Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Código Login Obrigatório"));
    }

    [Fact(DisplayName = "Deve Conter Uma Notificacao Para Login Maior Que Permitido Ao Efetuar o Login.")]
    public async Task DeveConterUmaNotificacaoParaLoginMaiorQuePermitidoAoEfetuarLogin()
    {
        var mocker = new AutoMocker();
        var app = mocker.CreateInstance<AutenticacaoApp>();
        var signature = DtoFixture.EfetuarLogin;
        signature.Login = "loremipsumdolorsitametconsecteturadipiscingelitProdsfasfhjyjindignissimegestasexEtiamquispujygjygjgjusnequeNammassaloremlobortisamaurisnullam@gmail.com";

        await app.Login(signature);

        Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Código Login Inválido"));
    }

    [Fact(DisplayName = "Deve Conter Uma Notificacao Para Login Com Formato Invalido Ao Efetuar o Login.")]
    public async Task DeveConterUmaNotificacaoParaLoginComFormatoInvalidoAoEfetuarLogin()
    {
        var mocker = new AutoMocker();
        var app = mocker.CreateInstance<AutenticacaoApp>();
        var signature = DtoFixture.EfetuarLogin;
        signature.Login = "loremipsumdolorsitagmail.com";

        await app.Login(signature);

        Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Formato Invalido"));
    }

    [Theory(DisplayName = "Deve Conter Uma Notificacao Para Senha Obrigatoria Ao Efetuar o Login.")]
    [InlineData(null)]
    [InlineData("")]
    public async Task DeveConterUmaNotificacaoParaSenhaObrigatoriaAoEfetuarLogin(string pass)
    {
        var mocker = new AutoMocker();
        var app = mocker.CreateInstance<AutenticacaoApp>();
        var signature = DtoFixture.EfetuarLogin;
        signature.Password = pass;

        await app.Login(signature);

        Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Senha Obrigatória"));
    }

    [Fact(DisplayName = "Deve Conter Uma Notificacao Para Senha Com Tamanho Invalido Ao Efetuar o Login.")]
    public async Task DeveConterUmaNotificacaoParaSenhaComTamanhoInvalidoAoEfetuarLogin()
    {
        var mocker = new AutoMocker();
        var app = mocker.CreateInstance<AutenticacaoApp>();
        var signature = DtoFixture.EfetuarLogin;
        signature.Password = "teste12";

        await app.Login(signature);

        Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Formato Invalido"));
    }

    [Theory(DisplayName = "Deve Conter Uma Notificacao Para DeviceId Obrigatorio Ao Efetuar o Login.")]
    [InlineData(null)]
    [InlineData("")]
    public async Task DeveConterUmaNotificacaoParaDeviceIdObrigatorioAoEfetuarLogin(string deviceId)
    {
        var mocker = new AutoMocker();
        var app = mocker.CreateInstance<AutenticacaoApp>();
        var signature = DtoFixture.EfetuarLogin;
        signature.DeviceId = deviceId;

        await app.Login(signature);

        Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("DeviceId Obrigatório"));
    }

    [Theory(DisplayName = "Deve Conter Uma Notificacao Para Versao Dispositivo Obrigatorio Ao Efetuar o Login.")]
    [InlineData(null)]
    [InlineData("")]
    public async Task DeveConterUmaNotificacaoParaVersaoDispositivoObrigatorioAoEfetuarLogin(string versaoDispositivo)
    {
        var mocker = new AutoMocker();
        var app = mocker.CreateInstance<AutenticacaoApp>();
        var signature = DtoFixture.EfetuarLogin;
        signature.VersaoDispositivo = versaoDispositivo;

        await app.Login(signature);

        Assert.Contains(mocker.GetMock<NotificationContext>().Object.Notifications, x => x.Message.Equals("Versão Dispositivo Obrigatório"));
    }
}