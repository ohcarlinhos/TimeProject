using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_users_UserId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_time_periods_users_UserId",
                table: "time_periods");

            migrationBuilder.DropForeignKey(
                name: "FK_time_records_users_UserId",
                table: "time_records");

            migrationBuilder.DropIndex(
                name: "IX_time_records_UserId",
                table: "time_records");

            migrationBuilder.DropIndex(
                name: "IX_time_periods_UserId",
                table: "time_periods");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserId",
                table: "categories");

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_time_records_UserId",
                table: "time_records",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_time_periods_UserId",
                table: "time_periods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_UserId",
                table: "categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_users_UserId",
                table: "categories",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_time_periods_users_UserId",
                table: "time_periods",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_time_records_users_UserId",
                table: "time_records",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
