using Bogus;
using Bogus.Extensions.Brazil;
using Dayconnect.Fidelity.Domain.Interfaces.Repository;
using Dayconnect.Fidelity.Domain.Service;
using Dayconnect.Fidelity.Test.Domain.Fixtures;
using Moq;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Service
{
    [Collection(nameof(ModelsCollection))]
    public class ClienteServiceTest
    {
        private readonly ModelFixture _modelFixture;
        private readonly Faker _faker;
        public ClienteServiceTest(ModelFixture modelFixture)
        {
            _modelFixture = modelFixture;
            _faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Deve inativar um cliente")]
        public async Task DeveInativarCliente()
        {
            var mocker = new AutoMocker();

            var repository = mocker.GetMock<IClienteRepository>();
            var documento = _faker.Person.Cpf();
            repository.Setup(x => x.InativarCliente(documento));

            var service = new ClienteService(repository.Object);

            await service.InativarCliente(documento);

            mocker.GetMock<IClienteRepository>().Verify(x => x.InativarCliente(documento), Times.Once);

        }

        [Fact(DisplayName = "Deve obter os dados de clientes")]
        public async Task DeveObterDadosCliente()
        {
            var mocker = new AutoMocker();

            var repository = mocker.GetMock<IClienteRepository>();
            var documento = _faker.Person.Cpf();

            repository.Setup(x => x.ObterDadosCliente(documento)).ReturnsAsync(_modelFixture.ListaCliente);

            var service = new ClienteService(repository.Object);

            var result = await service.ObterDadosCliente(documento);

            mocker.GetMock<IClienteRepository>().Verify(x => x.ObterDadosCliente(documento), Times.Once);

            Assert.Contains(result, item => item.Ativo);

        }
    }
}
