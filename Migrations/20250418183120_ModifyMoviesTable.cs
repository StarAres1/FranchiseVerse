using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FranchiseVerse.Migrations
{
    /// <inheritdoc />
    public partial class ModifyMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeRating",
                table: "movie",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "BoxOffice",
                table: "movie",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "movie",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "movie",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "movie",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "movie",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "movie",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "movie",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "movie",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PosterUrl",
                table: "movie",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "movie",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "movie",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "movie",
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
                table: "movie");

            migrationBuilder.DropColumn(
                name: "BoxOffice",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "PosterUrl",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "movie");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "movie");
        }
    }
}
