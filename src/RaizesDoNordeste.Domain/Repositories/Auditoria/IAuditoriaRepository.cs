namespace RaizesDoNordeste.Domain.Repositories.Auditoria;

public interface IAuditoriaRepository
{
    Task Salvar(Entities.Auditoria auditoria);
}