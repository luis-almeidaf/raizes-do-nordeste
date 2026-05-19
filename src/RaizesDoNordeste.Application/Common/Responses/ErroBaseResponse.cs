namespace RaizesDoNordeste.Application.Common.Responses;

public class ErroBaseResponse
{
    public List<string> Erros { get; }

    public ErroBaseResponse(string erros) => Erros = [erros];
    
    public ErroBaseResponse(List<string> erros) => Erros = erros;
}