using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RaizesDoNordeste.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EstoqueSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estoque",
                columns: new[] { "Id", "UnidadeId" },
                values: new object[,]
                {
                    { new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), 1 },
                    { new Guid("28efd76e-2df0-4eff-8618-c31750451536"), 2 },
                    { new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 3 }
                });

            migrationBuilder.InsertData(
                table: "ItensEstoque",
                columns: new[] { "Id", "EstoqueId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { new Guid("054919e4-56b1-42c2-b6b8-87ba307a3151"), new Guid("28efd76e-2df0-4eff-8618-c31750451536"), 10, 12 },
                    { new Guid("0ae75959-96a8-4294-908a-eb277eec9567"), new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), 9, 6 },
                    { new Guid("15915bce-5ac2-4502-9ef4-95b60cd307f2"), new Guid("28efd76e-2df0-4eff-8618-c31750451536"), 1, 12 },
                    { new Guid("1640f03c-a718-4a61-80f1-b92979814b4b"), new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 3, 16 },
                    { new Guid("20fc78bd-fa0e-4b7d-8aaf-1016b44672ce"), new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 4, 8 },
                    { new Guid("226acdbd-1743-4c44-8275-b816c8ee2b5b"), new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), 2, 6 },
                    { new Guid("24230b66-c6fa-4d7b-9d28-5eb6897928f6"), new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), 1, 10 },
                    { new Guid("4661f17b-4781-4f8e-a80f-8095b901b787"), new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), 5, 6 },
                    { new Guid("4cfac063-6c5f-4470-97a4-bd908278ef94"), new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 10, 20 },
                    { new Guid("58256543-ab3b-4ef5-8ce1-5fbd7e5b7206"), new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 8, 10 },
                    { new Guid("5d364e6e-cd1a-4625-9ee5-e6934adf934e"), new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 9, 18 },
                    { new Guid("65ec4b5c-c88d-424f-8f2c-ee9d95e39df6"), new Guid("28efd76e-2df0-4eff-8618-c31750451536"), 8, 12 },
                    { new Guid("7193fc9c-988f-400f-9cc3-06b26f2ac49d"), new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), 4, 11 },
                    { new Guid("7a38cf98-3183-4b79-8aa6-c19fd2661b4f"), new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 5, 5 },
                    { new Guid("94ce378e-8946-4613-a121-3f2af9815aae"), new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 6, 5 },
                    { new Guid("b41e8335-2786-4a92-9ad4-bc1af6275916"), new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), 10, 15 },
                    { new Guid("b6e2e780-f78d-4bfa-9d7f-d5811f770665"), new Guid("28efd76e-2df0-4eff-8618-c31750451536"), 9, 12 },
                    { new Guid("c033df3d-bc83-4be5-8992-2662af1b8520"), new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"), 3, 12 },
                    { new Guid("c1c00c28-e68d-4475-97af-7004f81f3b6e"), new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"), 7, 14 },
                    { new Guid("cbc73a05-9c04-48c4-bf94-1676ff93fd2e"), new Guid("28efd76e-2df0-4eff-8618-c31750451536"), 2, 15 },
                    { new Guid("dbc5458b-b3ca-48af-b917-cdde604250f9"), new Guid("28efd76e-2df0-4eff-8618-c31750451536"), 3, 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("054919e4-56b1-42c2-b6b8-87ba307a3151"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("0ae75959-96a8-4294-908a-eb277eec9567"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("15915bce-5ac2-4502-9ef4-95b60cd307f2"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("1640f03c-a718-4a61-80f1-b92979814b4b"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("20fc78bd-fa0e-4b7d-8aaf-1016b44672ce"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("226acdbd-1743-4c44-8275-b816c8ee2b5b"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("24230b66-c6fa-4d7b-9d28-5eb6897928f6"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("4661f17b-4781-4f8e-a80f-8095b901b787"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("4cfac063-6c5f-4470-97a4-bd908278ef94"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("58256543-ab3b-4ef5-8ce1-5fbd7e5b7206"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("5d364e6e-cd1a-4625-9ee5-e6934adf934e"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("65ec4b5c-c88d-424f-8f2c-ee9d95e39df6"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("7193fc9c-988f-400f-9cc3-06b26f2ac49d"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("7a38cf98-3183-4b79-8aa6-c19fd2661b4f"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("94ce378e-8946-4613-a121-3f2af9815aae"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("b41e8335-2786-4a92-9ad4-bc1af6275916"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("b6e2e780-f78d-4bfa-9d7f-d5811f770665"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("c033df3d-bc83-4be5-8992-2662af1b8520"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("c1c00c28-e68d-4475-97af-7004f81f3b6e"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("cbc73a05-9c04-48c4-bf94-1676ff93fd2e"));

            migrationBuilder.DeleteData(
                table: "ItensEstoque",
                keyColumn: "Id",
                keyValue: new Guid("dbc5458b-b3ca-48af-b917-cdde604250f9"));

            migrationBuilder.DeleteData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: new Guid("1ebb40fa-ea6e-444f-813d-d1251fd052bf"));

            migrationBuilder.DeleteData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: new Guid("28efd76e-2df0-4eff-8618-c31750451536"));

            migrationBuilder.DeleteData(
                table: "Estoque",
                keyColumn: "Id",
                keyValue: new Guid("7e740bdc-9054-4af1-aaf8-b3ed850b7fed"));
        }
    }
}
