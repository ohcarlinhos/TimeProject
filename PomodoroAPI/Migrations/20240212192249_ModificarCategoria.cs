using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PomodoroAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModificarCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos_de_foco");

            migrationBuilder.DropTable(
                name: "tempos_focado");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "categorias",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 120);

            migrationBuilder.CreateTable(
                name: "registros_de_tempo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    DataDeRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registros_de_tempo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_registros_de_tempo_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_registros_de_tempo_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eventos_dos_registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    TempoFocadoId = table.Column<int>(type: "integer", nullable: false),
                    DataDeRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Posicao = table.Column<int>(type: "integer", nullable: false),
                    RegistroDeTempoModelId = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_registros_de_tempo_CategoriaId",
                table: "registros_de_tempo",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_registros_de_tempo_UsuarioId",
                table: "registros_de_tempo",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos_dos_registros");

            migrationBuilder.DropTable(
                name: "registros_de_tempo");

            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "categorias",
                type: "integer",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(120)",
                oldMaxLength: 120);

            migrationBuilder.CreateTable(
                name: "tempos_focado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    DataDeRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tempos_focado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tempos_focado_categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tempos_focado_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eventos_de_foco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    DataDeRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Posicao = table.Column<int>(type: "integer", nullable: false),
                    TempoFocadoId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos_de_foco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventos_de_foco_tempos_focado_TempoFocadoId",
                        column: x => x.TempoFocadoId,
                        principalTable: "tempos_focado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_eventos_de_foco_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventos_de_foco_TempoFocadoId",
                table: "eventos_de_foco",
                column: "TempoFocadoId");

            migrationBuilder.CreateIndex(
                name: "IX_eventos_de_foco_UsuarioId",
                table: "eventos_de_foco",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tempos_focado_CategoriaId",
                table: "tempos_focado",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_tempos_focado_UsuarioId",
                table: "tempos_focado",
                column: "UsuarioId");
        }
    }
}
