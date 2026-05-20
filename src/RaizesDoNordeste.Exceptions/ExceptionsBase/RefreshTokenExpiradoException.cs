using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class RefreshTokenExpiradoException() : RaizesDoNordesteException(MensagensDeErro.REFRESH_TOKEN_EXPIRADO)
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors() => [Message];
}