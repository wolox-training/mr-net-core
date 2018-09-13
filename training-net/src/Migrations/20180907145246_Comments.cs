using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace src.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Movies",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movies",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Text = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    MovieID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_MovieID",
                table: "Comment",
                column: "MovieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
