using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeProject.Api.Migrations
{
    /// <inheritdoc />
    public partial class RemovePassowordColoumnFromUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "users",
                type: "character varying(72)",
                maxLength: 72,
                nullable: true);
        }
    }
}
