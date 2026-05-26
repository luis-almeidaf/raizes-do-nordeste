using RaizesDoNordeste.Domain.Security.Tokens;

namespace RaizesDoNordeste.Api.Token;

public class HttpTokenContext(IHttpContextAccessor httpContextAccessor) : ITokenContexto
{
    public string BuscarToken()
    {
        var autorizacao = httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return autorizacao["Bearer ".Length..].Trim();
    }
}