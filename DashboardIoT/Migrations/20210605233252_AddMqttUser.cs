using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardIoT.Migrations
{
	public partial class AddMqttUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MqttUsers",
                columns: table => new
                {
                    id = table.Column<uint>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    clientId = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    salt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MqttUsers", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "MqttUsers",
                columns: new[] { "id", "clientId", "password", "salt", "username" },
                values: new object[] { 1, "AlarmSystem", "1qh3UlBFsU9Jw0TAjYitz5iigv9m63/79AafWnWLx/Q=", "w2jQ/QQSfqDe34fRaTVAHQ==", "AlarmSystem" });

            migrationBuilder.CreateIndex(
                name: "IX_MqttUsers_clientId",
                table: "MqttUsers",
                column: "clientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MqttUsers_id",
                table: "MqttUsers",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MqttUsers_username",
                table: "MqttUsers",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MqttUsers");
        }
    }
}
