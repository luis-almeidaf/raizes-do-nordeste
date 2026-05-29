using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaizesDoNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDeUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("73396d14-99c3-49fc-b1ce-b052e5e5c50d"),
                column: "UnidadeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("99311212-2878-42c4-b5c4-6a2f79d3833d"),
                column: "UnidadeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("bea1c218-b855-4ca8-8358-6da9cb59f590"),
                column: "UnidadeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("ce08874a-8df3-4abe-abd6-587c22630cb1"),
                column: "UnidadeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("fc27019d-bbc4-45d5-b6c0-cf91d10828f5"),
                column: "UnidadeId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("73396d14-99c3-49fc-b1ce-b052e5e5c50d"),
                column: "UnidadeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("99311212-2878-42c4-b5c4-6a2f79d3833d"),
                column: "UnidadeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("bea1c218-b855-4ca8-8358-6da9cb59f590"),
                column: "UnidadeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("ce08874a-8df3-4abe-abd6-587c22630cb1"),
                column: "UnidadeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("fc27019d-bbc4-45d5-b6c0-cf91d10828f5"),
                column: "UnidadeId",
                value: null);
        }
    }
}
