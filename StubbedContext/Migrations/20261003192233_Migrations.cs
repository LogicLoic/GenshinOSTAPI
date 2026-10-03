using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StubbedContext.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Visibility = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatorId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contains",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomTitle = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumId = table.Column<long>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    FriendId = table.Column<long>(type: "INTEGER", nullable: false),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Artist = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<long>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "CreationDate", "CreatorId", "Name", "Visibility" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, "Album 1", 1 },
                    { 2L, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, "Album 2", 2 },
                    { 3L, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3L, "Album 3", 1 }
                });

            migrationBuilder.InsertData(
                table: "Contains",
                columns: new[] { "Id", "AlbumId", "CustomTitle", "TrackId" },
                values: new object[,]
                {
                    { 1L, 1L, "Custom Title 1", 1L },
                    { 2L, 1L, "Custom Title 2", 2L },
                    { 3L, 2L, "Custom Title 3", 3L },
                    { 4L, 2L, "Custom Title 4", 4L },
                    { 5L, 3L, "Custom Title 5", 5L }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "FriendId", "Strength", "UserId" },
                values: new object[,]
                {
                    { 1L, 3L, 0, 2L },
                    { 2L, 2L, 0, 3L }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Artist", "Duration", "Rating", "Title" },
                values: new object[,]
                {
                    { 1L, "Artist 1", 180L, 4.5, "Track 1" },
                    { 2L, "Artist 2", 200L, 4.0, "Track 2" },
                    { 3L, "Artist 3", 240L, 5.0, "Track 3" },
                    { 4L, "Artist 4", 210L, 3.5, "Track 4" },
                    { 5L, "Artist 5", 190L, 4.2000000000000002, "Track 5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Role", "Username" },
                values: new object[,]
                {
                    { 1L, 2, "Admin" },
                    { 2L, 1, "User1" },
                    { 3L, 1, "User2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Contains");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
