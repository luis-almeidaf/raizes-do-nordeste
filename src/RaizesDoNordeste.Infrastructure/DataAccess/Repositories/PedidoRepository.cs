using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories.Pedido;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class PedidoRepository(RaizesDoNordesteDbContext dbContext)
    : IPedidoWriteOnlyRepository, IPedidoReadOnlyRepository
{
    Task<Pedido?> IPedidoReadOnlyRepository.BuscarPorId(int pedidoId, Guid usuarioId)
    {
        return dbContext.Pedido
            .AsNoTracking().Include(pedido => pedido.ItensPedido).ThenInclude(itemPedido => itemPedido.Produto)
            .FirstOrDefaultAsync(pedido => pedido.Id == pedidoId && pedido.ClienteId == usuarioId);
    }

    async Task<Pedido?> IPedidoWriteOnlyRepository.BuscarPorId(int pedidoId)
    {
        return await dbContext.Pedido
            .Include(p => p.ItensPedido).ThenInclude(itemPedido => itemPedido.Produto)
            .FirstOrDefaultAsync(p => p.Id == pedidoId);
    }

    public async Task Salvar(Pedido pedido) => await dbContext.Pedido.AddAsync(pedido);

    public void AtualizarPedido(Pedido pedido) => dbContext.Pedido.Update(pedido);
}