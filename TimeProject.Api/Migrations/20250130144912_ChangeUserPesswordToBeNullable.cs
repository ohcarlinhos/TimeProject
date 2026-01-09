using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeProject.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserPesswordToBeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "character varying(72)",
                maxLength: 72,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(72)",
                oldMaxLength: 72);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "character varying(72)",
                maxLength: 72,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(72)",
                oldMaxLength: 72,
                oldNullable: true);
        }
    }
}
