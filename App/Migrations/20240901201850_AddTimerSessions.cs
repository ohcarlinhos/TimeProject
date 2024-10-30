using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class AddTimerSessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimePeriodDate",
                table: "time_record_metas",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstTimePeriodDate",
                table: "time_record_metas",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "TimerSessionId",
                table: "time_periods",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "timer_sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    TimeRecordId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    From = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timer_sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_timer_sessions_time_records_TimeRecordId",
                        column: x => x.TimeRecordId,
                        principalTable: "time_records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_timer_sessions_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_time_periods_TimerSessionId",
                table: "time_periods",
                column: "TimerSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_timer_sessions_TimeRecordId",
                table: "timer_sessions",
                column: "TimeRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_timer_sessions_UserId",
                table: "timer_sessions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_time_periods_timer_sessions_TimerSessionId",
                table: "time_periods",
                column: "TimerSessionId",
                principalTable: "timer_sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_time_periods_timer_sessions_TimerSessionId",
                table: "time_periods");

            migrationBuilder.DropTable(
                name: "timer_sessions");

            migrationBuilder.DropIndex(
                name: "IX_time_periods_TimerSessionId",
                table: "time_periods");

            migrationBuilder.DropColumn(
                name: "TimerSessionId",
                table: "time_periods");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastTimePeriodDate",
                table: "time_record_metas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FirstTimePeriodDate",
                table: "time_record_metas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
