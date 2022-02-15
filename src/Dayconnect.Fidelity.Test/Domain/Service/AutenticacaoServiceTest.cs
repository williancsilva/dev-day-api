using Bogus;
using Bogus.Extensions.Brazil;
using Dayconnect.Fidelity.Domain.Interfaces.ExternalService;
using Dayconnect.Fidelity.Domain.Models.Result;
using Dayconnect.Fidelity.Domain.Models.Signature;
using Dayconnect.Fidelity.Domain.Service;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Service
{
    [Collection(nameof(ModelsCollection))]
    public class AutenticacaoServiceTest
    {
        private readonly ModelFixture _modelFixture;
        private readonly Faker _faker;

        public AutenticacaoServiceTest(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Deve efetuar um login")]
        public async Task DeveLogin()
        {
            var mocker = new AutoMocker();

            var proxy = mocker.GetMock<IAccessControlSession>();

            string login = _faker.Internet.Email();
            string senha = _faker.Internet.Password();
            string ip = _faker.Internet.Ip();
            string deviceId = _faker.Random.Word();
            string versaoDispositivo = _faker.Random.Number(10, 30).ToString();
            string sessionId = $"353_{Guid.NewGuid()}";

            var autenticarUsuarioResult = new AutenticarUsuarioResult()
            {
                Autenticado = true,
                LoginHabilitado = true
            };

            proxy.Setup(x => x.CriarSessao(It.IsAny<CriarSessaoSignature>())).ReturnsAsync(sessionId);
            proxy.Setup(x => x.AutenticarUsuario(It.IsAny < AutenticarUsuarioSignature>())).ReturnsAsync(autenticarUsuarioResult);

            var service = new AutenticacaoService(proxy.Object);

            var result = await service.Login(login,senha,ip,deviceId,versaoDispositivo);

            mocker.GetMock<IAccessControlSession>().Verify(x => x.CriarSessao(It.IsAny<CriarSessaoSignature>()), Times.Once);
            mocker.GetMock<IAccessControlSession>().Verify(x => x.AutenticarUsuario(It.IsAny < AutenticarUsuarioSignature>()), Times.Once);

            Assert.Equal(sessionId, result.Id);
        }
    }
}
