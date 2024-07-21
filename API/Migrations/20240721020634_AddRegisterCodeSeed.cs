using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddRegisterCodeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "register_code",
                columns: new[] { "Key", "IsUsed", "UserId" },
                values: new object[,]
                {
                    { "1463a5d2-63ee-469a-8481-05deecca3f53", false, null },
                    { "476841d4-d228-4ef8-b248-0ff45826791f", false, null },
                    { "d67441c3-c377-4350-ad3d-8bb6acf4f882", false, null },
                    { "f5071b43-4689-4ea7-841f-5f5b053532d9", false, null },
                    { "f7489c8e-a0df-4d65-a739-03f9b7d92c74", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Key",
                keyValue: "1463a5d2-63ee-469a-8481-05deecca3f53");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Key",
                keyValue: "476841d4-d228-4ef8-b248-0ff45826791f");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Key",
                keyValue: "d67441c3-c377-4350-ad3d-8bb6acf4f882");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Key",
                keyValue: "f5071b43-4689-4ea7-841f-5f5b053532d9");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Key",
                keyValue: "f7489c8e-a0df-4d65-a739-03f9b7d92c74");
        }
    }
}
