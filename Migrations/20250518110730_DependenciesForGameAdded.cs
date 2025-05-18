using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranchiseVerse.Migrations
{
    /// <inheritdoc />
    public partial class DependenciesForGameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characterPerson",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    RoleType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characterPerson", x => new { x.GameId, x.CharacterId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_characterPerson_character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_characterPerson_game_GameId",
                        column: x => x.GameId,
                        principalTable: "game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_characterPerson_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gamePerson",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    RoleType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gamePerson", x => new { x.GameId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_gamePerson_game_GameId",
                        column: x => x.GameId,
                        principalTable: "game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gamePerson_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_characterPerson_CharacterId",
                table: "characterPerson",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_characterPerson_PersonId",
                table: "characterPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_gamePerson_PersonId",
                table: "gamePerson",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "characterPerson");

            migrationBuilder.DropTable(
                name: "gamePerson");
        }
    }
}
