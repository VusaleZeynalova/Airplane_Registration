using Microsoft.EntityFrameworkCore.Migrations;

namespace layihe.Migrations
{
    public partial class Updcity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartureCities_ArrivialCities_ArrivialCitiesId",
                table: "DepartureCities");

            migrationBuilder.DropIndex(
                name: "IX_DepartureCities_ArrivialCitiesId",
                table: "DepartureCities");

            migrationBuilder.DropColumn(
                name: "ArrivialCitiesId",
                table: "DepartureCities");

            migrationBuilder.RenameColumn(
                name: "ArrivialCitiesId",
                table: "ArrivialCities",
                newName: "ArrivialCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArrivialCityId",
                table: "ArrivialCities",
                newName: "ArrivialCitiesId");

            migrationBuilder.AddColumn<int>(
                name: "ArrivialCitiesId",
                table: "DepartureCities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DepartureCities_ArrivialCitiesId",
                table: "DepartureCities",
                column: "ArrivialCitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartureCities_ArrivialCities_ArrivialCitiesId",
                table: "DepartureCities",
                column: "ArrivialCitiesId",
                principalTable: "ArrivialCities",
                principalColumn: "ArrivialCitiesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
