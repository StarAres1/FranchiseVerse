using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FranchiseVerse.Migrations
{
    /// <inheritdoc />
    public partial class DependenciesForGameUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_gamePerson",
                table: "gamePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_characterPerson",
                table: "characterPerson");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "gamePerson",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "characterPerson",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_gamePerson",
                table: "gamePerson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_characterPerson",
                table: "characterPerson",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_gamePerson_GameId",
                table: "gamePerson",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_characterPerson_GameId",
                table: "characterPerson",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_gamePerson",
                table: "gamePerson");

            migrationBuilder.DropIndex(
                name: "IX_gamePerson_GameId",
                table: "gamePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_characterPerson",
                table: "characterPerson");

            migrationBuilder.DropIndex(
                name: "IX_characterPerson_GameId",
                table: "characterPerson");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "gamePerson");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "characterPerson");

            migrationBuilder.AddPrimaryKey(
                name: "PK_gamePerson",
                table: "gamePerson",
                columns: new[] { "GameId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_characterPerson",
                table: "characterPerson",
                columns: new[] { "GameId", "CharacterId", "PersonId" });
        }
    }
}
