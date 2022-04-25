using Bogus;
using Dayconnect.Fidelity.Domain.Interfaces.ExternalService;
using Dayconnect.Fidelity.Domain.Models.Result;
using Dayconnect.Fidelity.Domain.Models.Signature;
using Dayconnect.Fidelity.Domain.Service;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Service
{
    [Collection(nameof(ModelsCollection))]
    public class AutenticacaoServiceTest
    {
        private readonly Faker _faker;

        public AutenticacaoServiceTest()
        {
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Deve efetuar um login")]
        public async Task DeveLogin()
        {
            var mocker = new AutoMocker();

            var proxy = mocker.GetMock<IAccessControlSession>();

            var login = _faker.Internet.Email();
            var senha = _faker.Internet.Password();
            var ip = _faker.Internet.Ip();
            var deviceId = _faker.Random.Word();
            var versaoDispositivo = _faker.Random.Number(10, 30).ToString();
            var sessionId = $"353_{Guid.NewGuid()}";

            var autenticarUsuarioResult = new AutenticarUsuarioResult()
            {
                Autenticado = true,
                LoginHabilitado = true
            };

            proxy.Setup(x => x.CriarSessao(It.IsAny<CriarSessaoSignature>())).ReturnsAsync(sessionId);
            proxy.Setup(x => x.AutenticarUsuario(It.IsAny<AutenticarUsuarioSignature>())).ReturnsAsync(autenticarUsuarioResult);

            var service = new AutenticacaoService(proxy.Object);

            var result = await service.Login(login, senha, ip, deviceId, versaoDispositivo);

            mocker.GetMock<IAccessControlSession>().Verify(x => x.CriarSessao(It.IsAny<CriarSessaoSignature>()), Times.Once);
            mocker.GetMock<IAccessControlSession>().Verify(x => x.AutenticarUsuario(It.IsAny<AutenticarUsuarioSignature>()), Times.Once);

            Assert.Equal(sessionId, result.Id);
        }
    }
}