using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ModificacaoParaPeriodosDeTempo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registros_de_tempo_categorias_CategoriaId",
                table: "registros_de_tempo");

            migrationBuilder.DropTable(
                name: "eventos_dos_registros");

            migrationBuilder.RenameColumn(
                name: "DataDeRegistro",
                table: "registros_de_tempo",
                newName: "DataDoRegistro");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "registros_de_tempo",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "periodos_de_tempo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    RegistroDeTempoId = table.Column<int>(type: "integer", nullable: false),
                    Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Posicao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodos_de_tempo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_periodos_de_tempo_registros_de_tempo_RegistroDeTempoId",
                        column: x => x.RegistroDeTempoId,
                        principalTable: "registros_de_tempo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_periodos_de_tempo_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_periodos_de_tempo_RegistroDeTempoId",
                table: "periodos_de_tempo",
                column: "RegistroDeTempoId");

            migrationBuilder.CreateIndex(
                name: "IX_periodos_de_tempo_UsuarioId",
                table: "periodos_de_tempo",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_registros_de_tempo_categorias_CategoriaId",
                table: "registros_de_tempo",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registros_de_tempo_categorias_CategoriaId",
                table: "registros_de_tempo");

            migrationBuilder.DropTable(
                name: "periodos_de_tempo");

            migrationBuilder.RenameColumn(
                name: "DataDoRegistro",
                table: "registros_de_tempo",
                newName: "DataDeRegistro");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "registros_de_tempo",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "eventos_dos_registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    DataDeRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Posicao = table.Column<int>(type: "integer", nullable: false),
                    RegistroDeTempoModelId = table.Column<int>(type: "integer", nullable: true),
                    TempoFocadoId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos_dos_registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventos_dos_registros_registros_de_tempo_RegistroDeTempoMod~",
                        column: x => x.RegistroDeTempoModelId,
                        principalTable: "registros_de_tempo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_eventos_dos_registros_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventos_dos_registros_RegistroDeTempoModelId",
                table: "eventos_dos_registros",
                column: "RegistroDeTempoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_eventos_dos_registros_UsuarioId",
                table: "eventos_dos_registros",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_registros_de_tempo_categorias_CategoriaId",
                table: "registros_de_tempo",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
