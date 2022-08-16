using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentTemperature = table.Column<double>(type: "float", nullable: false),
                    AverageTemp = table.Column<double>(type: "float", nullable: false),
                    MaxTemp = table.Column<double>(type: "float", nullable: false),
                    MinTemp = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherStatistics", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Weather",
                columns: new[] { "Id", "City", "Date", "Temperature" },
                values: new object[,]
                {
                    { 1, "Lisboa", new DateTime(2022, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), 25.0 },
                    { 2, "Lisboa", new DateTime(2022, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 27.0 },
                    { 3, "Lisboa", new DateTime(2022, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 28.0 },
                    { 4, "Lisboa", new DateTime(2022, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 30.0 },
                    { 5, "Lisboa", new DateTime(2022, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 22.0 },
                    { 6, "Porto", new DateTime(2022, 8, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), 20.0 },
                    { 7, "Porto", new DateTime(2022, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 22.0 },
                    { 8, "Porto", new DateTime(2022, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), 21.0 },
                    { 9, "Porto", new DateTime(2022, 8, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 23.0 },
                    { 10, "Porto", new DateTime(2022, 8, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 26.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "WeatherStatistics");
        }
    }
}
