using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.Cancelar;

public class CancelarPedidoResponse
{
    public string Mensagem { get; set; } = null!;

    public static CancelarPedidoResponse Criar( string mensagem) => new()
    {
        Mensagem = mensagem
    };
}