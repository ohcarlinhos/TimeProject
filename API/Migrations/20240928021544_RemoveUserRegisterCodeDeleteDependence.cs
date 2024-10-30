using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserRegisterCodeDeleteDependence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_register_code_users_UserId",
                table: "register_code");

            migrationBuilder.AddForeignKey(
                name: "FK_register_code_users_UserId",
                table: "register_code",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_register_code_users_UserId",
                table: "register_code");

            migrationBuilder.AddForeignKey(
                name: "FK_register_code_users_UserId",
                table: "register_code",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
