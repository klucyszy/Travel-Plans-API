using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlans.Infrastructure.Migrations
{
    public partial class Includelocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Locations",
                table: "TravelPlans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locations",
                table: "TravelPlans");
        }
    }
}
