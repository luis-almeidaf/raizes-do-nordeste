using RaizesDoNordeste.Domain.Enums;

namespace RaizesDoNordeste.Domain.Repositories.Pedido;

public interface IPedidoReadOnlyRepository
{
    Task<Entities.Pedido?> BuscarPorId(int pedidoId, Guid usuarioId);

    public Task<(List<Entities.Pedido>, int Total)> BuscarPedidosDoCliente(Guid usuarioId, int pagina,
        int tamanhoPagina, Status? status);

    public Task<(List<Entities.Pedido>, int Total)> BuscarPedidosUnidade(int? unidadeId, int pagina,
        int tamanhoPagina, Status? status, CanalPedido? canalPedido);
}