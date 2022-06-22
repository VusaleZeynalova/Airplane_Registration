using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace layihe.Migrations
{
    public partial class newflightig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArrivialCities_Flights_FlightId",
                table: "ArrivialCities");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartureCities_Flights_FlightId",
                table: "DepartureCities");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "DepartureCities",
                newName: "NewFlightId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartureCities_FlightId",
                table: "DepartureCities",
                newName: "IX_DepartureCities_NewFlightId");

            migrationBuilder.RenameColumn(
                name: "FlightId",
                table: "ArrivialCities",
                newName: "NewFlightId");

            migrationBuilder.RenameIndex(
                name: "IX_ArrivialCities_FlightId",
                table: "ArrivialCities",
                newName: "IX_ArrivialCities_NewFlightId");

            migrationBuilder.CreateTable(
                name: "NewFlights",
                columns: table => new
                {
                    NewFlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivialCityId = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivialTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewFlights", x => x.NewFlightId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ArrivialCities_NewFlights_NewFlightId",
                table: "ArrivialCities",
                column: "NewFlightId",
                principalTable: "NewFlights",
                principalColumn: "NewFlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartureCities_NewFlights_NewFlightId",
                table: "DepartureCities",
                column: "NewFlightId",
                principalTable: "NewFlights",
                principalColumn: "NewFlightId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArrivialCities_NewFlights_NewFlightId",
                table: "ArrivialCities");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartureCities_NewFlights_NewFlightId",
                table: "DepartureCities");

            migrationBuilder.DropTable(
                name: "NewFlights");

            migrationBuilder.RenameColumn(
                name: "NewFlightId",
                table: "DepartureCities",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartureCities_NewFlightId",
                table: "DepartureCities",
                newName: "IX_DepartureCities_FlightId");

            migrationBuilder.RenameColumn(
                name: "NewFlightId",
                table: "ArrivialCities",
                newName: "FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_ArrivialCities_NewFlightId",
                table: "ArrivialCities",
                newName: "IX_ArrivialCities_FlightId");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivialCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivialTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ArrivialCities_Flights_FlightId",
                table: "ArrivialCities",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartureCities_Flights_FlightId",
                table: "DepartureCities",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
