using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class ProdutoNaoDisponivelEmEstoque(int produtoId)
    : RaizesDoNordesteException(string.Format(MensagensDeErro.PRODUTO_NAO_DISPONIVEL, produtoId))
{
    public override int StatusCode => (int)HttpStatusCode.UnprocessableEntity;

    public override List<string> GetErrors() => [Message];
}