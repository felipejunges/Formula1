using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class RemoveTabelaPunicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Punicoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Punicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    EquipeId = table.Column<int>(type: "INTEGER", nullable: true),
                    PilotoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Pontos = table.Column<int>(type: "INTEGER", nullable: false),
                    Temporada = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punicoes_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Punicoes_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Punicoes_EquipeId",
                table: "Punicoes",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Punicoes_PilotoId",
                table: "Punicoes",
                column: "PilotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Punicoes_Temporada",
                table: "Punicoes",
                column: "Temporada");
        }
    }
}
