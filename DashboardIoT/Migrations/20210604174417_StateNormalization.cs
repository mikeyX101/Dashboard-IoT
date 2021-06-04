using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardIoT.Migrations
{
    public partial class StateNormalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemStates");

            migrationBuilder.CreateTable(
                name: "ArmedStates",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    state = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmedStates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SilentStates",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    state = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SilentStates", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmedStates_id",
                table: "ArmedStates",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SilentStates_id",
                table: "SilentStates",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmedStates");

            migrationBuilder.DropTable(
                name: "SilentStates");

            migrationBuilder.CreateTable(
                name: "SystemStates",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    silentModeActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    state = table.Column<int>(type: "INTEGER", nullable: false),
                    time = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemStates", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SystemStates_id",
                table: "SystemStates",
                column: "id",
                unique: true);
        }
    }
}
