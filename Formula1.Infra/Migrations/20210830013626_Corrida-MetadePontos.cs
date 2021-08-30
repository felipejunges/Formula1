using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class CorridaMetadePontos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Pontos",
                table: "Resultados",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pontos",
                table: "PilotosTemporada",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pontos",
                table: "EquipesTemporada",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<bool>(
                name: "MetadePontos",
                table: "Corridas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetadePontos",
                table: "Corridas");

            migrationBuilder.AlterColumn<int>(
                name: "Pontos",
                table: "Resultados",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Pontos",
                table: "PilotosTemporada",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Pontos",
                table: "EquipesTemporada",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
