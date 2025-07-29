using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIBRARY_SYSTEM.Migrations
{
    /// <inheritdoc />
    public partial class MemberUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategories_Members_MemberId",
                table: "BookCategories");

            migrationBuilder.DropIndex(
                name: "IX_BookCategories_MemberId",
                table: "BookCategories");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "BookCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Members",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Members",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "BookCategories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_MemberId",
                table: "BookCategories",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategories_Members_MemberId",
                table: "BookCategories",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId");
        }
    }
}
