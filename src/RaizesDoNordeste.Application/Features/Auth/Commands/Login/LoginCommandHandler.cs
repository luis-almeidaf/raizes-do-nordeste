using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories;
using RaizesDoNordeste.Domain.Security.Criptography;
using RaizesDoNordeste.Domain.Security.Tokens;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler(
    IUsuarioReadOnlyRepository usuarioRepo,
    IPasswordEncrypter passwordEncrypter,
    IUnitOfWork unitOfWork,
    IAccessTokenGenerator tokenGenerator,
    IRefreshTokenWriteOnlyRepository refreshTokenRepo) : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var usuario = await usuarioRepo.BuscarUsuarioPorEmail(request.Email) ?? throw new LoginInvalidoException();

        var passwordMatch = passwordEncrypter.VerificarSenha(request.Senha, usuario.Senha);
        if (!passwordMatch)
            throw new LoginInvalidoException();

        var refreshToken = RefreshToken.Criar(tokenGenerator.GerarRefreshToken(), usuario.Id);

        await refreshTokenRepo.Remover(usuario.Id);
        await refreshTokenRepo.Salvar(refreshToken);
        await unitOfWork.Commit();

        return new LoginResponse
        {
            UsuarioId = usuario.Id,
            Nome = usuario.Nome,
            Token = tokenGenerator.GerarTokenJwt(usuario),
            RefreshToken = refreshToken.Token
        };
    }
}