namespace RaizesDoNordeste.Domain.Repositories.Pedido;

public interface IPedidoWriteOnlyRepository
{
    Task Salvar(Entities.Pedido pedido);
}