using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuineaPigApi.Migrations
{
    public partial class LastHealthCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HealthCheckDate",
                table: "HealthChecks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 5, 14, 27, 0, 153, DateTimeKind.Local).AddTicks(9171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 4, 20, 12, 36, 424, DateTimeKind.Local).AddTicks(122));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastHealthCheck",
                table: "GuineaPigs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastHealthCheck",
                table: "GuineaPigs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HealthCheckDate",
                table: "HealthChecks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 4, 20, 12, 36, 424, DateTimeKind.Local).AddTicks(122),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 5, 14, 27, 0, 153, DateTimeKind.Local).AddTicks(9171));
        }
    }
}
