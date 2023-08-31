using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Controle_de_Alienígenas.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Populacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poderes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poderes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aliens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Corpo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetaID = table.Column<int>(type: "int", nullable: false),
                    EstaNaTerra = table.Column<bool>(type: "bit", nullable: false),
                    PlanetaModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aliens_Planetas_PlanetaID",
                        column: x => x.PlanetaID,
                        principalTable: "Planetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aliens_Planetas_PlanetaModelId",
                        column: x => x.PlanetaModelId,
                        principalTable: "Planetas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlienPoder",
                columns: table => new
                {
                    AlienId = table.Column<int>(type: "int", nullable: false),
                    PoderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlienPoder", x => new { x.AlienId, x.PoderId });
                    table.ForeignKey(
                        name: "FK_AlienPoder_Aliens_AlienId",
                        column: x => x.AlienId,
                        principalTable: "Aliens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlienPoder_Poderes_PoderId",
                        column: x => x.PoderId,
                        principalTable: "Poderes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlienId = table.Column<int>(type: "int", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlienModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Aliens_AlienId",
                        column: x => x.AlienId,
                        principalTable: "Aliens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Aliens_AlienModelId",
                        column: x => x.AlienModelId,
                        principalTable: "Aliens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlienPoder_PoderId",
                table: "AlienPoder",
                column: "PoderId");

            migrationBuilder.CreateIndex(
                name: "IX_Aliens_PlanetaID",
                table: "Aliens",
                column: "PlanetaID");

            migrationBuilder.CreateIndex(
                name: "IX_Aliens_PlanetaModelId",
                table: "Aliens",
                column: "PlanetaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_AlienId",
                table: "Registros",
                column: "AlienId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_AlienModelId",
                table: "Registros",
                column: "AlienModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlienPoder");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Poderes");

            migrationBuilder.DropTable(
                name: "Aliens");

            migrationBuilder.DropTable(
                name: "Planetas");
        }
    }
}
