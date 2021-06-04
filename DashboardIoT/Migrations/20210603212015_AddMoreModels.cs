using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardIoT.Migrations
{
    public partial class AddMoreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlarmStates",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    state = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmStates", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CalibratedDistances",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    calibratedDistance = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalibratedDistances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SystemStates",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    state = table.Column<int>(type: "INTEGER", nullable: false),
                    silentModeActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemStates", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlarmStates_id",
                table: "AlarmStates",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalibratedDistances_id",
                table: "CalibratedDistances",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemStates_id",
                table: "SystemStates",
                column: "id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmStates");

            migrationBuilder.DropTable(
                name: "CalibratedDistances");

            migrationBuilder.DropTable(
                name: "SystemStates");
        }
    }
}
