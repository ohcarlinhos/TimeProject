using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ModificacaoDeNomeclatura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_periodos_de_tempo_registros_de_tempo_RegistroDeTempoId",
                table: "periodos_de_tempo");

            migrationBuilder.RenameColumn(
                name: "RegistroDeTempoId",
                table: "periodos_de_tempo",
                newName: "RegistroId");

            migrationBuilder.RenameIndex(
                name: "IX_periodos_de_tempo_RegistroDeTempoId",
                table: "periodos_de_tempo",
                newName: "IX_periodos_de_tempo_RegistroId");

            migrationBuilder.AddForeignKey(
                name: "FK_periodos_de_tempo_registros_de_tempo_RegistroId",
                table: "periodos_de_tempo",
                column: "RegistroId",
                principalTable: "registros_de_tempo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_periodos_de_tempo_registros_de_tempo_RegistroId",
                table: "periodos_de_tempo");

            migrationBuilder.RenameColumn(
                name: "RegistroId",
                table: "periodos_de_tempo",
                newName: "RegistroDeTempoId");

            migrationBuilder.RenameIndex(
                name: "IX_periodos_de_tempo_RegistroId",
                table: "periodos_de_tempo",
                newName: "IX_periodos_de_tempo_RegistroDeTempoId");

            migrationBuilder.AddForeignKey(
                name: "FK_periodos_de_tempo_registros_de_tempo_RegistroDeTempoId",
                table: "periodos_de_tempo",
                column: "RegistroDeTempoId",
                principalTable: "registros_de_tempo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
