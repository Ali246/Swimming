using Microsoft.EntityFrameworkCore.Migrations;

namespace Swimming.Data.Migrations
{
    public partial class updateonqualifiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RacingId",
                table: "QualifierDetails");

            migrationBuilder.AddColumn<int>(
                name: "RacingId",
                table: "Qualifiers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RacingId",
                table: "Qualifiers");

            migrationBuilder.AddColumn<int>(
                name: "RacingId",
                table: "QualifierDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
