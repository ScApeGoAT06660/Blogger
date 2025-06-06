using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Migrations
{
    /// <inheritdoc />
    public partial class FixingCommants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Commant_BlogPostId",
                table: "Commant",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commant_BlogPost_BlogPostId",
                table: "Commant",
                column: "BlogPostId",
                principalTable: "BlogPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commant_BlogPost_BlogPostId",
                table: "Commant");

            migrationBuilder.DropIndex(
                name: "IX_Commant_BlogPostId",
                table: "Commant");
        }
    }
}
