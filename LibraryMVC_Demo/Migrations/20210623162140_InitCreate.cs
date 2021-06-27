using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMVC_Demo.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    DateOfPublishing = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_books_authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_books_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "AuthorId", "AuthorName" },
                values: new object[,]
                {
                    { 1, "Shirow Masamune " },
                    { 2, "Hitoshi Iwaaki" },
                    { 3, "Yoshitoki Oima" },
                    { 4, "Yana Toboso" },
                    { 5, "Kudan Naduka" },
                    { 6, "Sun Takeda" }
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Sci-Fi" },
                    { 2, "Psychological" },
                    { 3, "Drame" },
                    { 4, "Mystery" },
                    { 5, "Thriller" },
                    { 6, "Seinen" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "BookId", "AuthorId", "DateOfPublishing", "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2008, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "The Ghost in the Shell" },
                    { 2, 2, new DateTime(2008, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Parasyte" },
                    { 3, 3, new DateTime(2014, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "A Silent Voice" },
                    { 4, 4, new DateTime(2010, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Black Butler" },
                    { 5, 5, new DateTime(2018, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Angels of Death" },
                    { 6, 6, new DateTime(2017, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Gleipnir" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_GenreId",
                table: "books",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "genres");
        }
    }
}
