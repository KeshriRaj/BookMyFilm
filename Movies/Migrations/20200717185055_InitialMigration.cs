using Microsoft.EntityFrameworkCore.Migrations;

namespace Movies.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguagesTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageNames = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoviesName = table.Column<string>(nullable: true),
                    LanguageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesTable_LanguagesTable_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LanguagesTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HonestReviews = table.Column<string>(nullable: true),
                    MoviesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewsTable_MoviesTable_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "MoviesTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesTable_LanguageId",
                table: "MoviesTable",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsTable_MoviesId",
                table: "ReviewsTable",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewsTable");

            migrationBuilder.DropTable(
                name: "MoviesTable");

            migrationBuilder.DropTable(
                name: "LanguagesTable");
        }
    }
}
