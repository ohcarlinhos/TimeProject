using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalLinkToTimeRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "245a1ba3-9794-4d4b-91c9-16ad1ec322ac");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "51102149-65db-406f-bff9-5ac907b70616");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "67d574ee-151f-4d42-9661-95ee13525ad3");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "ac6b615c-b6c5-4596-86c8-ed31a32f4968");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "c96f3682-c6a5-4238-b9b3-cf5e68359b1a");

            migrationBuilder.AddColumn<string>(
                name: "ExternalLink",
                table: "time_records",
                type: "character varying(120)",
                maxLength: 120,
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "07577660-b921-4e07-bb68-990e8f286475");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "209a8b3f-9a5c-4019-b673-846c1b3d92f0");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "2b9134e6-4a21-417a-a08c-8600d05247fe");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "6daea389-c618-4f44-8958-d423952a4941");

            migrationBuilder.DeleteData(
                table: "register_code",
                keyColumn: "Id",
                keyValue: "d62a3d33-18c9-4ab3-85ec-c8f22187f078");

            migrationBuilder.DropColumn(
                name: "ExternalLink",
                table: "time_records");

            migrationBuilder.InsertData(
                table: "register_code",
                columns: new[] { "Id", "IsUsed", "UserId" },
                values: new object[,]
                {
                    { "245a1ba3-9794-4d4b-91c9-16ad1ec322ac", false, null },
                    { "51102149-65db-406f-bff9-5ac907b70616", false, null },
                    { "67d574ee-151f-4d42-9661-95ee13525ad3", false, null },
                    { "ac6b615c-b6c5-4596-86c8-ed31a32f4968", false, null },
                    { "c96f3682-c6a5-4238-b9b3-cf5e68359b1a", false, null }
                });
        }
    }
}
