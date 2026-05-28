namespace RaizesDoNordeste.Domain.Repositories.Pedido;

public interface IPedidoWriteOnlyRepository
{
    Task Salvar(Entities.Pedido pedido);
    Task<Entities.Pedido?> BuscarPorId(int pedidoId);
    void AtualizarPedido(Entities.Pedido pedido);
}