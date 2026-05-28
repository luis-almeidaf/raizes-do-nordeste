using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Application.Features.Pedidos.Commands.AtualizarStatus;

public class AtualizarStatusResponse
{
    public Status NovoStatus { get; set; }
    public string Mensagem { get; set; } = null!;

    public static AtualizarStatusResponse Criar(Status novoStatus, string mensagem) => new()
    {
        NovoStatus = novoStatus,
        Mensagem = mensagem
    };
}