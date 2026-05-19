using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class LoginInvalidoException() : RaizesDoNordesteException(MensagensDeErro.LOGIN_INVALIDO)
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}