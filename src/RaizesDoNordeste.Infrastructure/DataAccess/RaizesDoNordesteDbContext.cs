using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Infrastructure.DataAccess;

public class RaizesDoNordesteDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Unidade> Unidade { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(usuario => usuario.Id);
            entity.HasOne(usuario => usuario.Unidade)
                .WithMany(unidade => unidade.Funcionarios)
                .HasForeignKey(usuario => usuario.UnidadeId);
        });

        modelBuilder.Entity<Unidade>(entity =>
        {
            entity.HasKey(unidade => unidade.Id);
            entity.HasOne(unidade => unidade.Estoque)
                .WithOne()
                .HasForeignKey<Estoque>(estoque => estoque.UnidadeId);
        });

        modelBuilder.Entity<ItemEstoque>(entity =>
        {
            entity.HasKey(item => item.Id);
            entity.HasOne(item => item.Produto)
                .WithMany()
                .HasForeignKey(item => item.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.ToTable("ItensEstoque");
        });

        modelBuilder.Entity<Unidade>().HasData(
            new Unidade { Id = 1, Nome = "Unidade Centro" },
            new Unidade { Id = 2, Nome = "Unidade Cabral" },
            new Unidade { Id = 3, Nome = "Unidade Portão" }
        );

        modelBuilder.Entity<Produto>().HasData(
            new Produto { Id = 1, Nome = "Cuscuz de camarão", Descricao = "Com requeijão cremoso", Preco = 29.5m },
            new Produto { Id = 2, Nome = "Cuscuz de carne sol", Descricao = "Com requeijão cremoso", Preco = 25.0m },
            new Produto { Id = 3, Nome = "Cuscuz de carne seca", Descricao = "Com requeijão cremoso", Preco = 27.5m },
            new Produto { Id = 4, Nome = "Tapioca com chocolate", Descricao = "Com chocolate", Preco = 10.0m },
            new Produto { Id = 5, Nome = "Tapioca com doce leite", Descricao = "Com doce de leite", Preco = 10.0m },
            new Produto { Id = 6, Nome = "Tapioca de queijo", Descricao = "Com queijo", Preco = 12.0m },
            new Produto { Id = 7, Nome = "Coca-cola", Descricao = "Garrafa 2L", Preco = 10.0m },
            new Produto { Id = 8, Nome = "Pepsi", Descricao = "Garrafa 2L", Preco = 9.5m },
            new Produto { Id = 9, Nome = "Suco laranja", Descricao = "Garrafa 500ML", Preco = 8.0m },
            new Produto { Id = 10, Nome = "Porção de queijo coalho", Descricao = "Porção de 500GR", Preco = 30.0m }
        );
    }
}