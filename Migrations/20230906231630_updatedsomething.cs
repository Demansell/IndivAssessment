using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndivAssessment.Migrations
{
    public partial class updatedsomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "ArtistId", "Length", "Title" },
                values: new object[,]
                {
                    { 1, "Thriller 25", 1, 110, "Beat it" },
                    { 2, "Jail house rock", 2, 130, "Jail house rock" },
                    { 3, "Fire in the church", 3, 170, "Fire in the church" },
                    { 4, "Tha carter 3", 4, 140, "A mili" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Album", "ArtistId", "Length", "Title" },
                values: new object[,]
                {
                    { 1, "Thriller 25", 1, 110, "Beat it" },
                    { 2, "Jail house rock", 2, 130, "Jail house rock" },
                    { 3, "Fire in the church", 3, 170, "Fire in the church" },
                    { 4, "Tha carter 3", 4, 140, "A mili" }
                });
        }
    }
}
