using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class ResultadoDSQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DSQ",
                table: "Resultados",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Corridas",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroCorrida",
                table: "Corridas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DSQ",
                table: "Resultados");

            migrationBuilder.DropColumn(
                name: "NumeroCorrida",
                table: "Corridas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Corridas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
