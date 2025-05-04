using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class RemovePeriodReferencesFromTRMetaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimePeriodCount",
                table: "time_record_metas",
                newName: "TimeCount");

            migrationBuilder.RenameColumn(
                name: "LastTimePeriodDate",
                table: "time_record_metas",
                newName: "LastTimeDate");

            migrationBuilder.RenameColumn(
                name: "FirstTimePeriodDate",
                table: "time_record_metas",
                newName: "FirstTimeDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeCount",
                table: "time_record_metas",
                newName: "TimePeriodCount");

            migrationBuilder.RenameColumn(
                name: "LastTimeDate",
                table: "time_record_metas",
                newName: "LastTimePeriodDate");

            migrationBuilder.RenameColumn(
                name: "FirstTimeDate",
                table: "time_record_metas",
                newName: "FirstTimePeriodDate");
        }
    }
}
