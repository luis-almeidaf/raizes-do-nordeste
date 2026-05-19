using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Infrastructure.DataAccess;

public class RaizesDoNordesteDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(usuario => usuario.Id);
            entity.HasOne(usuario => usuario.Unidade)
                .WithMany(unidade => unidade.Usuarios)
                .HasForeignKey(usuario => usuario.UnidadeId);
        });
    }
}