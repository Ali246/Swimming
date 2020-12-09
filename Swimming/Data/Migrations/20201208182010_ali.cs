using Microsoft.EntityFrameworkCore.Migrations;

namespace Swimming.Data.Migrations
{
    public partial class ali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllRacingDataTBL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Race1 = table.Column<string>(nullable: true),
                    Race2 = table.Column<string>(nullable: true),
                    Race3 = table.Column<string>(nullable: true),
                    Race4 = table.Column<string>(nullable: true),
                    Race5 = table.Column<string>(nullable: true),
                    Race6 = table.Column<string>(nullable: true),
                    Race7 = table.Column<string>(nullable: true),
                    Race8 = table.Column<string>(nullable: true),
                    Race9 = table.Column<string>(nullable: true),
                    Race10 = table.Column<string>(nullable: true),
                    Race11 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllRacingDataTBL", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllRacingDataTBL");
        }
    }
}
