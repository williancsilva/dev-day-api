using Bogus;
using Bogus.Extensions.Brazil;
using Dayconnect.Fidelity.Domain.Models;
using Dayconnect.Fidelity.Domain.Models.Signature;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Dayconnect.Fidelity.Test.Domain.Fixtures
{
    [CollectionDefinition(nameof(ModelsCollection))]
    public class ModelsCollection : ICollectionFixture<ModelFixture>
    {

    }
    public class ModelFixture
    {
        public LogDominio LogDominio { get { return GerarLogDominioValido(); } }
        public Login Login { get { return GerarLoginValido(); } }
        public Cliente Cliente { get { return GerarClienteValido(); } }
        public IEnumerable<Cliente> ListaCliente { get { return GerarListaClienteValido(); } }
        public AutenticarUsuarioSignature AutenticarUsuario { get { return GerarAutenticarUsuarioSignatureValido(); } }
        public CriarSessaoSignature CriarSessao { get { return GerarCriarSessaoSignatureValido(); } }
        public SessaoSignature Sessao { get { return GerarSessaoSignatureValido(); } }

        private SessaoSignature GerarSessaoSignatureValido()
        {
            var faker = new Faker<SessaoSignature>("pt_BR").CustomInstantiator(f =>
            {
                return new SessaoSignature(f.Random.Guid().ToString());
            });

            return faker.Generate(1).First();
        }
        private CriarSessaoSignature GerarCriarSessaoSignatureValido()
        {
            var faker = new Faker<CriarSessaoSignature>("pt_BR").CustomInstantiator(f =>
            {
                return new CriarSessaoSignature(f.Internet.Email(), f.Internet.Ip(), f.Random.Word(), f.Random.Number(10,30).ToString());
            });

            return faker.Generate(1).First();
        }
        private AutenticarUsuarioSignature GerarAutenticarUsuarioSignatureValido()
        {
            var faker = new Faker<AutenticarUsuarioSignature>("pt_BR").CustomInstantiator(f =>
            {
                return new AutenticarUsuarioSignature(f.Random.Guid().ToString(), f.Internet.Email(), f.Internet.Password());
            });

            return faker.Generate(1).First();
        }
        private LogDominio GerarLogDominioValido()
        {
            var faker = new Faker<LogDominio>("pt_BR").CustomInstantiator(f =>
            {
                return new LogDominio(f.Person.Cpf(), f.Random.Word(),f.Internet.Url(),f.Internet.Email(),f.Internet.Ip());
            });

            return faker.Generate(1).First();
        }
        private Login GerarLoginValido()
        {
            string id = $"353_{Guid.NewGuid()}";
            return new Login(id, true, true);
        }
        private Cliente GerarClienteValido()
        {
            var faker = new Faker<Cliente>("pt_BR").CustomInstantiator(f =>
            {
                var cliente = new Cliente(f.Person.FullName, f.Person.Cpf());
                cliente.SetAtivo(true);
                return cliente;
            });

            return faker.Generate(1).First();
        }
        private IEnumerable<Cliente> GerarListaClienteValido()
        {
            var faker = new Faker<Cliente>("pt_BR").CustomInstantiator(f =>
            {
                var cliente = new Cliente(f.Person.FullName, f.Person.Cpf());
                cliente.SetAtivo(true);
                return cliente;
            });

            return faker.Generate(10);
        }
    }

}
