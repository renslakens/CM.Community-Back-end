using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CM.CommunityBackend.Migrations
{
    /// <inheritdoc />
    public partial class removeunusedtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttachmentPosts");

            migrationBuilder.DropTable(
                name: "CommentPosts");

            migrationBuilder.DropTable(
                name: "ProfilePicture");

            migrationBuilder.DropTable(
                name: "TagPosts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "groupName",
                table: "Posts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "groupName",
                table: "Posts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AttachmentPosts",
                columns: table => new
                {
                    postID = table.Column<int>(type: "int", nullable: false),
                    attachment = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentPosts", x => x.postID);
                    table.ForeignKey(
                        name: "FK_AttachmentPosts_Posts_postID",
                        column: x => x.postID,
                        principalTable: "Posts",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentID);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePicture",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false),
                    profilePicture = table.Column<byte[]>(type: "varbinary(8000)", maxLength: 8000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePicture", x => x.userID);
                    table.ForeignKey(
                        name: "FK_ProfilePicture_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    tagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tagName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.tagID);
                });

            migrationBuilder.CreateTable(
                name: "CommentPosts",
                columns: table => new
                {
                    postID = table.Column<int>(type: "int", nullable: false),
                    commentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPosts", x => new { x.commentID, x.postID });
                    table.ForeignKey(
                        name: "FK_CommentPosts_Comments_commentID",
                        column: x => x.commentID,
                        principalTable: "Comments",
                        principalColumn: "commentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentPosts_Posts_postID",
                        column: x => x.postID,
                        principalTable: "Posts",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagPosts",
                columns: table => new
                {
                    postID = table.Column<int>(type: "int", nullable: false),
                    tagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPosts", x => new { x.tagID, x.postID });
                    table.ForeignKey(
                        name: "FK_TagPosts_Posts_postID",
                        column: x => x.postID,
                        principalTable: "Posts",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagPosts_Tags_tagID",
                        column: x => x.tagID,
                        principalTable: "Tags",
                        principalColumn: "tagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosts_postID",
                table: "CommentPosts",
                column: "postID");

            migrationBuilder.CreateIndex(
                name: "IX_TagPosts_postID",
                table: "TagPosts",
                column: "postID");
        }
    }
}
