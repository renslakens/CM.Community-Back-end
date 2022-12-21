using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.CommunityBackend.Migrations
{
    /// <inheritdoc />
    public partial class editedPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Groups_groupID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_groupID",
                table: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Posts_groupID",
                table: "Posts",
                column: "groupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Groups_groupID",
                table: "Posts",
                column: "groupID",
                principalTable: "Groups",
                principalColumn: "groupID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
