using Microsoft.EntityFrameworkCore.Migrations;

namespace APIsurveys.Migrations
{
    public partial class addrespuesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Respuesta",
                table: "CamposEncuesta",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Respuesta",
                table: "CamposEncuesta");
        }
    }
}
