using FluentValidation.Results;
using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories;
using RaizesDoNordeste.Domain.Security.Criptography;
using RaizesDoNordeste.Domain.Security.Tokens;
using RaizesDoNordeste.Exceptions;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Auth.CadastrarUsuarioCommand;

public class CadastrarUsuarioCommandHandler(
    IUnitOfWork unitOfWork,
    IPasswordEncrypter passwordEncrypter,
    IAccessTokenGenerator tokenGenerator,
    IRefreshTokenWriteOnlyRepository refreshTokenRepository,
    IUsuarioReadOnlyRepository usuarioReadOnlyRepository,
    IUsuarioWriteOnlyRepository usuarioWriteOnlyRepository) 
    : IRequestHandler<CadastrarUsuarioCommand, CadastrarUsuarioResponse>
{
    public async Task<CadastrarUsuarioResponse> Handle(CadastrarUsuarioCommand request,
        CancellationToken cancellationToken)
    {
        await Validate(request);

        var usuario = Usuario.Criar(request.Nome, request.Sobrenome, request.Email);
        usuario.DefinirSenha(passwordEncrypter.Criptografar(usuario.Senha));

        var refreshToken = RefreshToken.Criar(tokenGenerator.GerarRefreshToken(), usuario.Id);

        await refreshTokenRepository.Salvar(refreshToken);
        await usuarioWriteOnlyRepository.Cadastrar(usuario);
        await unitOfWork.Commit();

        return new CadastrarUsuarioResponse()
        {
            Id = usuario.Id,
            Nome = usuario.Nome,
            Token = tokenGenerator.GerarTokenJwt(usuario),
            RefreshToken = refreshToken.Token,
        };
    }

    private async Task Validate(CadastrarUsuarioCommand request)
    {
        var resultado = await new CadastrarUsuarioValidator().ValidateAsync(request);
        var emailJaCadastrado = await usuarioReadOnlyRepository.EmailJaCadastrado(request.Email);

        if (emailJaCadastrado)
            resultado.Errors.Add(new ValidationFailure(string.Empty, MensagensDeErro.EMAIL_JA_CADASTRADO));

        if (!resultado.IsValid)
        {
            var erros = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();
            throw new ErroDeValidacaoException(erros);
        }
    }
}