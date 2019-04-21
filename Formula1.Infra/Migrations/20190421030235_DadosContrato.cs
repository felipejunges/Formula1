using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class DadosContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contratos",
                columns: new[] { "Id", "EquipeId", "PilotoId", "Temporada" },
                values: new object[,]
                {
                    { 1, 1, 1, 2019 },
                    { 18, 9, 10, 2019 },
                    { 17, 9, 9, 2019 },
                    { 16, 7, 14, 2019 },
                    { 15, 7, 13, 2019 },
                    { 14, 4, 12, 2019 },
                    { 13, 4, 11, 2019 },
                    { 12, 10, 16, 2019 },
                    { 11, 10, 15, 2019 },
                    { 10, 8, 18, 2019 },
                    { 9, 8, 17, 2019 },
                    { 8, 5, 7, 2019 },
                    { 7, 5, 8, 2019 },
                    { 6, 3, 6, 2019 },
                    { 5, 3, 5, 2019 },
                    { 4, 2, 4, 2019 },
                    { 3, 2, 3, 2019 },
                    { 2, 1, 2, 2019 },
                    { 19, 6, 20, 2019 },
                    { 20, 6, 19, 2019 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Contratos",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
