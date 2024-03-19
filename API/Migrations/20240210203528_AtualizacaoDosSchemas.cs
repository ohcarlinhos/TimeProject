using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDosSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Usuarios_UsuarioId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_EventosDeFoco_TemposFocado_TempoFocadoId",
                table: "EventosDeFoco");

            migrationBuilder.DropForeignKey(
                name: "FK_EventosDeFoco_Usuarios_UsuarioId",
                table: "EventosDeFoco");

            migrationBuilder.DropForeignKey(
                name: "FK_TemposFocado_Categorias_CategoriaId",
                table: "TemposFocado");

            migrationBuilder.DropForeignKey(
                name: "FK_TemposFocado_Usuarios_UsuarioId",
                table: "TemposFocado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemposFocado",
                table: "TemposFocado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventosDeFoco",
                table: "EventosDeFoco");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "categorias");

            migrationBuilder.RenameTable(
                name: "TemposFocado",
                newName: "tempos_focado");

            migrationBuilder.RenameTable(
                name: "EventosDeFoco",
                newName: "eventos_de_foco");

            migrationBuilder.RenameIndex(
                name: "IX_Categorias_UsuarioId",
                table: "categorias",
                newName: "IX_categorias_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_TemposFocado_UsuarioId",
                table: "tempos_focado",
                newName: "IX_tempos_focado_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_TemposFocado_CategoriaId",
                table: "tempos_focado",
                newName: "IX_tempos_focado_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_EventosDeFoco_UsuarioId",
                table: "eventos_de_foco",
                newName: "IX_eventos_de_foco_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_EventosDeFoco_TempoFocadoId",
                table: "eventos_de_foco",
                newName: "IX_eventos_de_foco_TempoFocadoId");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "usuarios",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "tempos_focado",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categorias",
                table: "categorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tempos_focado",
                table: "tempos_focado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_eventos_de_foco",
                table: "eventos_de_foco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categorias_usuarios_UsuarioId",
                table: "categorias",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eventos_de_foco_tempos_focado_TempoFocadoId",
                table: "eventos_de_foco",
                column: "TempoFocadoId",
                principalTable: "tempos_focado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_eventos_de_foco_usuarios_UsuarioId",
                table: "eventos_de_foco",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tempos_focado_categorias_CategoriaId",
                table: "tempos_focado",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tempos_focado_usuarios_UsuarioId",
                table: "tempos_focado",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorias_usuarios_UsuarioId",
                table: "categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_eventos_de_foco_tempos_focado_TempoFocadoId",
                table: "eventos_de_foco");

            migrationBuilder.DropForeignKey(
                name: "FK_eventos_de_foco_usuarios_UsuarioId",
                table: "eventos_de_foco");

            migrationBuilder.DropForeignKey(
                name: "FK_tempos_focado_categorias_CategoriaId",
                table: "tempos_focado");

            migrationBuilder.DropForeignKey(
                name: "FK_tempos_focado_usuarios_UsuarioId",
                table: "tempos_focado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categorias",
                table: "categorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tempos_focado",
                table: "tempos_focado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_eventos_de_foco",
                table: "eventos_de_foco");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "categorias",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "tempos_focado",
                newName: "TemposFocado");

            migrationBuilder.RenameTable(
                name: "eventos_de_foco",
                newName: "EventosDeFoco");

            migrationBuilder.RenameIndex(
                name: "IX_categorias_UsuarioId",
                table: "Categorias",
                newName: "IX_Categorias_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_tempos_focado_UsuarioId",
                table: "TemposFocado",
                newName: "IX_TemposFocado_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_tempos_focado_CategoriaId",
                table: "TemposFocado",
                newName: "IX_TemposFocado_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_eventos_de_foco_UsuarioId",
                table: "EventosDeFoco",
                newName: "IX_EventosDeFoco_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_eventos_de_foco_TempoFocadoId",
                table: "EventosDeFoco",
                newName: "IX_EventosDeFoco_TempoFocadoId");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "TemposFocado",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldMaxLength: 120);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemposFocado",
                table: "TemposFocado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventosDeFoco",
                table: "EventosDeFoco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Usuarios_UsuarioId",
                table: "Categorias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventosDeFoco_TemposFocado_TempoFocadoId",
                table: "EventosDeFoco",
                column: "TempoFocadoId",
                principalTable: "TemposFocado",
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
    }
}
