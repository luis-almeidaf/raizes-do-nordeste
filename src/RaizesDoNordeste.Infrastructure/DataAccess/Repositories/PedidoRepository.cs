using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories.Pedido;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class PedidoRepository(RaizesDoNordesteDbContext dbContext) : IPedidoWriteOnlyRepository
{
    public async Task<Pedido?> BuscarPorId(int pedidoId) => await dbContext.Pedido
        .Include(p => p.ItensPedido).ThenInclude(itemPedido => itemPedido.Produto)
        .FirstOrDefaultAsync(p => p.Id == pedidoId);

    public async Task Salvar(Pedido pedido) => await dbContext.Pedido.AddAsync(pedido);

    public void AtualizarPedido(Pedido pedido) => dbContext.Pedido.Update(pedido);
}