using MediatR;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories;
using RaizesDoNordeste.Domain.Security.Tokens;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Application.Features.Auth.Commands.RefreshTokenLogin;

public class RefreshTokenLoginCommandHandler(
    IAccessTokenGenerator tokenGenerator,
    IRefreshTokenReadOnlyRepository refreshTokenReadRepo,
    IRefreshTokenWriteOnlyRepository refreshTokenWriteRepo,
    IUnitOfWork unitOfWork
) : IRequestHandler<RefreshTokenLoginCommand, RefreshTokenLoginResponse>
{
    public async Task<RefreshTokenLoginResponse> Handle(RefreshTokenLoginCommand request,
        CancellationToken cancellationToken)
    {
        var refreshToken = await refreshTokenReadRepo.BuscarToken(request.RefreshToken);

        if (refreshToken is null || refreshToken.ExpiraEm < DateTime.UtcNow)
            throw new RefreshTokenExpiradoException();

        var novoRefreshToken = RefreshToken.Criar(tokenGenerator.GerarRefreshToken(), refreshToken.UsuarioId);
        var accessToken = tokenGenerator.GerarTokenJwt(refreshToken.Usuario);

        await refreshTokenWriteRepo.Remover(refreshToken.UsuarioId);
        await refreshTokenWriteRepo.Salvar(novoRefreshToken);
        await unitOfWork.Commit();

        return new RefreshTokenLoginResponse
        {
            Token = accessToken,
            RefreshToken = novoRefreshToken.Token
        };
    }
}