using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeProject.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeRecordMetaTimeOnSeconds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TimeOnSeconds",
                table: "time_record_metas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeOnSeconds",
                table: "time_record_metas");
        }
    }
}
