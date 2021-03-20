using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class FlagAtivoPilotoEquipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Pilotos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Equipes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PilotoId",
                table: "Contratos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "Contratos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.Sql("UPDATE Pilotos SET Ativo = 1");
            migrationBuilder.Sql("UPDATE Equipes SET Ativo = 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Pilotos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Equipes");

            migrationBuilder.AlterColumn<int>(
                name: "PilotoId",
                table: "Contratos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "Contratos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
