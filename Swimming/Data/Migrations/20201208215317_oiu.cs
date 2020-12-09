using Microsoft.EntityFrameworkCore.Migrations;

namespace Swimming.Data.Migrations
{
    public partial class oiu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "CWRChampionShipwithRacing",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "CWRChampionShipwithRacing");
        }
    }
}
