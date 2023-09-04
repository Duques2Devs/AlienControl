using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_de_Controle_de_Alienígenas.Migrations
{
    /// <inheritdoc />
    public partial class alienregistrotest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Aliens_AlienModelId",
                table: "Registros");

            migrationBuilder.DropIndex(
                name: "IX_Registros_AlienModelId",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "AlienModelId",
                table: "Registros");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlienModelId",
                table: "Registros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registros_AlienModelId",
                table: "Registros",
                column: "AlienModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Aliens_AlienModelId",
                table: "Registros",
                column: "AlienModelId",
                principalTable: "Aliens",
                principalColumn: "Id");
        }
    }
}
