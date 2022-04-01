using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIsurveys.Migrations
{
    public partial class Modificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Encuestas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Encuestas");
        }
    }
}
