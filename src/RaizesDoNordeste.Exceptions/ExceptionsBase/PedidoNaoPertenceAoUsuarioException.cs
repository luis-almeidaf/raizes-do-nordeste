using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class PedidoNaoPertenceAoUsuarioException()
    : RaizesDoNordesteException(MensagensDeErro.PEDIDO_NAO_PERTENCE_AO_USUARIO)
{
    public override int StatusCode => (int)HttpStatusCode.Conflict;
    public override List<string> GetErrors() => [Message];
}