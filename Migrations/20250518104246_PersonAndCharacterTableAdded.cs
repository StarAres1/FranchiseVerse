using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranchiseVerse.Migrations
{
    /// <inheritdoc />
    public partial class PersonAndCharacterTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "character",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "character",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "character",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "character",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "character");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "character");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "character");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "character");
        }
    }
}
