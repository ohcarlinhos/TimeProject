using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PomodoroAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TemposFocado_CategoriaId",
                table: "TemposFocado",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TemposFocado_UsuarioId",
                table: "TemposFocado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EventosDeFoco_UsuarioId",
                table: "EventosDeFoco",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_UsuarioId",
                table: "Categorias",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_UsuarioId",
                table: "Categorias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventosDeFoco_Usuarios_UsuarioId",
                table: "EventosDeFoco",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemposFocado_Categorias_CategoriaId",
                table: "TemposFocado",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemposFocado_Usuarios_UsuarioId",
                table: "TemposFocado",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Usuarios_UsuarioId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_EventosDeFoco_Usuarios_UsuarioId",
                table: "EventosDeFoco");

            migrationBuilder.DropForeignKey(
                name: "FK_TemposFocado_Categorias_CategoriaId",
                table: "TemposFocado");

            migrationBuilder.DropForeignKey(
                name: "FK_TemposFocado_Usuarios_UsuarioId",
                table: "TemposFocado");

            migrationBuilder.DropIndex(
                name: "IX_TemposFocado_CategoriaId",
                table: "TemposFocado");

            migrationBuilder.DropIndex(
                name: "IX_TemposFocado_UsuarioId",
                table: "TemposFocado");

            migrationBuilder.DropIndex(
                name: "IX_EventosDeFoco_UsuarioId",
                table: "EventosDeFoco");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_UsuarioId",
                table: "Categorias");
        }
    }
}
