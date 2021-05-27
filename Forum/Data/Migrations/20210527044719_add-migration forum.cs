using Microsoft.EntityFrameworkCore.Migrations;

namespace Forum.Data.Migrations
{
    public partial class addmigrationforum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Author_AuthorID",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_Author_AuthorID",
                table: "Reply");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Reply_AuthorID",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Post_AuthorID",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Reply");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Post");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Reply",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reply_ApplicationUserID",
                table: "Reply",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_ApplicationUserID",
                table: "Post",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_ApplicationUserID",
                table: "Post",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_AspNetUsers_ApplicationUserID",
                table: "Reply",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_ApplicationUserID",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Reply_AspNetUsers_ApplicationUserID",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Reply_ApplicationUserID",
                table: "Reply");

            migrationBuilder.DropIndex(
                name: "IX_Post_ApplicationUserID",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Reply");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Reply",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reply_AuthorID",
                table: "Reply",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_AuthorID",
                table: "Post",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Author_AuthorID",
                table: "Post",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_Author_AuthorID",
                table: "Reply",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
