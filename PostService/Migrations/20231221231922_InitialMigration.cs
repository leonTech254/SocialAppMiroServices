using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostService.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    postid = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    post = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
