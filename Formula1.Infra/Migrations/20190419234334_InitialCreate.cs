using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Formula1.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CorridaId = table.Column<int>(nullable: true),
                    PilotoId = table.Column<int>(nullable: true),
                    EquipeId = table.Column<int>(nullable: true),
                    PosicaoLargada = table.Column<int>(nullable: false),
                    PosicaoChegada = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false),
                    PontoExtra = table.Column<bool>(nullable: false),
                    DNF = table.Column<bool>(nullable: false),
                    MotivoDNF = table.Column<int>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "Corridas",
                columns: new[] { "Id", "Circuito", "DataHoraBrasil", "NomeGrandePremio", "Temporada" },
                values: new object[,]
                {
                    { 998, "Circuito de Albert Park", new DateTime(2019, 3, 17, 2, 10, 0, 0, DateTimeKind.Unspecified), "GP da Austrália", 2019 },
                    { 1018, "Circuito de Yas Marina", new DateTime(2019, 12, 1, 11, 10, 0, 0, DateTimeKind.Unspecified), "GP do Abu Dhabi", 2019 },
                    { 1017, "Autódromo José Carlos Pace", new DateTime(2019, 11, 17, 15, 10, 0, 0, DateTimeKind.Unspecified), "GP do Brasil", 2019 },
                    { 1016, "Circuito das Américas", new DateTime(2019, 11, 3, 17, 10, 0, 0, DateTimeKind.Unspecified), "GP dos Estados Unidos", 2019 },
                    { 1015, "Autódromo Hermanos Rodríguez", new DateTime(2019, 10, 27, 16, 10, 0, 0, DateTimeKind.Unspecified), "GP do México", 2019 },
                    { 1014, "Circuito de Suzuka", new DateTime(2019, 10, 13, 2, 10, 0, 0, DateTimeKind.Unspecified), "GP do Japão", 2019 },
                    { 1013, "Autódromo de Sóchi", new DateTime(2019, 9, 29, 8, 10, 0, 0, DateTimeKind.Unspecified), "GP da Rússia", 2019 },
                    { 1012, "Circuito Urbano de Marina Bay", new DateTime(2019, 9, 22, 9, 10, 0, 0, DateTimeKind.Unspecified), "GP de Singapura", 2019 },
                    { 1011, "Circuito de Monza", new DateTime(2019, 9, 8, 10, 10, 0, 0, DateTimeKind.Unspecified), "GP da Itália", 2019 },
                    { 1009, "Hungaroring", new DateTime(2019, 8, 4, 10, 10, 0, 0, DateTimeKind.Unspecified), "GP da Hungria", 2019 },
                    { 1010, "Spa-Francorchamps", new DateTime(2019, 9, 1, 10, 10, 0, 0, DateTimeKind.Unspecified), "GP da Bélgica", 2019 },
                    { 1007, "Silverstone", new DateTime(2019, 7, 14, 11, 10, 0, 0, DateTimeKind.Unspecified), "GP da Grã-Bretanha", 2019 },
                    { 1006, "Red Bull Ring", new DateTime(2019, 6, 30, 10, 10, 0, 0, DateTimeKind.Unspecified), "GP da Áustria", 2019 },
                    { 1005, "Circuito Paul Ricard", new DateTime(2019, 6, 23, 10, 10, 0, 0, DateTimeKind.Unspecified), "GP da França", 2019 },
                    { 1004, "Circuito Gilles Villeneuve", new DateTime(2019, 6, 9, 15, 10, 0, 0, DateTimeKind.Unspecified), "GP do Canadá", 2019 },
                    { 1003, "Circuito de Mônaco", new DateTime(2019, 5, 26, 10, 10, 0, 0, DateTimeKind.Unspecified), "GP de Mônaco", 2019 },
                    { 1002, "Circuito da Catalunha", new DateTime(2019, 5, 12, 10, 10, 0, 0, DateTimeKind.Unspecified), "GP da Espanha", 2019 },
                    { 1001, "Curcuito Urbano de Baku", new DateTime(2019, 4, 28, 9, 10, 0, 0, DateTimeKind.Unspecified), "GP do Azerbaijão", 2019 },
                    { 1000, "Circuito Internacional de Xangai", new DateTime(2019, 4, 14, 3, 10, 0, 0, DateTimeKind.Unspecified), "GP da China", 2019 },
                    { 999, "Circuito Internacional do Bahrein", new DateTime(2019, 3, 31, 12, 10, 0, 0, DateTimeKind.Unspecified), "GP do Bahrein", 2019 },
                    { 1008, "Hockenheimring", new DateTime(2019, 7, 28, 10, 10, 0, 0, DateTimeKind.Unspecified), "GP da Alemanha", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Equipes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 7, "McLaren" },
                    { 10, "Alfa Romeo" },
                    { 9, "Haas" },
                    { 8, "Racing Point" },
                    { 6, "Williams" },
                    { 5, "Renault" },
                    { 4, "Scuderia Toro Rosso" },
                    { 3, "RedBull Racing" },
                    { 2, "Ferrari" },
                    { 1, "Mercedes" }
                });

            migrationBuilder.InsertData(
                table: "Pilotos",
                columns: new[] { "Id", "Nome", "NomeGuerra", "NumeroCarro", "PaisOrigem", "Sigla" },
                values: new object[,]
                {
                    { 18, "Lance Stroll", "Stroll", 18, "Canadá", "STR" },
                    { 17, "Sergio Perez", "Perez", 11, "México", "PER" },
                    { 16, "Antonio Giovinazzi", "Giovinazzi", 99, "Itália", "GIO" },
                    { 15, "Kimi Räikkönen", "Räikkönen", 7, "Finlândia", "RAI" },
                    { 14, "Carlos Sainz Jr.", "Sainz", 55, "Espanha", "SAI" },
                    { 13, "Lando Norris", "Norris", 4, "Inglaterra", "NOR" },
                    { 12, "Alexander Albon", "Albon", 23, "?", "ALB" },
                    { 11, "Daniil Kvyat", "Kvyat", 26, "Rússia", "KVY" },
                    { 10, "Romain Grosjean", "Grosjean", 8, "França", "GRO" },
                    { 8, "Nico Hülkenberg", "Hülkenberg", 27, "Alemanha", "HUL" },
                    { 19, "Robert Kubica", "Kubica", 88, "Polônia", "KUB" },
                    { 7, "Daniel Riccardo", "Riccardo", 3, "Austrália", "RIC" },
                    { 6, "Pierre Gasly", "Gasly", 10, "França", "GAS" },
                    { 5, "Max Verstappen", "Verstappen", 33, "Holanda (talvez)", "VER" },
                    { 4, "Charles Leclerc", "Leclerc", 16, "Mônaco", "LEC" },
                    { 3, "Sebastian Vettel", "Vettel", 5, "Alemanha", "VET" },
                    { 2, "Valtteri Bottas", "Bottas", 77, "Finlândia", "BOT" },
                    { 1, "Lewis Hamilton", "Hamilton", 44, "Inglaterra", "HAM" },
                    { 9, "Kevin Magnussen", "Magnussen", 20, "Dinamarca", "MAG" },
                    { 20, "George Russell", "Russell", 63, "Inglaterra", "RUS" }
                });

            migrationBuilder.InsertData(
                table: "Resultados",
                columns: new[] { "Id", "CorridaId", "DNF", "EquipeId", "MotivoDNF", "PilotoId", "PontoExtra", "Pontos", "PosicaoChegada", "PosicaoLargada" },
                values: new object[,]
                {
                    { 2, 998, false, 1, null, 1, false, 18, 2, 1 },
                    { 59, 1000, true, 4, 4, 11, false, 0, 19, 11 },
                    { 14, 998, false, 4, null, 12, false, 0, 14, 13 },
                    { 29, 999, false, 4, null, 12, false, 2, 9, 12 },
                    { 50, 1000, false, 4, null, 12, false, 1, 10, 20 },
                    { 12, 998, false, 7, null, 13, false, 0, 12, 8 },
                    { 26, 999, false, 7, null, 13, false, 8, 6, 9 },
                    { 58, 1000, true, 7, 4, 13, false, 0, 18, 15 },
                    { 20, 998, true, 7, 3, 14, false, 0, 20, 18 },
                    { 39, 999, false, 7, null, 14, false, 0, 19, 7 },
                    { 54, 1000, false, 7, null, 14, false, 0, 14, 14 },
                    { 8, 998, false, 10, null, 15, false, 4, 8, 9 },
                    { 27, 999, false, 10, null, 15, false, 6, 7, 8 },
                    { 32, 999, false, 4, null, 11, false, 0, 12, 15 },
                    { 49, 1000, false, 10, null, 15, false, 2, 9, 13 },
                    { 31, 999, false, 10, null, 16, false, 0, 11, 16 },
                    { 55, 1000, false, 10, null, 16, false, 0, 15, 19 },
                    { 13, 998, false, 8, null, 17, false, 0, 13, 10 },
                    { 30, 999, false, 8, null, 17, false, 1, 10, 14 },
                    { 48, 1000, false, 8, null, 17, false, 4, 8, 12 },
                    { 9, 998, false, 8, null, 18, false, 2, 9, 16 },
                    { 34, 999, false, 8, null, 18, false, 0, 14, 18 },
                    { 52, 1000, false, 8, null, 18, false, 0, 12, 16 },
                    { 17, 998, false, 6, null, 19, false, 0, 17, 20 },
                    { 36, 999, false, 6, null, 19, false, 0, 16, 20 },
                    { 57, 1000, false, 6, null, 19, false, 0, 17, 18 },
                    { 16, 998, false, 6, null, 20, false, 0, 16, 19 },
                    { 15, 998, false, 10, null, 16, false, 0, 15, 14 },
                    { 10, 998, false, 4, null, 11, false, 1, 10, 15 },
                    { 51, 1000, false, 9, null, 10, false, 0, 11, 10 },
                    { 40, 999, true, 9, 4, 10, false, 0, 20, 11 },
                    { 21, 999, false, 1, null, 1, false, 25, 1, 3 },
                    { 41, 1000, false, 1, null, 1, false, 25, 1, 2 },
                    { 1, 998, false, 1, null, 2, true, 26, 1, 2 },
                    { 22, 999, false, 1, null, 2, false, 18, 2, 4 },
                    { 42, 1000, false, 1, null, 2, false, 18, 2, 1 },
                    { 4, 998, false, 2, null, 3, false, 12, 4, 3 },
                    { 25, 999, false, 2, null, 3, false, 10, 5, 2 },
                    { 43, 1000, false, 2, null, 3, false, 15, 3, 3 },
                    { 5, 998, false, 2, null, 4, false, 10, 5, 5 },
                    { 23, 999, false, 2, null, 4, true, 16, 3, 1 },
                    { 45, 1000, false, 2, null, 4, false, 10, 5, 4 },
                    { 3, 998, false, 3, null, 5, false, 15, 3, 4 },
                    { 24, 999, false, 3, null, 5, false, 12, 4, 5 },
                    { 44, 1000, false, 3, null, 5, false, 12, 4, 5 },
                    { 11, 998, false, 3, null, 6, false, 0, 11, 17 },
                    { 28, 999, false, 3, null, 6, false, 4, 8, 13 },
                    { 46, 1000, false, 3, null, 6, true, 9, 6, 6 },
                    { 19, 998, true, 5, 2, 7, false, 0, 19, 12 },
                    { 38, 999, false, 5, null, 7, false, 0, 18, 10 },
                    { 47, 1000, false, 5, null, 7, false, 6, 7, 7 },
                    { 7, 998, false, 5, null, 8, false, 6, 7, 11 },
                    { 37, 999, false, 5, null, 8, false, 0, 17, 17 },
                    { 60, 1000, true, 5, 3, 8, false, 0, 20, 8 },
                    { 6, 998, false, 9, null, 9, false, 8, 6, 7 },
                    { 33, 999, false, 9, null, 9, false, 0, 13, 6 },
                    { 53, 1000, false, 9, null, 9, false, 0, 13, 9 },
                    { 18, 998, true, 9, 1, 10, false, 0, 18, 6 },
                    { 35, 999, false, 6, null, 20, false, 0, 15, 19 },
                    { 56, 1000, false, 6, null, 20, false, 0, 16, 17 }
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
