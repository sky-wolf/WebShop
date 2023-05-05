using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Data.Migrations
{
    public partial class addproductpreceorderitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "APrice",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "491f1e07-97a3-4fc6-9ac2-24d1db9d917d", "4fc94176-2148-4304-b083-a7f32f0babca", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b2e9e97-2374-4dad-acd3-2e3bbba0d35d", "ba88a3a2-6d41-4775-a7b9-f411fc529053", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c79a063c-8a2f-43e0-b7ed-0a6d91452120", 0, "2a601e6c-3288-4590-a535-e505ea9a7f9d", "Admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEG7K3vNjKfwCmb+xUS0y+qCD1ptvHoCRMLyMCu5U2Yki+7WpNrmq0WGb16nGn3HTtg==", null, false, "33f02034-1323-4cf0-956e-e21dc16186b6", false, "Admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "491f1e07-97a3-4fc6-9ac2-24d1db9d917d", "c79a063c-8a2f-43e0-b7ed-0a6d91452120" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b2e9e97-2374-4dad-acd3-2e3bbba0d35d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "491f1e07-97a3-4fc6-9ac2-24d1db9d917d", "c79a063c-8a2f-43e0-b7ed-0a6d91452120" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "491f1e07-97a3-4fc6-9ac2-24d1db9d917d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c79a063c-8a2f-43e0-b7ed-0a6d91452120");

            migrationBuilder.DropColumn(
                name: "APrice",
                table: "OrderItems");

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
    }
}
