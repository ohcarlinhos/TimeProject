using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRegisterCodesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "register_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "register_code",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_register_code", x => x.Id);
                    table.ForeignKey(
                        name: "FK_register_code_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "register_code",
                columns: new[] { "Id", "IsUsed", "UserId" },
                values: new object[,]
                {
                    { "07577660-b921-4e07-bb68-990e8f286475", false, null },
                    { "209a8b3f-9a5c-4019-b673-846c1b3d92f0", false, null },
                    { "2b9134e6-4a21-417a-a08c-8600d05247fe", false, null },
                    { "6daea389-c618-4f44-8958-d423952a4941", false, null },
                    { "d62a3d33-18c9-4ab3-85ec-c8f22187f078", false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_register_code_UserId",
                table: "register_code",
                column: "UserId",
                unique: true);
        }
    }
}
