using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.CommunityBackend.Migrations
{
    /// <inheritdoc />
    public partial class addnametopost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userFirstname",
                table: "Posts",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userLastName",
                table: "Posts",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userFirstname",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "userLastName",
                table: "Posts");
        }
    }
}
