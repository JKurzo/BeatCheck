using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthCheckSuites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TargetName = table.Column<string>(type: "TEXT", nullable: false),
                    TargetType = table.Column<string>(type: "TEXT", nullable: false),
                    HealthCheckSuiteDiscriminator = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckSuites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthCheckDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    Details = table.Column<string>(type: "TEXT", nullable: true),
                    CheckTypeDiscriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    HealthCheckSuiteId = table.Column<int>(type: "INTEGER", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCheckDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCheckDefinitions_HealthCheckSuites_HealthCheckSuiteId",
                        column: x => x.HealthCheckSuiteId,
                        principalTable: "HealthCheckSuites",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthCheckDefinitions_HealthCheckSuiteId",
                table: "HealthCheckDefinitions",
                column: "HealthCheckSuiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthCheckDefinitions");

            migrationBuilder.DropTable(
                name: "HealthCheckSuites");
        }
    }
}
