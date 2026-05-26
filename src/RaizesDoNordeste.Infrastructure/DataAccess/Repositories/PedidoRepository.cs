using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories.Pedido;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

public class PedidoRepository(RaizesDoNordesteDbContext dbContext) : IPedidoWriteOnlyRepository
{
    public async Task Salvar(Pedido pedido) => await dbContext.Pedido.AddAsync(pedido);
}