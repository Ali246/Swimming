using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swimming.Data.Migrations
{
    public partial class tre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "placeNo",
                table: "CWRChampionShipwithRacing",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Race9",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race8",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race7",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race6",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race5",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race4",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race3",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race2",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race11",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race10",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race1",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AllRacingDataTBL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaptainOrOrganization",
                table: "AllRacingDataTBL",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AllRacingFindDataTBL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CaptainOrOrganization = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Race21 = table.Column<int>(nullable: true),
                    Race22 = table.Column<int>(nullable: true),
                    Race23 = table.Column<int>(nullable: true),
                    Race24 = table.Column<int>(nullable: true),
                    Race25 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllRacingFindDataTBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RACWITHCHTBL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Result = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RACWITHCHTBL", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllRacingFindDataTBL");

            migrationBuilder.DropTable(
                name: "RACWITHCHTBL");

            migrationBuilder.DropColumn(
                name: "placeNo",
                table: "CWRChampionShipwithRacing");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AllRacingDataTBL");

            migrationBuilder.DropColumn(
                name: "CaptainOrOrganization",
                table: "AllRacingDataTBL");

            migrationBuilder.AlterColumn<string>(
                name: "Race9",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race8",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race7",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race6",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race5",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race4",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race3",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race2",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race11",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race10",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Race1",
                table: "AllRacingDataTBL",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
