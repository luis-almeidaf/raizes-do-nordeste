using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class PedidoNaoEncontradoException() : RaizesDoNordesteException(MensagensDeErro.PEDIDO_NAO_ENCONTRADO)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;
    public override List<string> GetErrors() => [Message];
}