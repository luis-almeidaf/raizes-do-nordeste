using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string GerarTokenJwt(Usuario usuario);
    string GerarRefreshToken();
}