using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EP_Borda.Data.Migrations
{
    /// <inheritdoc />
    public partial class InicialModeloDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Edad = table.Column<int>(type: "INTEGER", nullable: false),
                    Posicion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_assignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_t_assignment_t_player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "t_player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_assignment_t_team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "t_team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_assignment_PlayerId_TeamId",
                table: "t_assignment",
                columns: new[] { "PlayerId", "TeamId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_assignment_TeamId",
                table: "t_assignment",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_assignment");

            migrationBuilder.DropTable(
                name: "t_player");

            migrationBuilder.DropTable(
                name: "t_team");
        }
    }
}
