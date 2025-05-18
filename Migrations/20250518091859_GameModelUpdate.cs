using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranchiseVerse.Migrations
{
    /// <inheritdoc />
    public partial class GameModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeRating",
                table: "game",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "BoxOffice",
                table: "game",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "game",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "game",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "game",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "game",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "game",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "game",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "game",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "game",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "game",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "game",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "game",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRating",
                table: "game");

            migrationBuilder.DropColumn(
                name: "BoxOffice",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "game");

            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "game");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "game");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "game");
        }
    }
}
