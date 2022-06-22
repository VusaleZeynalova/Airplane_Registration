using Microsoft.EntityFrameworkCore.Migrations;

namespace layihe.Migrations
{
    public partial class upflightmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArrivialCities_NewFlights_NewFlightId",
                table: "ArrivialCities");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartureCities_NewFlights_NewFlightId",
                table: "DepartureCities");

            migrationBuilder.DropIndex(
                name: "IX_DepartureCities_NewFlightId",
                table: "DepartureCities");

            migrationBuilder.DropIndex(
                name: "IX_ArrivialCities_NewFlightId",
                table: "ArrivialCities");

            migrationBuilder.DropColumn(
                name: "NewFlightId",
                table: "DepartureCities");

            migrationBuilder.DropColumn(
                name: "NewFlightId",
                table: "ArrivialCities");

            migrationBuilder.CreateIndex(
                name: "IX_NewFlights_ArrivialCityId",
                table: "NewFlights",
                column: "ArrivialCityId");

            migrationBuilder.CreateIndex(
                name: "IX_NewFlights_DepartureCityId",
                table: "NewFlights",
                column: "DepartureCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewFlights_ArrivialCities_ArrivialCityId",
                table: "NewFlights",
                column: "ArrivialCityId",
                principalTable: "ArrivialCities",
                principalColumn: "ArrivialCityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewFlights_DepartureCities_DepartureCityId",
                table: "NewFlights",
                column: "DepartureCityId",
                principalTable: "DepartureCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewFlights_ArrivialCities_ArrivialCityId",
                table: "NewFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_NewFlights_DepartureCities_DepartureCityId",
                table: "NewFlights");

            migrationBuilder.DropIndex(
                name: "IX_NewFlights_ArrivialCityId",
                table: "NewFlights");

            migrationBuilder.DropIndex(
                name: "IX_NewFlights_DepartureCityId",
                table: "NewFlights");

            migrationBuilder.AddColumn<int>(
                name: "NewFlightId",
                table: "DepartureCities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewFlightId",
                table: "ArrivialCities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartureCities_NewFlightId",
                table: "DepartureCities",
                column: "NewFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrivialCities_NewFlightId",
                table: "ArrivialCities",
                column: "NewFlightId");

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
    }
}
