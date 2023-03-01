using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finanzauto.ManagementIndicators.API.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GV");

            migrationBuilder.CreateTable(
                name: "GaviotaData",
                schema: "GV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    PhaseId = table.Column<int>(type: "int", nullable: false),
                    Phase = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Analyst = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartHour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EndHour = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GaviotaData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GaviotaData",
                schema: "GV");
        }
    }
}
