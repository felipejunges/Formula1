using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class TemporadaResultadoPosicaoMaximaPersistida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PosicaoMaxima",
                table: "PilotosTemporada",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosicaoMaxima",
                table: "EquipesTemporada",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PosicaoMaxima",
                table: "PilotosTemporada");

            migrationBuilder.DropColumn(
                name: "PosicaoMaxima",
                table: "EquipesTemporada");
        }
    }
}
