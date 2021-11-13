using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class CorridaSeparadoPontos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PontoExtra",
                table: "Resultados",
                newName: "VoltaMaisRapida");

            migrationBuilder.RenameColumn(
                name: "Pontos",
                table: "Resultados",
                newName: "PontosCorrida");

            migrationBuilder.AddColumn<double>(
                name: "PontosClassificacao",
                table: "Resultados",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PontosClassificacao",
                table: "Resultados");

            migrationBuilder.RenameColumn(
                name: "VoltaMaisRapida",
                table: "Resultados",
                newName: "PontoExtra");

            migrationBuilder.RenameColumn(
                name: "PontosCorrida",
                table: "Resultados",
                newName: "Pontos");
        }
    }
}
