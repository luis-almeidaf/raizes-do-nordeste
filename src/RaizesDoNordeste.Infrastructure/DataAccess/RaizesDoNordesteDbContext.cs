using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;

namespace RaizesDoNordeste.Infrastructure.DataAccess;

public class RaizesDoNordesteDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Unidade> Unidade { get; set; }
    public DbSet<Estoque> Estoque { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<ItemEstoque> ItemEstoque { get; set; }

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
                .WithOne(estoque => estoque.Unidade)
                .HasForeignKey<Estoque>(estoque => estoque.UnidadeId);
        });

        modelBuilder.Entity<ItemEstoque>(entity =>
        {
            entity.HasKey(item => item.Id);
            entity.HasOne(item => item.Estoque)
                .WithMany()
                .HasForeignKey(item => item.EstoqueId)
                .OnDelete(DeleteBehavior.NoAction);
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

        modelBuilder.Entity<Estoque>().HasData(
            new Estoque { Id = Guid.Parse("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), UnidadeId = 1 },
            new Estoque { Id = Guid.Parse("28efd76e-2df0-4eff-8618-c31750451536"), UnidadeId = 2 },
            new Estoque { Id = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), UnidadeId = 3 }
        );

        modelBuilder.Entity<ItemEstoque>().HasData(
            new ItemEstoque
            {
                Id = Guid.Parse("24230b66-c6fa-4d7b-9d28-5eb6897928f6"),
                EstoqueId = Guid.Parse("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), ProdutoId = 1, Quantidade = 10
            },
            new ItemEstoque
            {
                Id = Guid.Parse("226acdbd-1743-4c44-8275-b816c8ee2b5b"),
                EstoqueId = Guid.Parse("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), ProdutoId = 2, Quantidade = 6
            },
            new ItemEstoque
            {
                Id = Guid.Parse("c033df3d-bc83-4be5-8992-2662af1b8520"),
                EstoqueId = Guid.Parse("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), ProdutoId = 3, Quantidade = 12
            },
            new ItemEstoque
            {
                Id = Guid.Parse("7193fc9c-988f-400f-9cc3-06b26f2ac49d"),
                EstoqueId = Guid.Parse("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), ProdutoId = 4, Quantidade = 11
            },
            new ItemEstoque
            {
                Id = Guid.Parse("4661f17b-4781-4f8e-a80f-8095b901b787"),
                EstoqueId = Guid.Parse("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), ProdutoId = 5, Quantidade = 6
            },
            new ItemEstoque
            {
                Id = Guid.Parse("0ae75959-96a8-4294-908a-eb277eec9567"),
                EstoqueId = Guid.Parse("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), ProdutoId = 9, Quantidade = 6
            },
            new ItemEstoque
            {
                Id = Guid.Parse("b41e8335-2786-4a92-9ad4-bc1af6275916"),
                EstoqueId = Guid.Parse("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), ProdutoId = 10, Quantidade = 15
            },
            new ItemEstoque
            {
                Id = Guid.Parse("15915bce-5ac2-4502-9ef4-95b60cd307f2"),
                EstoqueId = Guid.Parse("28efd76e-2df0-4eff-8618-c31750451536"), ProdutoId = 1, Quantidade = 12
            },
            new ItemEstoque
            {
                Id = Guid.Parse("cbc73a05-9c04-48c4-bf94-1676ff93fd2e"),
                EstoqueId = Guid.Parse("28efd76e-2df0-4eff-8618-c31750451536"), ProdutoId = 2, Quantidade = 15
            },
            new ItemEstoque
            {
                Id = Guid.Parse("dbc5458b-b3ca-48af-b917-cdde604250f9"),
                EstoqueId = Guid.Parse("28efd76e-2df0-4eff-8618-c31750451536"), ProdutoId = 3, Quantidade = 11
            },
            new ItemEstoque
            {
                Id = Guid.Parse("65ec4b5c-c88d-424f-8f2c-ee9d95e39df6"),
                EstoqueId = Guid.Parse("28efd76e-2df0-4eff-8618-c31750451536"), ProdutoId = 8, Quantidade = 12
            },
            new ItemEstoque
            {
                Id = Guid.Parse("b6e2e780-f78d-4bfa-9d7f-d5811f770665"),
                EstoqueId = Guid.Parse("28efd76e-2df0-4eff-8618-c31750451536"), ProdutoId = 9, Quantidade = 12
            },
            new ItemEstoque
            {
                Id = Guid.Parse("054919e4-56b1-42c2-b6b8-87ba307a3151"),
                EstoqueId = Guid.Parse("28efd76e-2df0-4eff-8618-c31750451536"), ProdutoId = 10, Quantidade = 12
            },
            new ItemEstoque
            {
                Id = Guid.Parse("1640f03c-a718-4a61-80f1-b92979814b4b"),
                EstoqueId = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), ProdutoId = 3, Quantidade = 16
            },
            new ItemEstoque
            {
                Id = Guid.Parse("20fc78bd-fa0e-4b7d-8aaf-1016b44672ce"),
                EstoqueId = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), ProdutoId = 4, Quantidade = 8
            },
            new ItemEstoque
            {
                Id = Guid.Parse("7a38cf98-3183-4b79-8aa6-c19fd2661b4f"),
                EstoqueId = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), ProdutoId = 5, Quantidade = 5
            },
            new ItemEstoque
            {
                Id = Guid.Parse("94ce378e-8946-4613-a121-3f2af9815aae"),
                EstoqueId = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), ProdutoId = 6, Quantidade = 5
            },
            new ItemEstoque
            {
                Id = Guid.Parse("c1c00c28-e68d-4475-97af-7004f81f3b6e"),
                EstoqueId = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), ProdutoId = 7, Quantidade = 14
            },
            new ItemEstoque
            {
                Id = Guid.Parse("58256543-ab3b-4ef5-8ce1-5fbd7e5b7206"),
                EstoqueId = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), ProdutoId = 8, Quantidade = 10
            },
            new ItemEstoque
            {
                Id = Guid.Parse("5d364e6e-cd1a-4625-9ee5-e6934adf934e"),
                EstoqueId = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), ProdutoId = 9, Quantidade = 18
            },
            new ItemEstoque
            {
                Id = Guid.Parse("4cfac063-6c5f-4470-97a4-bd908278ef94"),
                EstoqueId = Guid.Parse("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), ProdutoId = 10, Quantidade = 20
            }
        );
    }
}