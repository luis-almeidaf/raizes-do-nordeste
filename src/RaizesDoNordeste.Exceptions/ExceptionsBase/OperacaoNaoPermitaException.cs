using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class OperacaoNaoPermitaException(string message) : RaizesDoNordesteException(message)
{
    public override int StatusCode => (int)HttpStatusCode.Conflict;
    public override List<string> GetErrors() => [Message];
}