using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class OperacaoNaoPermitaException() : RaizesDoNordesteException(MensagensDeErro.OPERACAO_NAO_PERMITIDA)
{
    public override int StatusCode => (int)HttpStatusCode.Conflict;
    public override List<string> GetErrors() => [Message];
}