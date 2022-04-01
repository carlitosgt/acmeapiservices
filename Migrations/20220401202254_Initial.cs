using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIsurveys.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Encuestas",
                columns: table => new
                {
                    IdEncuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEncuesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkEncuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuestas", x => x.IdEncuesta);
                    table.ForeignKey(
                        name: "FK_Encuestas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CamposEncuesta",
                columns: table => new
                {
                    IdCampoEncuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCampo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TituloCampo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsRequerido = table.Column<bool>(type: "bit", nullable: false),
                    tipoCampo = table.Column<int>(type: "int", nullable: false),
                    IdEncuesta = table.Column<int>(type: "int", nullable: true),
                    EncuestaIdEncuesta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamposEncuesta", x => x.IdCampoEncuesta);
                    table.ForeignKey(
                        name: "FK_CamposEncuesta_Encuestas_EncuestaIdEncuesta",
                        column: x => x.EncuestaIdEncuesta,
                        principalTable: "Encuestas",
                        principalColumn: "IdEncuesta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CamposEncuesta_EncuestaIdEncuesta",
                table: "CamposEncuesta",
                column: "EncuestaIdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_UserId",
                table: "Encuestas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamposEncuesta");

            migrationBuilder.DropTable(
                name: "Encuestas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
