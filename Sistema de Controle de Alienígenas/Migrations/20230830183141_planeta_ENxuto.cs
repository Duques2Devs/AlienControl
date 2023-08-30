using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Controle_de_Alienígenas.Migrations
{
    /// <inheritdoc />
    public partial class planeta_ENxuto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aliens_Planetas_PlanetaModelId",
                table: "Aliens");

            migrationBuilder.DropIndex(
                name: "IX_Aliens_PlanetaModelId",
                table: "Aliens");

            migrationBuilder.DropColumn(
                name: "Populacao",
                table: "Planetas");

            migrationBuilder.DropColumn(
                name: "PlanetaModelId",
                table: "Aliens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Populacao",
                table: "Planetas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetaModelId",
                table: "Aliens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aliens_PlanetaModelId",
                table: "Aliens",
                column: "PlanetaModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aliens_Planetas_PlanetaModelId",
                table: "Aliens",
                column: "PlanetaModelId",
                principalTable: "Planetas",
                principalColumn: "Id");
        }
    }
}
