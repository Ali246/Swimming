using Microsoft.EntityFrameworkCore.Migrations;

namespace Swimming.Data.Migrations
{
    public partial class chwrc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RacingId",
                table: "CSDChampionshipDetails");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "CSDChampionshipDetails");

            migrationBuilder.CreateTable(
                name: "CWRChampionShipwithRacing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionshipDetailsId = table.Column<int>(nullable: false),
                    RacingId = table.Column<int>(nullable: false),
                    Result = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CWRChampionShipwithRacing", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CWRChampionShipwithRacing");

            migrationBuilder.AddColumn<int>(
                name: "RacingId",
                table: "CSDChampionshipDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Result",
                table: "CSDChampionshipDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
