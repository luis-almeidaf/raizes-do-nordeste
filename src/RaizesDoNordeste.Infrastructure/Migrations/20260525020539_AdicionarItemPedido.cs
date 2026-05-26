using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaizesDoNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarItemPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "Estoque",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"),
                column: "ProdutoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: new Guid("28efd76e-2df0-4eff-8618-c31750451536"),
                column: "ProdutoId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"),
                column: "ProdutoId",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
