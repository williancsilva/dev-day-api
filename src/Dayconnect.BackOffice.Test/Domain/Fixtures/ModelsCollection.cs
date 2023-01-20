using Bogus;
using Bogus.Extensions.Brazil;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Domain.Models.Signature;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DevSecOps.backoffice.Test.Domain.Fixtures;

[CollectionDefinition(nameof(ModelsCollection))]
public class ModelsCollection : ICollectionFixture<ModelFixture>
{
}

public class ModelFixture
{
    public static LogDominio LogDominio => GerarLogDominioValido();

    public static Login Login => GerarLoginValido();

    public static Cliente Cliente => GerarClienteValido();

    public static IEnumerable<Cliente> ListaCliente => GerarListaClienteValido();

    public static AutenticarUsuarioSignature AutenticarUsuario => GerarAutenticarUsuarioSignatureValido();

    public static CriarSessaoSignature CriarSessao => GerarCriarSessaoSignatureValido();

    public static SessaoSignature Sessao => GerarSessaoSignatureValido();
    public static ObterTipoAutenticacaoSignature ObterTipoAutenticacao => GerarObterTipoAutenticacaoSignatureValido();
    private static ObterTipoAutenticacaoSignature GerarObterTipoAutenticacaoSignatureValido()
    {
        var faker = new Faker<ObterTipoAutenticacaoSignature>("pt_BR").CustomInstantiator(f => new ObterTipoAutenticacaoSignature(f.Internet.ExampleEmail()));

        return faker.Generate(1).First();
    }
    private static SessaoSignature GerarSessaoSignatureValido()
    {
        var faker = new Faker<SessaoSignature>("pt_BR").CustomInstantiator(f => new SessaoSignature(f.Random.Guid().ToString()));

        return faker.Generate(1).First();
    }

    private static CriarSessaoSignature GerarCriarSessaoSignatureValido()
    {
        var faker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
            new CriarSessaoSignature(f.Internet.Email(), f.Internet.Ip(), f.Random.Word(), f.Random.Number(10, 30).ToString()));

        return faker.Generate(1).First();
    }

    private static AutenticarUsuarioSignature GerarAutenticarUsuarioSignatureValido()
    {
        var faker = new Faker<AutenticarUsuarioSignature>("pt_BR").CustomInstantiator(f =>
            new AutenticarUsuarioSignature(f.Random.Guid().ToString(), f.Internet.Email(), f.Internet.Password(),9));

        return faker.Generate(1).First();
    }

    private static LogDominio GerarLogDominioValido()
    {
        var faker = new Faker<LogDominio>("pt_BR").CustomInstantiator(f => new LogDominio(f.Person.Cpf(), f.Random.Word(), f.Internet.Url(), f.Internet.Email(), f.Internet.Ip()));

        return faker.Generate(1).First();
    }

    private static Login GerarLoginValido()
    {
        var id = $"439_{Guid.NewGuid()}";
        return new Login(id, true, true);
    }

    private static Cliente GerarClienteValido()
    {
        var faker = new Faker<Cliente>("pt_BR").CustomInstantiator(f => new Cliente(f.Person.FullName, f.Person.Cpf(), true));

        return faker.Generate(1).First();
    }

    private static IEnumerable<Cliente> GerarListaClienteValido()
    {
        var faker = new Faker<Cliente>("pt_BR").CustomInstantiator(f => new Cliente(f.Person.FullName, f.Person.Cpf(), true));

        return faker.Generate(10);
    }
}