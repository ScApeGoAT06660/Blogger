using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class SeedAdminUserFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e5c27a7-4679-40cb-b2f4-ec25518f7506");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e32588d5-84d5-4423-940a-77f8b23edb8b", 0, "2282952a-293c-4e7c-b9e0-8e95ec15ead2", "admin@bloggie.com", true, false, null, "ADMIN@BLOGGIE.COM", "ADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEEU7vxejBzfSgXs35j54Ik2Fxhs1oyqryrY0sfpGTUiPHVWzxcZw2vg4X4DuTF6AdQ==", null, false, "cfeb3e90-a12e-4e5d-9c7e-2c1a3f63db4b", false, "admin@bloggie.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f9b16c62-86a2-4ae2-98b4-35a0b82440a1", "e32588d5-84d5-4423-940a-77f8b23edb8b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9b16c62-86a2-4ae2-98b4-35a0b82440a1", "e32588d5-84d5-4423-940a-77f8b23edb8b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e32588d5-84d5-4423-940a-77f8b23edb8b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e5c27a7-4679-40cb-b2f4-ec25518f7506", null, "User", "USER" });
        }
    }
}
