using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class CreateTablePunicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Punicoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CorridaId = table.Column<int>(nullable: false),
                    PilotoId = table.Column<int>(nullable: true),
                    EquipeId = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    Pontos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Punicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Punicoes_Corridas_CorridaId",
                        column: x => x.CorridaId,
                        principalTable: "Corridas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Punicoes_CorridaId",
                table: "Punicoes",
                column: "CorridaId");

            migrationBuilder.CreateIndex(
                name: "IX_Punicoes_EquipeId",
                table: "Punicoes",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Punicoes_PilotoId",
                table: "Punicoes",
                column: "PilotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Punicoes");
        }
    }
}
