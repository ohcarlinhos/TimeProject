using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeRecordMetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "time_records",
                type: "character varying(36)",
                maxLength: 36,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(36)",
                oldMaxLength: 36,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "time_record_metas",
                columns: table => new
                {
                    TimeRecordId = table.Column<int>(type: "integer", nullable: false),
                    FormattedTime = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: false),
                    TimePeriodCount = table.Column<int>(type: "integer", nullable: false),
                    FirstTimePeriodDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastTimePeriodDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_time_record_metas", x => x.TimeRecordId);
                    table.ForeignKey(
                        name: "FK_time_record_metas_time_records_TimeRecordId",
                        column: x => x.TimeRecordId,
                        principalTable: "time_records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "time_record_metas");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "time_records",
                type: "character varying(36)",
                maxLength: 36,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(36)",
                oldMaxLength: 36);
        }
    }
}
