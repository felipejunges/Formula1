using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Temporada = table.Column<int>(nullable: false),
                    NomeGrandePremio = table.Column<string>(nullable: true),
                    Circuito = table.Column<string>(nullable: true),
                    DataHoraBrasil = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    CorRgb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pilotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    NomeGuerra = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true),
                    NumeroCarro = table.Column<int>(nullable: false),
                    PaisOrigem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilotos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipesTemporada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipeId = table.Column<int>(nullable: true),
                    Temporada = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false),
                    Posicao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipesTemporada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipesTemporada_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotoId = table.Column<int>(nullable: true),
                    EquipeId = table.Column<int>(nullable: true),
                    Temporada = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contratos_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PilotosTemporada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PilotoId = table.Column<int>(nullable: true),
                    Temporada = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false),
                    Posicao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PilotosTemporada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PilotosTemporada_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CorridaId = table.Column<int>(nullable: false),
                    PilotoId = table.Column<int>(nullable: false),
                    EquipeId = table.Column<int>(nullable: false),
                    PosicaoLargada = table.Column<int>(nullable: false),
                    PosicaoChegada = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false),
                    PontoExtra = table.Column<bool>(nullable: false),
                    DNF = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_Corridas_CorridaId",
                        column: x => x.CorridaId,
                        principalTable: "Corridas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resultados_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resultados_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_EquipeId",
                table: "Contratos",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_PilotoId",
                table: "Contratos",
                column: "PilotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_Temporada",
                table: "Contratos",
                column: "Temporada");

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_Temporada",
                table: "Corridas",
                column: "Temporada");

            migrationBuilder.CreateIndex(
                name: "IX_EquipesTemporada_EquipeId",
                table: "EquipesTemporada",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_PilotosTemporada_PilotoId",
                table: "PilotosTemporada",
                column: "PilotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_CorridaId",
                table: "Resultados",
                column: "CorridaId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_EquipeId",
                table: "Resultados",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_PilotoId",
                table: "Resultados",
                column: "PilotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "EquipesTemporada");

            migrationBuilder.DropTable(
                name: "PilotosTemporada");

            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Pilotos");
        }
    }
}
