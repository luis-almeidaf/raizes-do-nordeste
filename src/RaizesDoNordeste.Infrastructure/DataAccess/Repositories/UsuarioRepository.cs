using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Repositories;

namespace RaizesDoNordeste.Infrastructure.DataAccess.Repositories;

internal class UsuarioRepository(RaizesDoNordesteDbContext dbContext) :IUsuarioReadOnlyRepository, IUsuarioWriteOnlyRepository
{
    public async Task Cadastrar(Usuario usuario) => await dbContext.Usuarios.AddAsync(usuario);
    
    public async Task<bool> EmailJaCadastrado(string email) => await dbContext.Usuarios.AnyAsync(usuario => usuario.Email.Equals(email));
    
}