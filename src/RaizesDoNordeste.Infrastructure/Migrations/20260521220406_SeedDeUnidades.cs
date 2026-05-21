using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RaizesDoNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDeUnidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { new Guid("2674c278-9435-438a-bc5e-444bcfc94e67"), "Unidade Portão" },
                    { new Guid("9be89316-4b0e-444b-b890-20ba6a07faf4"), "Unidade Cabral" },
                    { new Guid("ceb2764a-43ea-4189-bddc-4dbddcd4bbcf"), "Unidade Centro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: new Guid("2674c278-9435-438a-bc5e-444bcfc94e67"));

            migrationBuilder.DeleteData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: new Guid("9be89316-4b0e-444b-b890-20ba6a07faf4"));

            migrationBuilder.DeleteData(
                table: "Unidade",
                keyColumn: "Id",
                keyValue: new Guid("ceb2764a-43ea-4189-bddc-4dbddcd4bbcf"));
        }
    }
}
