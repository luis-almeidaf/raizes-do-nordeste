using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RaizesDoNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDeUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Role", "Senha", "Sobrenome", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("73396d14-99c3-49fc-b1ce-b052e5e5c50d"), "cliente@email.com", "Cliente", 0, "$2a$11$bAuOcT03JZKfYVZQ.lj5Ne8E06SrGLnghArbkEnc25s1hEJh6SLnq", "Cliente", null },
                    { new Guid("99311212-2878-42c4-b5c4-6a2f79d3833d"), "gerente@email.com", "Gerente", 3, "$2a$11$bAuOcT03JZKfYVZQ.lj5Ne8E06SrGLnghArbkEnc25s1hEJh6SLnq", "Gerente", null },
                    { new Guid("bea1c218-b855-4ca8-8358-6da9cb59f590"), "atendente@email.com", "Atendente", 1, "$2a$11$bAuOcT03JZKfYVZQ.lj5Ne8E06SrGLnghArbkEnc25s1hEJh6SLnq", "Atendente", null },
                    { new Guid("ce08874a-8df3-4abe-abd6-587c22630cb1"), "admin@email.com", "Administrador", 4, "$2a$11$bAuOcT03JZKfYVZQ.lj5Ne8E06SrGLnghArbkEnc25s1hEJh6SLnq", "Administrador", null },
                    { new Guid("fc27019d-bbc4-45d5-b6c0-cf91d10828f5"), "cozinha@email.com", "Cozinha", 2, "$2a$11$bAuOcT03JZKfYVZQ.lj5Ne8E06SrGLnghArbkEnc25s1hEJh6SLnq", "Cozinha", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("73396d14-99c3-49fc-b1ce-b052e5e5c50d"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("99311212-2878-42c4-b5c4-6a2f79d3833d"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("bea1c218-b855-4ca8-8358-6da9cb59f590"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("ce08874a-8df3-4abe-abd6-587c22630cb1"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("fc27019d-bbc4-45d5-b6c0-cf91d10828f5"));
        }
    }
}
