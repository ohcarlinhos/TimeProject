using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeProject.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddWasSentToConfirmCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WasSent",
                table: "confirm_codes",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WasSent",
                table: "confirm_codes");
        }
    }
}
