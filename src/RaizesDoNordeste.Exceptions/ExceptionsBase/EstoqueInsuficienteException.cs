using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class EstoqueInsuficienteException(int produtoId)
    : RaizesDoNordesteException(string.Format(MensagensDeErro.ESTOQUE_INSUFICIENTE, produtoId))
{
    public override int StatusCode => (int)HttpStatusCode.UnprocessableEntity;

    public override List<string> GetErrors() => [Message];
}