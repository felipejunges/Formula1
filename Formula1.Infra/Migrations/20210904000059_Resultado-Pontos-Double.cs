using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class ResultadoPontosDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Pontos",
                table: "Resultados",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Pontos",
                table: "PilotosTemporada",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Pontos",
                table: "EquipesTemporada",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pontos",
                table: "Resultados",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Pontos",
                table: "PilotosTemporada",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Pontos",
                table: "EquipesTemporada",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
