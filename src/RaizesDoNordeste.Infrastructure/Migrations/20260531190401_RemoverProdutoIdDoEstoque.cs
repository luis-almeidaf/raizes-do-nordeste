using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaizesDoNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoverProdutoIdDoEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_ProdutoId",
                table: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Estoque");
            migrationBuilder.DropForeignKey(
                name: "FK_ItensEstoque_Produto_ProdutoId",
                table: "ItensEstoque");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensEstoque_Produto_ProdutoId",
                table: "ItensEstoque",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverte a mudança do FK de ItensEstoque
            migrationBuilder.DropForeignKey(
                name: "FK_ItensEstoque_Produto_ProdutoId",
                table: "ItensEstoque");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensEstoque_Produto_ProdutoId",
                table: "ItensEstoque",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // Recria a coluna ProdutoId no Estoque
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Estoque",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_ProdutoId",
                table: "Estoque",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }
    }
}
