using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e5c27a7-4679-40cb-b2f4-ec25518f7506", null, "User", "USER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e5c27a7-4679-40cb-b2f4-ec25518f7506");
        }
    }
}
