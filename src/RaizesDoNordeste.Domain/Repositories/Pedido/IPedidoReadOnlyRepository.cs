namespace RaizesDoNordeste.Domain.Repositories.Pedido;

public interface IPedidoReadOnlyRepository
{
    Task<Entities.Pedido?> BuscarPorId(int pedidoId, Guid usuarioId);
}