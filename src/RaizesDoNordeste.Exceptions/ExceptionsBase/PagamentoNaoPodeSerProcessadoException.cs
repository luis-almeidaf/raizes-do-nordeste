using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class PagamentoNaoPodeSerProcessadoException()
    : RaizesDoNordesteException(MensagensDeErro.PAGAMENTO_NAO_PODE_SER_PROCESSADO)
{
    public override int StatusCode => (int)HttpStatusCode.Conflict;
    public override List<string> GetErrors() => [Message];
}