using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.CommunityBackend.Migrations
{
    /// <inheritdoc />
    public partial class groupnamepost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "groupName",
                table: "Posts");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "groupName",
                table: "Posts");
        }
    }
}
