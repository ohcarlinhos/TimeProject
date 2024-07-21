using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeyToIdRegisterCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "register_code",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "register_code",
                columns: new[] { "Id", "IsUsed", "UserId" },
                values: new object[,]
                {
                    { "09d1ea29-d600-4db3-bf36-f9711021f451", false, null },
                    { "0a3316e4-5cf4-45c6-8b9d-fc916c538b91", false, null },
                    { "10b67dbb-5974-430a-9b35-8550454df09f", false, null },
                    { "45f18760-4a4f-499f-9aa0-daa190c110c0", false, null },
                    { "7254f040-8660-446e-ba7a-28626408d016", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "09d1ea29-d600-4db3-bf36-f9711021f451");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "0a3316e4-5cf4-45c6-8b9d-fc916c538b91");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "10b67dbb-5974-430a-9b35-8550454df09f");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "45f18760-4a4f-499f-9aa0-daa190c110c0");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "7254f040-8660-446e-ba7a-28626408d016");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "register_code",
                newName: "Key");

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
    }
}
