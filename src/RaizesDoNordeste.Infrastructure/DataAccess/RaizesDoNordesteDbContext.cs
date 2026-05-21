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

        modelBuilder.Entity<Unidade>().HasData(
            new Unidade { Id = new Guid("ceb2764a-43ea-4189-bddc-4dbddcd4bbcf"), Nome = "Unidade Centro" },
            new Unidade { Id = new Guid("9be89316-4b0e-444b-b890-20ba6a07faf4"), Nome = "Unidade Cabral" },
            new Unidade { Id = new Guid("2674c278-9435-438a-bc5e-444bcfc94e67"), Nome = "Unidade Portão" }
        );
    }
}