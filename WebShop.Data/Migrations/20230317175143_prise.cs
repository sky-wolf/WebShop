using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Data.Migrations
{
    public partial class prise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f753242-571c-4917-a60c-d3bec5150c13");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "af568145-94b6-4ebb-96ce-de038b49671c", "6507f661-7be6-4fbe-bb85-2f8c0ee51c09" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af568145-94b6-4ebb-96ce-de038b49671c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6507f661-7be6-4fbe-bb85-2f8c0ee51c09");

            migrationBuilder.AddColumn<int>(
                name: "Prise",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54a9e2fa-d22b-45a6-a227-e872a70a68d8", "6e180625-ca4a-46b9-855b-1c80ac1fcd97", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90d0cd0d-1b76-4ce6-a881-2290e64804f7", "dbad3b29-798b-4a65-bdbe-8670e7bf58cf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b82fb2a7-ac59-4777-b47a-43b8a6da645c", 0, "6fd3754a-0e85-477b-b8a3-03c4cf85484d", "Admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEEmktLiin1J1LHismokQDD4E8i+nAgnkqHWvn7tPTUGK5H9DexeU7v/7KqAB6XrBtA==", null, false, "768678a7-43e5-42ca-829a-31ef7e8e98d1", false, "Admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "90d0cd0d-1b76-4ce6-a881-2290e64804f7", "b82fb2a7-ac59-4777-b47a-43b8a6da645c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54a9e2fa-d22b-45a6-a227-e872a70a68d8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "90d0cd0d-1b76-4ce6-a881-2290e64804f7", "b82fb2a7-ac59-4777-b47a-43b8a6da645c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90d0cd0d-1b76-4ce6-a881-2290e64804f7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b82fb2a7-ac59-4777-b47a-43b8a6da645c");

            migrationBuilder.DropColumn(
                name: "Prise",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f753242-571c-4917-a60c-d3bec5150c13", "c51f4363-b927-47b2-9672-3499fa01250b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af568145-94b6-4ebb-96ce-de038b49671c", "e8f96c45-3400-4a0c-a037-7af174186d7c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6507f661-7be6-4fbe-bb85-2f8c0ee51c09", 0, "ec0b25e7-b810-4ef5-a898-67619b130638", "Admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEJ7daT+QSqHUHPTrGVrd245S6DPxuf+Fsx7WPuV92JC7IWrLzohKVmsCz/BeXxTOYQ==", null, false, "59be1698-4812-400e-ab54-fc84ae1a3756", false, "Admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "af568145-94b6-4ebb-96ce-de038b49671c", "6507f661-7be6-4fbe-bb85-2f8c0ee51c09" });
        }
    }
}
