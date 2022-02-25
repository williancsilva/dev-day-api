using Bogus;
using Dayconnect.Fidelity.App.Dto.Signature;
using System.Linq;
using Xunit;
using Bogus.Extensions.Brazil;

namespace Dayconnect.Fidelity.Test.App.Fixtures;

[CollectionDefinition(nameof(DtoCollection))]
public class DtoCollection : ICollectionFixture<DtoFixture>
{
}

public class DtoFixture
{
    public static ObterDadosClienteSignature ObterDadosCliente => GerarObterDadosClienteSignature();
    public static InativarClienteSignature InativarCliente => GerarInativarClienteSignature();
    public static LoginSignature EfetuarLogin => GerarLoginSignature();

    private static LoginSignature GerarLoginSignature()
    {
        var faker = new Faker<LoginSignature>("pt_BR").CustomInstantiator(f => new LoginSignature
        {
            Ip = f.Internet.Ip(),
            Login = f.Internet.Email(),
            Password = f.Internet.Password(),
            DeviceId = f.Random.Words(),
            VersaoDispositivo = f.Random.Number(1, 100).ToString()
        });

        return faker.Generate(1).First();
    }

    private static ObterDadosClienteSignature GerarObterDadosClienteSignature()
    {
        var faker = new Faker<ObterDadosClienteSignature>("pt_BR").CustomInstantiator(f => new ObterDadosClienteSignature
        {
            CpfCnpj = f.Person.Cpf()
        });

        return faker.Generate(1).First();
    }

    private static InativarClienteSignature GerarInativarClienteSignature()
    {
        var faker = new Faker<InativarClienteSignature>("pt_BR").CustomInstantiator(f => new InativarClienteSignature
        {
            CpfCnpj = f.Person.Cpf()
        });

        return faker.Generate(1).First();
    }
}