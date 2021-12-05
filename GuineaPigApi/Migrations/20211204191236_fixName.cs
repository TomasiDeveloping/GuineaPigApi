using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuineaPigApi.Migrations
{
    public partial class fixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ISEarsCheck",
                table: "HealthChecks",
                newName: "IsEarsCheck");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HealthCheckDate",
                table: "HealthChecks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 4, 20, 12, 36, 424, DateTimeKind.Local).AddTicks(122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 4, 18, 48, 51, 887, DateTimeKind.Local).AddTicks(3985));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEarsCheck",
                table: "HealthChecks",
                newName: "ISEarsCheck");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HealthCheckDate",
                table: "HealthChecks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 4, 18, 48, 51, 887, DateTimeKind.Local).AddTicks(3985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 4, 20, 12, 36, 424, DateTimeKind.Local).AddTicks(122));
        }
    }
}
