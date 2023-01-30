using DevSecOps.backoffice.Domain.Interfaces.Service;
using DevSecOps.backoffice.Domain.Models;
using DevSecOps.backoffice.Domain.Models.Result;
using DevSecOps.backoffice.Domain.Models.Signature;
using DevSecOps.BackOffice.Domain.Interfaces.Repository;
using DevSecOps.BackOffice.Domain.Models;

namespace DevSecOps.backoffice.Domain.Service;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly IAutenticacaoRepository _repository;

    public AutenticacaoService(IAutenticacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Login?> Login(string login, string senha, string ip, string deviceId, string versaoDispositivo)
    {
        var dayId = await _repository.CriarSessao(login);
        var result = await AutenticarUsuario(new AutenticarUsuarioSignature(dayId, login, senha));

        return new Login(dayId, result?.Autenticado, true, result?.Permissoes, result.Senha);
    }

    public async Task<SessaoResult> ObterSessao(SessaoSignature signature)
    {
        return await _repository.ObterSessao(signature.DayId);
    }

    public async Task<AutenticarUsuarioResult> AutenticarUsuario(AutenticarUsuarioSignature signature)
    {
        var sessao = await _repository.ObterSessao(signature.DayId);
        var autenticacaoUsuario = new AutenticarUsuarioResult();

        var hash = new Hash();
        var senhaCripto = hash.HashPassword($"{signature.Senha}{sessao.Salt}");

        if (sessao != null && senhaCripto == sessao.Senha)
        {
            autenticacaoUsuario.AutenticarUsuario(sessao);
            await _repository.AtualizarSessao(signature.DayId, true);

        }

        return autenticacaoUsuario;
    }

    public async Task Logoff(string dayId)
    {
        await _repository.AtualizarSessao(int.Parse(dayId), false);
    }
}