using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Data.Migrations
{
    public partial class addproductnameinitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "327efdf8-ebc1-4652-bf85-ede67947990b", "add6d83a-2897-4ad9-b2d3-88ea8e7ef1a1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1894c02-4516-484d-9d06-7fc9b912cb28", "94b152f3-818c-4202-8423-33ee5fd8bbc4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a0dd580c-30d5-493f-820e-e47de4dfdadf", 0, "c060800f-cadc-49c1-928c-754e2cf802dc", "Admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEEV4oN3IdAPJoXeo82pC5fR3gs344feubcIcnY8Zur8LfTQ1mgwIbh/7Xn2rvMjiGQ==", null, false, "6c94d485-3b64-4f48-a5e6-a02824acc855", false, "Admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c1894c02-4516-484d-9d06-7fc9b912cb28", "a0dd580c-30d5-493f-820e-e47de4dfdadf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "327efdf8-ebc1-4652-bf85-ede67947990b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1894c02-4516-484d-9d06-7fc9b912cb28", "a0dd580c-30d5-493f-820e-e47de4dfdadf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1894c02-4516-484d-9d06-7fc9b912cb28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0dd580c-30d5-493f-820e-e47de4dfdadf");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderItems");

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
    }
}
