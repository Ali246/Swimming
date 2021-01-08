using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swimming.Data.Migrations
{
    public partial class Qualifiers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Race25",
                table: "AllRacingFindDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race24",
                table: "AllRacingFindDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race23",
                table: "AllRacingFindDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race22",
                table: "AllRacingFindDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race21",
                table: "AllRacingFindDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AllRacingFindDataTBL",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race9",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race8",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race7",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race6",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race5",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race4",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race3",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race2",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race11",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race10",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Race1",
                table: "AllRacingDataTBL",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AllRacingDataTBL",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PartiWLastResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaptainOrOrganization = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Result = table.Column<double>(nullable: false),
                    GenderName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartiWLastResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartiWRacingTBL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartiWRacingTBL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualifierDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualifierId = table.Column<int>(nullable: false),
                    PartiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualifierDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ChampionId = table.Column<int>(nullable: false),
                    RacingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultOfRacingFin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_ResultOfRacingFin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultOfRacingFrees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    CaptainOrOrganization = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Race1 = table.Column<int>(nullable: true),
                    Race2 = table.Column<int>(nullable: true),
                    Race3 = table.Column<int>(nullable: true),
                    Race4 = table.Column<int>(nullable: true),
                    Race5 = table.Column<int>(nullable: true),
                    Race6 = table.Column<int>(nullable: true),
                    Race7 = table.Column<int>(nullable: true),
                    Race8 = table.Column<int>(nullable: true),
                    Race9 = table.Column<int>(nullable: true),
                    Race10 = table.Column<int>(nullable: true),
                    Race11 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultOfRacingFrees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartiWLastResults");

            migrationBuilder.DropTable(
                name: "PartiWRacingTBL");

            migrationBuilder.DropTable(
                name: "QualifierDetails");

            migrationBuilder.DropTable(
                name: "Qualifiers");

            migrationBuilder.DropTable(
                name: "ResultOfRacingFin");

            migrationBuilder.DropTable(
                name: "ResultOfRacingFrees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AllRacingFindDataTBL");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AllRacingDataTBL");

            migrationBuilder.AlterColumn<int>(
                name: "Race25",
                table: "AllRacingFindDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race24",
                table: "AllRacingFindDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race23",
                table: "AllRacingFindDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race22",
                table: "AllRacingFindDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race21",
                table: "AllRacingFindDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race9",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race8",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race7",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race6",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race5",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race4",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race3",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race2",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race11",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race10",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Race1",
                table: "AllRacingDataTBL",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
