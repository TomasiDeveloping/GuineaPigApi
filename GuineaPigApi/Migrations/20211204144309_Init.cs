using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuineaPigApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuineaPigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuineaPigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuineaPigId = table.Column<int>(type: "int", nullable: false),
                    IsPawsCheck = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PawsComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsChinCheck = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ChinComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsMouthCheck = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    MouthComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsNoseCheck = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    NoseComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsTeethCheck = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TeethComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEyesCheck = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EyesComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ISEarsCheck = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    EarsComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsFurCheck = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FurComment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HealthCheckDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 12, 4, 15, 43, 9, 857, DateTimeKind.Local).AddTicks(6597))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthChecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthChecks_GuineaPigs_GuineaPigId",
                        column: x => x.GuineaPigId,
                        principalTable: "GuineaPigs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthChecks_GuineaPigId",
                table: "HealthChecks",
                column: "GuineaPigId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthChecks");

            migrationBuilder.DropTable(
                name: "GuineaPigs");
        }
    }
}
