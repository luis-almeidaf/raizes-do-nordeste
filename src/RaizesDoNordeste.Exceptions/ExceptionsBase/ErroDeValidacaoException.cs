using System.Net;

namespace RaizesDoNordeste.Exceptions.ExceptionsBase;

public class ErroDeValidacaoException(List<string> erros) : RaizedDoNordesteException(string.Empty)
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
    public override List<string> GetErrors() => erros;
}