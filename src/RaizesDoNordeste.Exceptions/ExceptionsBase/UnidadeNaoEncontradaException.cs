using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class UnidadeNaoEncontradaException() : RaizesDoNordesteException(MensagensDeErro.UNIDADE_NAO_ENCONTRADA)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors() => [Message];
}